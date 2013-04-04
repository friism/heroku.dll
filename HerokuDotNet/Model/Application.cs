using System;

namespace HerokuDotNet.Model
{
	public class Application : UpdatableResourceBase
	{
		public string BuildpackProvidedDescription { get; set; }
		public string GitUrl { get; set; }
		public string Name { get; set; }
		public ApplicationOwner Owner { get; set; }
		public bool Maintenance { get; set; }
		public ApplicationRegion Region { get; set; }
		public DateTime? ReleasedAt { get; set; }
		public int RepoSize { get; set; }
		public int SlugSize { get; set; }
		public string Stack { get; set; }
		public DateTime WebUrl { get; set; }

		public class ApplicationOwner
		{
			public string Email { get; set; }
			public string Id { get; set; }
		}

		public class ApplicationRegion
		{
			public string Id { get; set; }
			public string Name { get; set; }
		}
	}
}
