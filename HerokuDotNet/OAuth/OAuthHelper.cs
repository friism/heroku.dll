using RestSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Authentication;

namespace Heroku.OAuth
{
	// REMARK: This code is taken from the AppHarbor SDK, https://github.com/appharbor/AppHarbor.NET/blob/master/AppHarbor.Sdk/AppHarborClient.Auth.cs
	public class OAuthHelper
	{
		private const string BaseUrl = "https://id.heroku.com/";

		public static AuthInfo GetAuthInfo(string clientId, string clientSecret, string code)
		{
			// make POST request to obtain the token
			var client = new RestClient(BaseUrl);
			client.AddHandler("application/json", new DynamicJsonDeserializer());
			var request = new RestRequest(Method.POST);
			request.Resource = "oauth/token";
			request.AddParameter("client_id", clientId);
			request.AddParameter("client_secret", clientSecret);
			request.AddParameter("code", code);

			var response = client.Execute<dynamic>(request);
			if (response.StatusCode != HttpStatusCode.OK)
			{
				return null;
			}

			return new AuthInfo(response.Data.access_token.ToString(), response.Data.token_type.ToString());
		}

		/// <summary>
		/// This will open a browser on the user's machine and asks for authorization of the client, if the user
		/// accepts then he is redirected back to localhost with the authorization code.
		/// </summary>
		/// <remarks>
		/// This command will start a webserver on localhost to listen for the authorization code. The webserver is
		/// listining on the following url: <code>http://+:80/Temporary_Listen_Addresses/</code>
		/// </remarks>
		/// <param name="clientId">The client ID</param>
		/// <param name="clientSecret">The client secret</param>
		/// <param name="timeout">Timeout, if the user has not authorized your application within the given timeout then a
		/// <see cref="TimeoutException"/> is thrown and the operation is cancelled.</param>
		/// <returns>If the operation is successful a valid <see cref="AuthInfo"/> is returned.</returns>
		public static AuthInfo AskForAuthorization(string clientId, string clientSecret, TimeSpan timeout)
		{
			string code = GetCodeFromLocalHost(clientId, timeout);
			return GetAuthInfo(clientId, clientSecret, code);
		}

		private static string GetAuthorizationUrl(string clientId, string redirectUrl)
		{
			return string.Format("{0}oauth/authorize?client_id={1}&response_type=code", BaseUrl, clientId);
		}

		private static string GetCodeFromLocalHost(string clientId, TimeSpan timeout)
		{
			const string httpTemporaryListenAddresses = "http://+:80/Temporary_Listen_Addresses/";
			const string redirectUrl = "http://localhost:80/Temporary_Listen_Addresses/";

			string code;
			using (var listener = new HttpListener())
			{
				string localHostUrl = string.Format(httpTemporaryListenAddresses);

				listener.Prefixes.Add(localHostUrl);
				listener.Start();

				using (Process.Start(GetAuthorizationUrl(clientId, redirectUrl)))
				{
					while (true)
					{
						var start = DateTime.Now;
						var context = listener.GetContext();
						var usedTime = DateTime.Now.Subtract(start);
						timeout = timeout.Subtract(usedTime);

						if (context.Request.Url.AbsolutePath == "/Temporary_Listen_Addresses/")
						{
							code = context.Request.QueryString["code"];
							if (code == null)
							{
								throw new AuthenticationException("Access denied, no return code was returned");
							}

							var writer = new StreamWriter(context.Response.OutputStream);
							writer.WriteLine(CloseWindowResponse);
							writer.Flush();

							context.Response.Close();
							break;
						}

						context.Response.StatusCode = 404;
						context.Response.Close();
					}
				}
			}
			return code;
		}

		private const string CloseWindowResponse = "<!DOCTYPE html><html><head></head><body onload=\"closeThis();\"><h1>Authorization Successfull</h1><p>You can now close this window</p><script type=\"text/javascript\">function closeMe() { window.close(); } function closeThis() { window.close(); }</script></body></html>";
	}
}
