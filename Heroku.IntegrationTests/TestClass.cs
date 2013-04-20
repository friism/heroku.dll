
namespace Heroku.IntegrationTests
{
	public class TestClass
	{
		protected readonly HerokuClient _client;

		public TestClass()
		{
			_client = new HerokuClient();
		}
	}
}
