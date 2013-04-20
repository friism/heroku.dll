using Heroku.Model;
using System;
using System.Collections.Generic;

namespace Heroku.Client
{
	public class AddonPlanClient : ResourceClient<AddonPlan>
	{
		public AddonPlanClient(HerokuServiceClient herokuServiceClient)
			: base(herokuServiceClient, "addon-plans")
		{
		}

		public AddonPlan Get(Guid id)
		{
			return base.Get(id);
		}

		public IEnumerable<AddonPlan> GetAll()
		{
			return base.GetAll();
		}
	}
}
