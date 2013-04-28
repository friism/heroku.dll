using Heroku.Model;
using System;
using System.Collections.Generic;

namespace Heroku.Client
{
	public abstract class ApplicationResourceClient<TResource> : ResourceClient<TResource>
		where TResource : ResourceBase
	{
		protected ApplicationResourceClient(string path)
			: base("apps/{0}/" + path)
		{
		}

		public TResource Create(Guid applicationId, ICreateRequest<TResource> createRequest)
		{
			return base.Create(createRequest, applicationId);
		}

		public void Delete(Guid applicationId, Guid id)
		{
			base.Delete(id, applicationId);
		}

		public TResource Get(Guid applicationId, Guid id)
		{
			return base.Get(id, applicationId);
		}

		public IEnumerable<TResource> GetAll(Guid applicationId)
		{
			return base.GetAll(applicationId);
		}
	}
}
