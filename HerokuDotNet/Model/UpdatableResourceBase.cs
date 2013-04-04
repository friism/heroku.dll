using System;

namespace HerokuDotNet.Model
{
	public abstract class UpdatableResourceBase : ResourceBase
	{
		public DateTime UpdatedAt { get; set; }
	}
}
