using HerokuDotNet.Model;
using System.Collections.Generic;

namespace HerokuDotNet.Clients
{
	public class LogClient : ResourceClient<Log>
	{
		public LogClient(HerokuServiceClient herokuServiceClient)
			: base(herokuServiceClient, "apps/{0}/log-sessions")
		{
		}

		public Log Create(string applicationIdentifier)
		{
			return base.Create(applicationIdentifier: applicationIdentifier);
		}
	}
}
