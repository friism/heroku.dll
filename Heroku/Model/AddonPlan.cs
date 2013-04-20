
namespace Heroku.Model
{
	public class AddonPlan : NamedResourceBase
	{
		public string Description { get; set; }
		public PlanPrice Price { get; set; }
		public string State { get; set; }

		public class PlanPrice
		{
			public int Cents { get; set; }
			public string Unit { get; set; }
		}
	}
}
