using Heroku.Model;

namespace Heroku.Client
{
	//TODO: implement update
	public class AccountClient : ResourceClient<Account>
	{
		public Account Get()
		{
			return Get<Account>("account");
		}
	}
}
