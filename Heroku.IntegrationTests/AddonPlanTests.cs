using Heroku.Model;
using System.Linq;
using Xunit;

namespace Heroku.IntegrationTests
{
	public class AddonPlanTests : TestClass
	{
		[Fact(Skip="Not working")]
		public void CanGetAddOnPlans()
		{
			var plans = _client.AddonPlans.GetAll();
			Assert.NotEmpty(plans);

			var firstPlan = plans.First();
			TestPlan(firstPlan);

			var plan = _client.AddonPlans.Get(firstPlan.Id);
			TestPlan(plan);
		}

		private void TestPlan(AddonPlan plan)
		{
			TestResource(plan);
			Assert.False(string.IsNullOrEmpty(plan.Description));
			Assert.False(string.IsNullOrEmpty(plan.State));

			Assert.NotNull(plan.Price);
			Assert.NotEqual(default(int), plan.Price.Cents);
			Assert.False(string.IsNullOrEmpty(plan.Price.Unit));
		}
	}
}
