using Heroku.Model;
using System;

namespace Heroku.Client
{
	public class LogSessionClient : ResourceClient<LogSession>
	{
		public LogSessionClient()
			: base("apps/{0}/log-sessions")
		{
		}

		public LogSession Create(Guid applicationId)
		{
			return base.Create(applicationId: applicationId);
		}
	}
}
