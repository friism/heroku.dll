using Heroku.Model;
using System.Collections.Generic;

namespace Heroku.Clients
{
	// TODO: Consider implementing `Delete` convenience method
	public class ConfigurationVariableClient : ResourceClient<Account>
	{
		public ConfigurationVariableClient(HerokuServiceClient herokuServiceClient)
			: base(herokuServiceClient, "apps/{0}/config-vars")
		{
		}

		public new IDictionary<string, string> GetAll(string applicationIdentifier)
		{
			return _herokuServiceClient.Get<IDictionary<string, string>>(
				FormatPath(applicationIdentifier));
		}

		public IDictionary<string, string> CreateOrUpdate(string applicationIdentifier,
			IDictionary<string, string> configVariables)
		{
			return _herokuServiceClient.Put<IDictionary<string, string>>(
				FormatPath(applicationIdentifier), configVariables);
		}
	}
}
