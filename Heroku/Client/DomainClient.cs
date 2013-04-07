using Heroku.Model;
using System.Collections.Generic;

namespace Heroku.Client
{
	public class DomainClient : ResourceClient<DomainResource>
	{
		public DomainClient(HerokuServiceClient herokuServiceClient)
			: base(herokuServiceClient, "apps/{0}/domains")
		{
		}

		public DomainResource Create(string applicationIdentifier, string domain)
		{
			return base.Create(new DomainResource.CreateRequest { Domain = domain } , applicationIdentifier);
		}

		public new void Delete(string applicationIdentifier, string identifier)
		{
			base.Delete(identifier, applicationIdentifier);
		}

		public new DomainResource Get(string applicationIdentifier, string identifier)
		{
			return base.Get(identifier, applicationIdentifier);
		}

		public new IEnumerable<DomainResource> GetAll(string applicationIdentifier)
		{
			return base.GetAll(applicationIdentifier);
		}
	}
}
