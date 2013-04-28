using Heroku.Model;
using System;

namespace Heroku.Client
{
	public class LogClient : ResourceClient<Log>
	{
		public LogClient()
			: base("apps/{0}/log-sessions")
		{
		}

		public Log Create(Guid applicationId)
		{
			return base.Create(applicationId: applicationId);
		}
	}
}
