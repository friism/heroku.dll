using System.Net;
using Xunit;

namespace Heroku.IntegrationTests
{
	public class KeyTests : TestClass
	{
		private const string _key = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCseVc/JLiVxXCFORJHf3zZjd3QExMW4DfVUfs/ZkELgAsxtmqs2wQQasG04iVVeOceZB1y1PjWGlsvEq+UKITE3H2gjOS/i+feTNMqfTys6Luhaz832XPJauM392kCchLAC1IqJPYCDN8ZYvzmFK/2Fi3y5YyZcPqYePpeeTFYGRitFmJ6vmMn3b/I1M6g8Mz+yiDSspwAopxjX/et8GWv3sVZmSVZvtxmmSY6UO8jSm5hKf5gy36jsYLMylr96w9mHvhi6bWHq4Bo8QR9mLrwISwaJdBYumVOg+LEz8H95UQIUZaqpvo3VYK7eOUgSul1DNejneftHRX2uiu839Uv username@example.com";

		[Fact]
		public void TestKeys()
		{
			var key = _client.Keys.Create(_key);

			TestResource(key);
			Assert.Equal(_key, key.PublicKey);

			key = _client.Keys.Get(key.Id);

			TestResource(key);

			Assert.DoesNotThrow(() => _client.Keys.Delete(key.Id));

			var exception = Assert.Throws<ApiException>(() => _client.Keys.Get(key.Id));
			Assert.Equal("Key not found.", exception.Message);

			Assert.IsType<WebException>(exception.InnerException);
			var webException = exception.InnerException as WebException;
			Assert.Equal("key_not_found", exception.ApiError.Id);
		}
	}
}
