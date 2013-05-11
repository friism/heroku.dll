namespace Heroku.Model
{
	public class Collaborator : ResourceBase
	{
		public User User { get; set; }

		public class CreateRequest : ICreateRequest<Collaborator>
		{
			public User User { get; set; }
		}
	}
}
