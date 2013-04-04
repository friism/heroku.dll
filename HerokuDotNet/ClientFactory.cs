using ServiceStack.ServiceClient.Web;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace HerokuDotNet
{
	public static class ClientFactory
	{
		public static HttpClient GetHttpClient()
		{
			var client = new HttpClient(new HttpClientHandler
			{
				AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
			});

			client.BaseAddress = new Uri("https://api.heroku.com/");

			// this dials us into v3. Both OAuth and ApiKey works with v2
			client.DefaultRequestHeaders.Add("Accept", "application/vnd.heroku+json; version=3");

			AuthorizeClient(client);

			return client;
		}

		public static ServiceClientBase GetServiceStackClient()
		{
			var client = new HerokuServiceClient("https://api.heroku.com/");
			client.Headers.Add("Authorization",
				string.Format("Basic {0}", EncodeApiKey(
					ConfigurationManager.AppSettings["ApiKey"])));

			return client;
		}

		private static void AuthorizeClient(HttpClient client)
		{
			var clientId = ConfigurationManager.AppSettings["ClientId"];
			var clientSecret = ConfigurationManager.AppSettings["ClientSecret"];

			if (!string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(clientSecret))
			{
				var authInfo = GetOauthAuthorization(clientId, clientSecret);
				client.DefaultRequestHeaders.Authorization =
					new AuthenticationHeaderValue("Bearer", authInfo.AccessToken);
				return;
			}

			var apiKey = ConfigurationManager.AppSettings["ApiKey"];
			if (!string.IsNullOrEmpty(apiKey))
			{
				client.DefaultRequestHeaders.Authorization =
					new AuthenticationHeaderValue("Basic", EncodeApiKey(apiKey));
				return;
			}

			Console.WriteLine("Neither `ApiKey` or OAuth client settings found in config, press any key to exit...");
			Console.ReadKey();
			Environment.Exit(1);
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
				return OAuth.AskForAuthorization(clientId, clientSecret, TimeSpan.FromMinutes(1));
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
