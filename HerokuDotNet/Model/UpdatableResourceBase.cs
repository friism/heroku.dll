using System;

namespace HerokuDotNet.Model
{
	public abstract class UpdatableResourceBase : IdentifiableResourceBase
	{
		public DateTime UpdatedAt { get; set; }
	}
}
