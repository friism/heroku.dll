using Heroku.Model;
using System.Collections.Generic;

namespace Heroku
{
	public abstract class ResourceClient<TResource> where TResource : ResourceBase
	{
		private string _path;

		protected HerokuServiceClient _herokuServiceClient;

		protected ResourceClient(HerokuServiceClient herokuServiceClient, string path)
		{
			_herokuServiceClient = herokuServiceClient;
			_path = path;
		}

		protected ResourceClient(HerokuServiceClient herokuServiceClient)
			: this(herokuServiceClient, null)
		{
		}

		protected TResource Create(ICreateRequest createRequest = null, string applicationIdentifier = null)
		{
			return _herokuServiceClient.Post<TResource>(
				FormatPath(applicationIdentifier), createRequest);
		}

		protected void Delete(string identifier, string applicationIdentifier = null)
		{
			_herokuServiceClient.Delete<TResource>(
				string.Format("{0}/{1}", FormatPath(applicationIdentifier), identifier));
		}

		protected TResource Get(string identifier, string applicationIdentifier = null)
		{
			return _herokuServiceClient.Get<TResource>(
				string.Format("{0}/{1}", FormatPath(applicationIdentifier), identifier));
		}

		protected IEnumerable<TResource> GetAll(string applicationIdentifier = null)
		{
			return _herokuServiceClient.Get<IEnumerable<TResource>>(
				FormatPath(applicationIdentifier));
		}

		protected void Update(string identifier, IUpdateRequest updateRequest, string applicationIdentifier = null)
		{
			_herokuServiceClient.Put<TResource>(
				string.Format("{0}/{1}", FormatPath(applicationIdentifier), identifier), updateRequest);
		}

		protected string FormatPath(string applicationIdentifier = null)
		{
			if (!string.IsNullOrEmpty(applicationIdentifier))
			{
				return string.Format(_path, applicationIdentifier);
			}

			return _path;
		}
	}
}
