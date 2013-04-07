using Heroku.Model;
using System.Collections.Generic;

namespace Heroku.Clients
{
	public class CollaboratorClient : ResourceClient<Collaborator>
	{
		public CollaboratorClient(HerokuServiceClient herokuServiceClient)
			: base(herokuServiceClient, "apps/{0}/collaborators")
		{
		}

		public Collaborator Create(string applicationIdentifier, Collaborator.CreateRequest createRequest)
		{
			return base.Create(createRequest, applicationIdentifier);
		}

		public new void Delete(string applicationIdentifier, string identifier)
		{
			base.Delete(identifier, applicationIdentifier);
		}

		public new Collaborator Get(string applicationIdentifier, string identifier)
		{
			return base.Get(identifier, applicationIdentifier);
		}

		public new IEnumerable<Collaborator> GetAll(string applicationIdentifier)
		{
			return base.GetAll(applicationIdentifier);
		}
	}
}
