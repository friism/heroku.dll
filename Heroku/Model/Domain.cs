
namespace Heroku.Model
{
	public class Domain : ResourceBase
	{
		public string Hostname { get; set; }

		public class CreateRequest : ICreateRequest<Domain>
		{
			public string Hostname { get; set; }
		}
	}
}
