using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Authentication;
using System.Text;

namespace ConsoleSample
{
	public class Program
	{
		static void Main(string[] arguments)
		{
			var client = GetClient();

			var response = client.GetAsync("apps").Result;
			var applications = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);

			foreach (var app in applications)
			{
				Console.WriteLine(app.name);
			}

			Console.WriteLine("Press the any key...");
			Console.ReadKey();
		}

		private static HttpClient GetClient()
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
				var authorization = Convert.ToBase64String(
					Encoding.ASCII.GetBytes(
						string.Format(":{0}", apiKey)));
				client.DefaultRequestHeaders.Authorization =
					new AuthenticationHeaderValue("Basic", authorization);
				return;
			}

			Console.WriteLine("Neither `ApiKey` or OAuth client settings found in config, press any key to exit...");
			Console.ReadKey();
			Environment.Exit(1);
		}

		private static AuthInfo GetOauthAuthorization(string clientId, string clientSecret)
		{
			try
			{
				return OAuth.AskForAuthorization(clientId, clientSecret, TimeSpan.FromMinutes(1));
			}
			catch (AuthenticationException)
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

		private static string ExecutableName
		{
			get
			{
				return Path.GetFileName(Assembly.GetEntryAssembly().Location);
			}
		}
	}
}
