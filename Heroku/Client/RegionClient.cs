using Heroku.Model;
using System;
using System.Collections.Generic;

namespace Heroku.Client
{
	public class RegionClient : ResourceClient<Region>
	{
		public RegionClient()
			: base("regions")
		{
		}

		public Region Get(Guid id)
		{
			return base.Get(id);
		}

		public IEnumerable<Region> GetAll()
		{
			return base.GetAll();
		}
	}
}
