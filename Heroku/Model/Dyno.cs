namespace Heroku.Model
{
	public class Dyno : UpdatableResourceBase
	{
		public string AttachUrl { get; set; }
		public string Command { get; set; }
		public string Name { get; set; }
		public NamedResourceReference Release { get; set; }
		public int Size { get; set; }
		public string State { get; set; }
		public string Type { get; set; }

		public class CreateRequest : ICreateRequest
		{
			public string Command { get; set; }
			public bool Attach { get; set; }
			public int Size { get; set; }
		}
	}
}
