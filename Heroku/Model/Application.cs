using System;

namespace Heroku.Model
{
	public class Application : NamedResourceBase
	{
		public string BuildpackProvidedDescription { get; set; }
		public string GitUrl { get; set; }
		public User Owner { get; set; }
		public bool Maintenance { get; set; }
		public NamedResourceReference Region { get; set; }
		public DateTime? ReleasedAt { get; set; }
		public int RepoSize { get; set; }
		public int SlugSize { get; set; }
		public string Stack { get; set; }
		public string WebUrl { get; set; }

		public class UpdateRequest : IUpdateRequest<Application>
		{
			public bool Maintenance { get; set; }
			public string Name { get; set; }
			public User Owner { get; set; }
		}

		public class CreateRequest : ICreateRequest<Application>
		{
			public string Name { get; set; }
			public NamedResourceReference Region { get; set; }
			public string Stack { get; set; }
		}
	}
}
