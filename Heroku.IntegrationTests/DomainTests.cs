using Heroku.IntegrationTests.Helpers;
using Heroku.Model;
using Xunit;

namespace Heroku.IntegrationTests
{
	public class DomainTests : TestClass
	{
		private const string _baseDomain = "example.com";
		private readonly string _domainName = string.Format("foo.{0}", _baseDomain);

		[Fact]
		public void TestDomains()
		{
			using (var wrapper = new ApplicationWrapper(_client))
			{
				var application = wrapper.Application;

				var domain = _client.Domains.Create(application.Id, new DomainResource.CreateRequest
				{
					Domain = _domainName,
				});

				TestResource(domain);

				Assert.Equal(_domainName, domain.Domain);
				Assert.Equal(_baseDomain, domain.Base);

				Assert.NotEmpty(_client.Domains.GetAll(application.Id));

				Assert.DoesNotThrow(() => _client.Domains.Delete(application.Id, domain.Id));
			}
		}
	}
}
