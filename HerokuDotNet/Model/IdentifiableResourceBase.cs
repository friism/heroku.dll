using System;

namespace HerokuDotNet.Model
{
	public abstract class IdentifiableResourceBase : ResourceBase
	{
		public string Id { get; set; }
	}
}
