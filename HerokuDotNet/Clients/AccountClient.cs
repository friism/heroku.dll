using Heroku.Model;

namespace Heroku.Clients
{
	public class AccountClient : ResourceClient<Account>
	{
		public AccountClient(HerokuServiceClient herokuServiceClient)
			: base(herokuServiceClient)
		{
		}

		public Account Get()
		{
			return _herokuServiceClient.Get<Account>("account");
		}
	}
}
