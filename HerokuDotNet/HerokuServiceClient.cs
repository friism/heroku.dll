using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;

namespace Heroku
{
	public class HerokuServiceClient : JsonServiceClient
	{
		private static readonly string _userAgent;

		static HerokuServiceClient()
		{
			_userAgent = string.Format("heroku.dll {0}",
				typeof(HerokuServiceClient).Assembly.GetName().Version);
		}

		public HerokuServiceClient()
			: base("https://api.heroku.com/")
		{
			JsConfig.PropertyConvention = JsonPropertyConvention.Lenient;
			JsConfig.EmitLowercaseUnderscoreNames = true;
			LocalHttpWebRequestFilter = request => request.UserAgent = _userAgent;
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
