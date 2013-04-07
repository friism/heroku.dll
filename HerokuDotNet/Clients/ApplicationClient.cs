using HerokuDotNet.Model;
using System.Collections.Generic;

namespace HerokuDotNet.Clients
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

		public void Delete(string identifier)
		{
			base.Delete(identifier);
		}

		public Application Get(string identifier)
		{
			return base.Get(identifier);
		}

		public IEnumerable<Application> GetAll()
		{
			return base.GetAll();
		}

		public void Update(string identifier, Application.UpdateRequest updateRequest)
		{
			base.Update(identifier, updateRequest);
		}
	}
}
