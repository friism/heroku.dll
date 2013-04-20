using Heroku.Model;
using System;
using System.Collections.Generic;

namespace Heroku.Client
{
	// TODO: Consider implementing `Delete` convenience method
	public class ConfigurationVariableClient : ResourceClient<Account>
	{
		public ConfigurationVariableClient(HerokuServiceClient herokuServiceClient)
			: base(herokuServiceClient, "apps/{0}/config-vars")
		{
		}

		public IDictionary<string, string> GetAll(Guid applicationId)
		{
			return _herokuServiceClient.Get<IDictionary<string, string>>(
				FormatPath(applicationId));
		}

		public IDictionary<string, string> CreateOrUpdate(Guid applicationId,
			IDictionary<string, string> configVariables)
		{
			return _herokuServiceClient.Put<IDictionary<string, string>>(
				FormatPath(applicationId), configVariables);
		}
	}
}
