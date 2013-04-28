using System.Net;
using System.Reflection;

namespace Heroku
{
	public static class HttpWebRequestHelper
	{
		static MethodInfo httpWebRequestAddRangeHelper =
			typeof(WebHeaderCollection).GetMethod ("AddWithoutValidate", BindingFlags.Instance | BindingFlags.NonPublic);

		public static void AddRange(this HttpWebRequest request, string value)
		{
			httpWebRequestAddRangeHelper.Invoke(request.Headers, new object[] { "Range", value });
		}
	}
}
