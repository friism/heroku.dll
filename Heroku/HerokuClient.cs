using Heroku.Client;

namespace Heroku
{
	// TODO: have a way to initialize with application context
	public class HerokuClient
	{
		public AccountClient Account
		{
			get { return new AccountClient(); }
		}

		public AddonPlanClient AddonPlans
		{
			get { return new AddonPlanClient(); }
		}

		public AddonClient Addons
		{
			get { return new AddonClient(); }
		}

		public ApplicationClient Applications
		{
			get { return new ApplicationClient(); }
		}

		public CollaboratorClient Collaborators
		{
			get { return new CollaboratorClient(); }
		}

		public ConfigurationVariableClient ConfigurationVariables
		{
			get { return new ConfigurationVariableClient(); }
		}

		public DomainClient Domains
		{
			get { return new DomainClient(); }
		}

		public DynoClient Dynos
		{
			get { return new DynoClient(); }
		}

		public FormationClient Formation
		{
			get { return new FormationClient(); }
		}

		public KeyClient Keys
		{
			get { return new KeyClient(); }
		}

		public LogSessionClient Logs
		{
			get { return new LogSessionClient(); }
		}

		public RegionClient Regions
		{
			get { return new RegionClient(); }
		}

		public ReleaseClient Releases
		{
			get { return new ReleaseClient(); }
		}
	}
}
