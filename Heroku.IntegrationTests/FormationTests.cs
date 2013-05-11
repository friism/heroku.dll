using System.Linq;
using Heroku.IntegrationTests.Helpers;
using Xunit;

namespace Heroku.IntegrationTests
{
	public class FormationTests : TestClass
	{
		[Fact]
		public void TestFormationOnNewApp()
		{
			using (var wrapper = new ApplicationWrapper(_client))
			{
				var application = wrapper.Application;

				var formation = _client.Formation.GetAll(application.Id);
				Assert.Empty(formation);
			}
		}

		[Fact]
		public void TestFormationOnDeployedApp()
		{
			var application = _client.Applications.GetAll()
				.Single(x => x.Name == "test-slow-uploading");

			var formations = _client.Formation.GetAll(application.Id);
			Assert.NotEmpty(formations);
			var formation = formations.ElementAt(1);
			Assert.False(string.IsNullOrEmpty(formation.Type));
			Assert.False(string.IsNullOrEmpty(formation.Command));
			Assert.NotEqual(default(int), formation.Quantity);
			Assert.NotEqual(default(int), formation.Size);
		}
	}
}
