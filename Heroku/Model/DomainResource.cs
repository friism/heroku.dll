namespace Heroku.Model
{
	public class DomainResource : IdentifiableResourceBase
	{
		public DomainApplication App { get; set; }
		public string Base { get; set; }
		public string Domain { get; set; }

		public class DomainApplication
		{
			public string Id { get; set; }
		}

		public class CreateRequest : ICreateRequest
		{
			public string Domain { get; set; }
		}
	}
}
