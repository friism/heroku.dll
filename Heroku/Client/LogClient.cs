using Heroku.Model;
using System;

namespace Heroku.Client
{
	public class LogClient : ResourceClient<Log>
	{
		public LogClient(HerokuServiceClient herokuServiceClient)
			: base(herokuServiceClient, "apps/{0}/log-sessions")
		{
		}

		public Log Create(Guid applicationId)
		{
			return base.Create(applicationId: applicationId);
		}
	}
}
