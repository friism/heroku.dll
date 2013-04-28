using Heroku.Model;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;

namespace Heroku.Client
{
	public abstract class ResourceClient<TResource> where TResource : ResourceBase
	{
		private const string _baseUrl = "https://api.heroku.com/";
		private readonly string _path;
		private readonly Action<HttpWebRequest> _requestFilter;

		private static readonly string _userAgent;
		private static readonly string _authorization;

		static ResourceClient()
		{
			var apiKey = ConfigurationManager.AppSettings["ApiKey"];
			if (string.IsNullOrEmpty(apiKey))
			{
				throw new ArgumentException("`ApiKey` not found in config");
			}
			_authorization = string.Format("Basic {0}", Convert.ToBase64String(
				Encoding.ASCII.GetBytes(string.Format(":{0}", apiKey)))
			);

			_userAgent = string.Format("Heroku.dll {0}",
				typeof(ResourceClient<>).Assembly.GetName().Version);
		}

		protected ResourceClient(string path)
			: this()
		{
			_path = path;
		}

		protected ResourceClient()
		{
			JsConfig.PropertyConvention = JsonPropertyConvention.Lenient;
			JsConfig.EmitLowercaseUnderscoreNames = true;

			_requestFilter = request => {
				request.UserAgent = _userAgent;
				request.Accept = "application/vnd.heroku+json; version=3";
				request.Headers.Add("Authorization", _authorization);
				request.ContentType = WebRequestExtensions.Json;
				request.Headers.Add("Authorization", _authorization);
			};
		}

		protected TResource Create(ICreateRequest<TResource> createRequest = null, Guid? applicationId = null)
		{
			return Send<TResource>("POST", FormatPath(applicationId), createRequest);
		}

		protected void Delete(Guid id, Guid? applicationId = null)
		{
			Send<object>("DELETE", string.Format("{0}/{1}", FormatPath(applicationId), id), null);
		}

		protected TResource Get(Guid id, Guid? applicationId = null)
		{
			return Send<TResource>("GET", string.Format("{0}/{1}", FormatPath(applicationId), id), null);
		}

		protected TResponse Get<TResponse>(string path)
		{
			return Send<TResponse>("GET", path, null);
		}

		protected IEnumerable<TResource> GetAll(Guid? applicationId = null)
		{
			return Send(FormatPath(applicationId));
		}

		protected void Update(Guid id, IUpdateRequest<TResource> updateRequest, Guid? applicationId = null)
		{
			Patch<object>(string.Format("{0}/{1}", FormatPath(applicationId), id), updateRequest);
		}

		protected TResponse Patch<TResponse>(string path, object body)
		{
			return Send<TResponse>("PATCH", path, body);
		}

		protected IEnumerable<TResource> Send(string path)
		{
			string range = null;
			do
			{
				var result = _baseUrl.AppendPath(path)
					.GetStringFromUrl(
						requestFilter: x => {
							if (!string.IsNullOrEmpty(range))
							{
								x.AddRange(range);
							}
							_requestFilter(x);
						},
						responseFilter: x => {
							if (x.StatusCode == HttpStatusCode.PartialContent)
							{
								range = x.Headers["Next-Range"];
							}
							else
							{
								range = null;
							}
						}
					)
					.FromJson<IEnumerable<TResource>>();
				foreach (var resource in result)
				{
					yield return resource;
				}
			}
			while (!string.IsNullOrEmpty(range));
		}

		protected TResponse Send<TResponse>(string method, string path, object body)
		{
			try
			{
				return _baseUrl.AppendPath(path)
					.SendStringToUrl(method: method, requestBody: body.ToJson(),
					requestFilter: _requestFilter)
					.FromJson<TResponse>();
			}
			catch (WebException exception)
			{
				var error = exception.GetResponseBody().FromJson<ApiError>();
				throw new ApiException(error, exception);
			}
		}

		protected string FormatPath(Guid? applicationId = null)
		{
			if (applicationId.HasValue)
			{
				return string.Format(_path, applicationId);
			}

			return _path;
		}
	}
}
