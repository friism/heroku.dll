using Heroku.IntegrationTests.Helpers;
using Heroku.Model;
using System;
using Xunit;

namespace Heroku.IntegrationTests
{
	public class DynoTests : TestClass
	{
		private const string _command = "ls";

		[Fact]
		public void TestDynos()
		{
			using (var wrapper = new ApplicationWrapper(_client))
			{
				var application = wrapper.Application;

				var dynos = _client.Dynos.GetAll(application.Id);
				Assert.Empty(dynos);

				var dyno = _client.Dynos.Create(application.Id, new Dyno.CreateRequest
					{
						Command = _command,
						Size = 1,
					});

				TestResource(dyno);
				Assert.Equal("starting", dyno.State);
				Assert.Equal(_command, dyno.Command);
				Assert.False(string.IsNullOrEmpty(dyno.Name));
				Assert.NotNull(dyno.Release);
				Assert.NotEqual(default(Guid), dyno.Release.Id);
				Assert.Equal("run", dyno.Type);
			}
		}
	}
}
