using System;

namespace HerokuDotNet.Model
{
	public class Application
		: UpdatableResourceBase
	{
		public string BuildpackProvidedDescription { get; set; }
		public string GitUrl { get; set; }
		public string Name { get; set; }
		public User Owner { get; set; }
		public bool Maintenance { get; set; }
		public NamedResourceReference Region { get; set; }
		public DateTime? ReleasedAt { get; set; }
		public int RepoSize { get; set; }
		public int SlugSize { get; set; }
		public string Stack { get; set; }
		public DateTime WebUrl { get; set; }

		public class UpdateRequest : IUpdateRequest
		{
			public bool Maintenance { get; set; }
			public string Name { get; set; }
			public User Owner { get; set; }
		}

		public class CreateRequest : ICreateRequest
		{
			public string Name { get; set; }
			public NamedResourceReference Region { get; set; }
			public string Stack { get; set; }
		}
	}
}
