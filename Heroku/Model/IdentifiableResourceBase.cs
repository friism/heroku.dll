using System;

namespace Heroku.Model
{
	public abstract class IdentifiableResourceBase : ResourceBase
	{
		public Guid Id { get; set; }
	}
}
