using System;
using System.IO;
using System.Net;

namespace Heroku.Client
{
	// NOTE: Added because helper method is not yet in NuGet ServiceStack.Text
	public static class ExceptionHelper
	{
		public static string GetResponseBody(this Exception ex)
		{
			var webEx = ex as WebException;
			if (webEx == null || webEx.Status != WebExceptionStatus.ProtocolError) return null;

			var errorResponse = ((HttpWebResponse)webEx.Response);
			using (var reader = new StreamReader(errorResponse.GetResponseStream()))
			{
				return reader.ReadToEnd();
			}
		}
	}
}
