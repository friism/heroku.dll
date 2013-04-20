using System.Collections.Generic;

namespace Heroku.Model
{
	public class Addon : UpdatableResourceBase
	{
		public AddonPlanResource AddonPlan { get; set; }
		public IDictionary<string, string> Attachments { get; set; }

		public class AddonPlanResource
		{
			public string Name { get; set; }
		}

		public class CreateRequest : ICreateRequest<Addon>
		{
			private readonly string _name;

			public CreateRequest(string name)
			{
				_name = name;
			}

			public AddonPlanResource AddonPlan
			{
				get
				{
					return new AddonPlanResource { Name = _name };
				}
			}
			public IDictionary<string, string> Config { get; set; }
		}
	}
}
