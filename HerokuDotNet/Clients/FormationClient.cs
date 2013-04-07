using HerokuDotNet.Model;
using System.Collections.Generic;

namespace HerokuDotNet.Clients
{
	public class FormationClient : ResourceClient<Formation>
	{
		private const string _pathFormat = "apps/{0}/formation";

		public FormationClient(HerokuServiceClient herokuServiceClient)
			: base(herokuServiceClient, _pathFormat)
		{
		}
		public new IEnumerable<Formation> GetAll(string applicationIdentifier)
		{
			return base.GetAll(applicationIdentifier);
		}

		public void Update(string applicationIdentifier, string processType, Formation.UpdateRequest updateRequest)
		{
			_herokuServiceClient.Put<IEnumerable<Formation>>(
				string.Format("{0}/{1}", FormatPath(applicationIdentifier), processType), updateRequest);
		}
	}
}
