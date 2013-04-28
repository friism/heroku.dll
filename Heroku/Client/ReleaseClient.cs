using Heroku.Model;
using System;
using System.Collections.Generic;

namespace Heroku.Client
{
	public class ReleaseClient : ResourceClient<Release>
	{
		public ReleaseClient()
			: base("apps/{0}/releases")
		{
		}

		public Release Get(Guid applicationId, Guid id)
		{
			return base.Get(id, applicationId);
		}

		public IEnumerable<Release> GetAll(Guid applicationId)
		{
			return base.GetAll(applicationId);
		}
	}
}
