using Heroku.Model;
using System;
using System.Collections.Generic;

namespace Heroku.Client
{
	public abstract class ResourceClient<TResource> where TResource : ResourceBase
	{
		private readonly string _path;

		protected readonly HerokuServiceClient _herokuServiceClient;

		protected ResourceClient(HerokuServiceClient herokuServiceClient, string path)
		{
			_herokuServiceClient = herokuServiceClient;
			_path = path;
		}

		protected ResourceClient(HerokuServiceClient herokuServiceClient)
			: this(herokuServiceClient, null)
		{
		}

		protected TResource Create(ICreateRequest<TResource> createRequest = null, Guid? applicationId = null)
		{
			return _herokuServiceClient.Post<TResource>(
				FormatPath(applicationId), createRequest);
		}

		protected void Delete(Guid id, Guid? applicationId = null)
		{
			_herokuServiceClient.Delete<TResource>(
				string.Format("{0}/{1}", FormatPath(applicationId), id));
		}

		protected TResource Get(Guid id, Guid? applicationId = null)
		{
			return _herokuServiceClient.Get<TResource>(
				string.Format("{0}/{1}", FormatPath(applicationId), id));
		}

		protected IEnumerable<TResource> GetAll(Guid? applicationId = null)
		{
			return _herokuServiceClient.Get<IEnumerable<TResource>>(
				FormatPath(applicationId));
		}

		protected void Update(Guid id, IUpdateRequest<TResource> updateRequest, Guid? applicationId = null)
		{
			_herokuServiceClient.Put<TResource>(
				string.Format("{0}/{1}", FormatPath(applicationId), id), updateRequest);
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
