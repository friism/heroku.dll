using Heroku.Model;
using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;
using System;
using System.Net;

namespace Heroku
{
	public class HerokuServiceClient : JsonServiceClient
	{
		private static readonly string _userAgent;

		static HerokuServiceClient()
		{
			_userAgent = string.Format("Heroku.dll {0}",
				typeof(HerokuServiceClient).Assembly.GetName().Version);
		}

		public HerokuServiceClient()
			: base("https://api.heroku.com/")
		{
			JsConfig.PropertyConvention = JsonPropertyConvention.Lenient;
			JsConfig.EmitLowercaseUnderscoreNames = true;
			LocalHttpWebRequestFilter = request => request.UserAgent = _userAgent;
		}

		protected override bool HandleResponseException<TResponse>(Exception exception, object request, string requestUri, Func<WebRequest> createWebRequest, Func<WebRequest, WebResponse> getResponse, out TResponse response)
		{
			ThrowWebServiceException<ApiError>(exception, requestUri);

			return base.HandleResponseException<TResponse>(exception, request, requestUri, createWebRequest, getResponse, out response);
		}

		public override TResponse Send<TResponse>(string httpMethod, string relativeOrAbsoluteUrl, object request)
		{
			try
			{
				return base.Send<TResponse>(httpMethod, relativeOrAbsoluteUrl, request);
			}
			catch (WebServiceException exception)
			{
				var error = exception.ResponseDto as ApiError;
				throw new ApiException(error.Message, exception);
			}
		}

		public override string Accept
		{
			get
			{
				return "application/vnd.heroku+json; version=3";
			}
		}
	}
}
