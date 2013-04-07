using Heroku.Model;
using System.Collections.Generic;

namespace Heroku.Client
{
	public class DynoClient : ResourceClient<Dyno>
	{
		public DynoClient(HerokuServiceClient herokuServiceClient)
			: base(herokuServiceClient, "apps/{0}/dynos")
		{
		}

		public Dyno Create(string applicationIdentifier, Dyno.CreateRequest createRequest)
		{
			return base.Create(createRequest, applicationIdentifier);
		}

		public new void Delete(string applicationIdentifier, string identifier)
		{
			base.Delete(identifier, applicationIdentifier);
		}

		public new Dyno Get(string applicationIdentifier, string identifier)
		{
			return base.Get(identifier, applicationIdentifier);
		}

		public new IEnumerable<Dyno> GetAll(string applicationIdentifier)
		{
			return base.GetAll(applicationIdentifier);
		}
	}
}
