using System;

namespace Heroku.Model
{
	public abstract class UpdatableResourceBase : IdentifiableResourceBase
	{
		public DateTime UpdatedAt { get; set; }
	}
}
