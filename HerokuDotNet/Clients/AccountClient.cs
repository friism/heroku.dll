using HerokuDotNet.Model;

namespace HerokuDotNet.Clients
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
