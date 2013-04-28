using Heroku.Model;
using System;
using Xunit;

namespace Heroku.IntegrationTests
{
	public class ApplicationTests : TestClass
	{
		[Fact]
		public void TestApplications()
		{
			var applicationName = GetValidApplicationName();

			var createdApplication = _client.Applications.Create(
				new Application.CreateRequest {
					Name = applicationName
			});

			Assert.Equal(applicationName, createdApplication.Name);

			var applications = _client.Applications.GetAll();
			Assert.NotEmpty(applications);

			var applicationFetchedById = _client.Applications.Get(createdApplication.Id);
			TestResource(applicationFetchedById);

			Assert.False(string.IsNullOrEmpty(applicationFetchedById.GitUrl));

			Assert.NotNull(applicationFetchedById.Owner);
			Assert.NotEqual(default(Guid), applicationFetchedById.Owner.Id);
			Assert.False(string.IsNullOrEmpty(applicationFetchedById.Owner.Email));

			Assert.NotNull(applicationFetchedById.Region);
			Assert.NotEqual(default(Guid), applicationFetchedById.Region.Id);
			Assert.False(string.IsNullOrEmpty(applicationFetchedById.Region.Name));

			Assert.False(string.IsNullOrEmpty(applicationFetchedById.Stack));
			Assert.False(string.IsNullOrEmpty(applicationFetchedById.WebUrl));

			var newApplicationName = GetValidApplicationName();
			_client.Applications.Update(createdApplication.Id,
				new Application.UpdateRequest { Name = newApplicationName });

			applicationFetchedById = _client.Applications.Get(createdApplication.Id);
			Assert.Equal(newApplicationName, applicationFetchedById.Name);

			_client.Applications.Delete(createdApplication.Id);

			var exception = Assert.Throws(typeof(ApiException), () => _client.Applications.Get(createdApplication.Id));
			Assert.Equal("App not found.", exception.Message);
		}

		public static string GetValidApplicationName()
		{
			return "a" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 28);
		}
	}
}
