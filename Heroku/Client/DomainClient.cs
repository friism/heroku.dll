using Heroku.Model;

namespace Heroku.Client
{
	public class DomainClient : ApplicationResourceClient<DomainResource>
	{
		public DomainClient(HerokuServiceClient herokuServiceClient)
			: base(herokuServiceClient, "apps/{0}/domains")
		{
		}
	}
}
