using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace HerokuDotNet
{
	public class HerokuServiceClient : JsonServiceClient
	{
		public HerokuServiceClient(string baseUri)
			: base(baseUri)
		{
			JsConfig.PropertyConvention = JsonPropertyConvention.Lenient;
		}

		public override string Accept
		{
			get
			{
				return "application/vnd.heroku+json; version=3";
			}
		}
	}
}
