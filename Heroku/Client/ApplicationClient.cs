using Heroku.Model;
using System;
using System.Collections.Generic;

namespace Heroku.Client
{
	public class ApplicationClient : ResourceClient<Application>
	{
		public ApplicationClient(HerokuServiceClient herokuServiceClient)
			: base(herokuServiceClient, "apps")
		{
		}

		public Application Create(Application.CreateRequest createRequest)
		{
			return base.Create(createRequest);
		}

		public void Delete(Guid id)
		{
			base.Delete(id);
		}

		public Application Get(Guid id)
		{
			return base.Get(id);
		}

		public IEnumerable<Application> GetAll()
		{
			return base.GetAll();
		}

		public void Update(Guid id, Application.UpdateRequest updateRequest)
		{
			base.Update(id, updateRequest);
		}
	}
}
