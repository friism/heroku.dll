using Heroku.IntegrationTests.Helpers;
using Heroku.Model;
using System;
using System.Linq;
using Xunit;

namespace Heroku.IntegrationTests
{
	public class RangeTests : TestClass
	{
		[Fact(Skip="Takes a long time")]
		public void TestRange()
		{
			using (var wrapper = new ApplicationWrapper(_client))
			{
				var application = wrapper.Application;

				var count = 201;

				Enumerable.Range(0, count)
					.AsParallel()
					.ForAll(x =>
					_client.Domains.Create(application.Id,
					new DomainResource.CreateRequest
					{
						Domain = string.Format("{0}.com", Guid.NewGuid()),
					}));

				var domains = _client.Domains.GetAll(application.Id).ToList();
				Assert.Equal(count + 1, domains.Count());
				var distinctIds = domains.Select(x => x.Id).Distinct();
				Assert.Equal(count + 1, distinctIds.Count());
			}
		}
	}
}
