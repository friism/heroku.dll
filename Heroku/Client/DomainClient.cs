using Heroku.Model;

namespace Heroku.Client
{
	public class DomainClient : ApplicationResourceClient<Domain>
	{
		public DomainClient()
			: base("domains")
		{
		}
	}
}
