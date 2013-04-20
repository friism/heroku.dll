using Heroku.Model;

namespace Heroku.Client
{
	public class CollaboratorClient : ApplicationResourceClient<Collaborator>
	{
		public CollaboratorClient(HerokuServiceClient herokuServiceClient)
			: base(herokuServiceClient, "collaborators")
		{
		}
	}
}
