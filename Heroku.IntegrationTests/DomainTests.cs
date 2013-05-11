using Heroku.IntegrationTests.Helpers;
using Heroku.Model;
using Xunit;

namespace Heroku.IntegrationTests
{
	public class DomainTests : TestClass
	{
		private const string _domainName = "foo.example.com";

		[Fact(Skip="Currently broken")]
		public void TestDomains()
		{
			using (var wrapper = new ApplicationWrapper(_client))
			{
				var application = wrapper.Application;

				var domain = _client.Domains.Create(application.Id, new Domain.CreateRequest
				{
					Hostname = _domainName,
				});

				TestResource(domain);

				Assert.Equal(_domainName, domain.Hostname);

				Assert.NotEmpty(_client.Domains.GetAll(application.Id));

				Assert.DoesNotThrow(() => _client.Domains.Delete(application.Id, domain.Id));
			}
		}
	}
}
