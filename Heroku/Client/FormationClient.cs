using Heroku.Model;
using System;
using System.Collections.Generic;

namespace Heroku.Client
{
	public class FormationClient : ResourceClient<Formation>
	{
		private const string _pathFormat = "apps/{0}/formation";

		public FormationClient()
			: base(_pathFormat)
		{
		}
		public IEnumerable<Formation> GetAll(Guid applicationId)
		{
			return base.GetAll(applicationId);
		}

		public void Update(Guid applicationId, string processType, Formation.UpdateRequest updateRequest)
		{
			Patch<IEnumerable<Formation>>(
				string.Format("{0}/{1}", FormatPath(applicationId), processType), updateRequest);
		}
	}
}
