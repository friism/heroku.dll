using System;

namespace Heroku.Model
{
	public abstract class ResourceBase
	{
		public DateTime CreatedAt { get; set; }
		public Guid Id { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
