using System;

namespace HerokuDotNet.Model
{
	public abstract class ResourceBase
	{
		public DateTime CreatedAt { get; set; }
		public string Id { get; set; }
	}
}
