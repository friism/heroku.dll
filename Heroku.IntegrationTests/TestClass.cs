using Heroku.Model;
using System;
using Xunit;

namespace Heroku.IntegrationTests
{
	public class TestClass
	{
		protected readonly HerokuClient _client;

		public TestClass()
		{
			_client = new HerokuClient();
		}

		protected void TestResource(ResourceBase @object)
		{
			Assert.NotEqual(default(DateTime), @object.CreatedAt);
			Assert.NotEqual(default(Guid), @object.Id);
			Assert.NotEqual(default(DateTime), @object.UpdatedAt);
		}

		protected void TestResource(NamedResourceBase @object)
		{
			TestResource((ResourceBase)@object);
			Assert.False(string.IsNullOrEmpty(@object.Name));
		}
	}
}
