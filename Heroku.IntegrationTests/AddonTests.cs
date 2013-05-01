using Heroku.IntegrationTests.Helpers;
using Heroku.Model;
using Xunit;

namespace Heroku.IntegrationTests
{
	public class AddonTests : TestClass
	{
		private const string _planName = "heroku-postgresql:dev";

		[Fact]
		public void TestAddons()
		{
			using (var wrapper = new ApplicationWrapper(_client))
			{
				var application = wrapper.Application;

				var addon = _client.Addons.Create(application.Id, new Addon.CreateRequest(_planName));

				TestResource(addon);

				_client.Addons.Delete(application.Id, addon.Id);

				Assert.Throws(typeof(ApiException),
					() => _client.Addons.Get(application.Id, addon.Id));
			}
		}
	}
}
