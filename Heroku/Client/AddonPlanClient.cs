﻿using Heroku.Model;

namespace Heroku.Client
{
	public class AddonClient :ApplicationResourceClient<Addon>
	{
		public AddonClient()
			: base("addons")
		{
		}
	}
}
