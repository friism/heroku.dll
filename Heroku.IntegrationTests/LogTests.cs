using Heroku.IntegrationTests.Helpers;
using Xunit;

namespace Heroku.IntegrationTests
{
	public class LogTests : TestClass
	{
		[Fact(Skip="Requires wait before log is available, could be solved with hack")]
		public void TestLogs()
		{
			using (var wrapper = new ApplicationWrapper(_client))
			{
				var application = wrapper.Application;

				var logSession = _client.LogSessions.Create(application.Id);

				TestResource(logSession);
				Assert.False(string.IsNullOrEmpty(logSession.LogplexUrl));
			}
		}
	}
}
