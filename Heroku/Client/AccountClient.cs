using Heroku.Model;

namespace Heroku.Client
{
	public class AccountClient : ResourceClient<Account>
	{
		//TODO: implement update
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
