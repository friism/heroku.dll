
namespace Heroku.Model
{
	public class DomainResource : IdentifiableResourceBase
	{
		public string Base { get; set; }
		public string Domain { get; set; }

		public class CreateRequest : ICreateRequest<DomainResource>
		{
			public string Domain { get; set; }
		}
	}
}
