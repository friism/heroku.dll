using System;

namespace Heroku.Model
{
	public abstract class IdentifiableResourceBase : ResourceBase
	{
		public string Id { get; set; }
	}
}
