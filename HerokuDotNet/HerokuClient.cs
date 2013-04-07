using HerokuDotNet.Clients;

namespace HerokuDotNet
{
	public class HerokuClient
	{
		private HerokuServiceClient _client;

		// TODO: have a way to initialize with application context
		public HerokuClient()
		{
			_client = ClientHelper.GetClient();
		}

		public AccountClient Account
		{
			get { return new AccountClient(_client); }
		}

		public ApplicationClient Applications
		{
			get { return new ApplicationClient(_client); }
		}

		public CollaboratorClient Collaborators
		{
			get { return new CollaboratorClient(_client); }
		}

		public ConfigurationVariableClient ConfigurationVariables
		{
			get { return new ConfigurationVariableClient(_client); }
		}

		public DomainClient Domains
		{
			get { return new DomainClient(_client); }
		}

		public DynoClient Dynos
		{
			get { return new DynoClient(_client); }
		}

		public FormationClient Formation
		{
			get { return new FormationClient(_client); }
		}

		public KeyClient Keys
		{
			get { return new KeyClient(_client); }
		}

		public LogClient Logs
		{
			get { return new LogClient(_client); }
		}
	}
}
