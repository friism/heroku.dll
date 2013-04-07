using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace HerokuDotNet
{
	public class HerokuServiceClient : JsonServiceClient
	{
		public HerokuServiceClient()
			: base("https://api.heroku.com/")
		{
			JsConfig.PropertyConvention = JsonPropertyConvention.Lenient;
			JsConfig.EmitLowercaseUnderscoreNames = true;
			LocalHttpWebRequestFilter = request => request.UserAgent = "heroku.dll";
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
