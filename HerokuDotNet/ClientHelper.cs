using HerokuDotNet.OAuth;
using System;
using System.Configuration;
using System.Text;

namespace HerokuDotNet
{
	public static class ClientHelper
	{
		public static HerokuServiceClient GetClient()
		{
			var client = new HerokuServiceClient();
			client.Headers.Add("Authorization", GetAuthorizationHeaderValue());

			return client;
		}

		private static string GetAuthorizationHeaderValue()
		{
			var clientId = ConfigurationManager.AppSettings["ClientId"];
			var clientSecret = ConfigurationManager.AppSettings["ClientSecret"];

			if (!string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(clientSecret))
			{
				var authInfo = GetOauthAuthorization(clientId, clientSecret);
				return string.Format("Bearer {0}", authInfo.AccessToken);
			}

			var apiKey = ConfigurationManager.AppSettings["ApiKey"];
			if (!string.IsNullOrEmpty(apiKey))
			{
				return string.Format("Basic {0}", EncodeApiKey(apiKey));
			}

			throw new ArgumentException("Neither `ApiKey` or OAuth client settings found in config");
		}

		private static string EncodeApiKey(string apiKey)
		{
			return Convert.ToBase64String(
				Encoding.ASCII.GetBytes(
					string.Format(":{0}", apiKey)));
		}

		private static AuthInfo GetOauthAuthorization(string clientId, string clientSecret)
		{
			try
			{
				return OAuthHelper.AskForAuthorization(clientId, clientSecret, TimeSpan.FromMinutes(1));
			}
			catch (System.Security.Authentication.AuthenticationException)
			{
				Console.WriteLine("Failed to get authorization");
				Environment.Exit(-1);
				throw;
			}
			catch (TimeoutException)
			{
				Console.WriteLine("Timeout, you have to be faster than that");
				Environment.Exit(-1);
				throw;
			}
		}
	}
}
