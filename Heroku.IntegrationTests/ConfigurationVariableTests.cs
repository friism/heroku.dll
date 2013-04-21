using Heroku.IntegrationTests.Helpers;
using System.Collections.Generic;
using Xunit;

namespace Heroku.IntegrationTests
{
	public class ConfigurationVariableTests : TestClass
	{
		[Fact]
		public void TestConfigurationVariables()
		{
			using (var wrapper = new ApplicationWrapper(_client))
			{
				var application = wrapper.Application;

				Assert.Empty(_client.ConfigurationVariables.GetAll(application.Id));

				_client.ConfigurationVariables.CreateOrUpdate(application.Id,
					new Dictionary<string, string>
					{
						{ "foo", "bar" },
					}
				);

				var configurationVariables = _client.ConfigurationVariables.GetAll(application.Id);
				Assert.True(configurationVariables.ContainsKey("foo"));
				Assert.Equal("bar", configurationVariables["foo"]);

				_client.ConfigurationVariables.CreateOrUpdate(application.Id,
					new Dictionary<string, string>
					{
						{"foo", "baz"},
					}
				);

				configurationVariables = _client.ConfigurationVariables.GetAll(application.Id);
				Assert.Equal("baz", configurationVariables["foo"]);
			}
		}
	}
}
