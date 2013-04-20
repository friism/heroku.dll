using System;
using Xunit;

namespace Heroku.IntegrationTests
{
	public class AccountTests : TestClass
	{
		[Fact]
		public void CanGetAccount()
		{
			var account = _client.Account.Get();
			TestResource(account);
			Assert.NotEqual(account.LastLogin, default(DateTime));
			Assert.False(string.IsNullOrEmpty(account.Email));
		}
	}
}
