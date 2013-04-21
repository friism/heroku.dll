using Heroku.IntegrationTests.Helpers;
using System;
using System.Linq;
using Xunit;

namespace Heroku.IntegrationTests
{
	public class ReleaseTests : TestClass
	{
		[Fact]
		public void TestReleases()
		{
			using (var wrapper = new ApplicationWrapper(_client))
			{
				var application = wrapper.Application;

				var initialReleases = _client.Releases.GetAll(application.Id);
				Assert.NotEmpty(initialReleases);

				var release = _client.Releases.Get(application.Id, initialReleases.First().Id);
				TestResource(release);
				Assert.False(string.IsNullOrEmpty(release.Description));
				Assert.False(string.IsNullOrEmpty(release.Name));
				Assert.NotNull(release.User);
				Assert.False(string.IsNullOrEmpty(release.User.Email));
				Assert.NotEqual(default(Guid), release.User.Id);
			}
		}
	}
}
