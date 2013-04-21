using Heroku.IntegrationTests.Helpers;
using Xunit;

namespace Heroku.IntegrationTests
{
	public class FormationTests : TestClass
	{
		[Fact]
		public void TestFormation()
		{
			using (var wrapper = new ApplicationWrapper(_client))
			{
				var application = wrapper.Application;

				var formation = _client.Formation.GetAll(application.Id);
				Assert.Empty(formation);
			}
		}
	}
}
