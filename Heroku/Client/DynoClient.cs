using Heroku.Model;

namespace Heroku.Client
{
	public class DynoClient : ApplicationResourceClient<Dyno>
	{
		public DynoClient()
			: base("dynos")
		{
		}
	}
}
