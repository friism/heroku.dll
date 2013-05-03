using Heroku.Model;
using System.Linq;
using Xunit;

namespace Heroku.IntegrationTests
{
	public class RegionTests : TestClass
	{
		[Fact]
		public void CanGetRegions()
		{
			var regions = _client.Regions.GetAll();
			Assert.NotEmpty(regions);

			var firstRegion = regions.First();
			TestRegion(firstRegion);

			var region = _client.Regions.Get(firstRegion.Id);
			TestRegion(region);
		}

		private void TestRegion(Region region)
		{
			TestResource(region);
			Assert.False(string.IsNullOrEmpty(region.Name));
			Assert.False(string.IsNullOrEmpty(region.Description));
		}
	}
}
