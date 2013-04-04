using HerokuDotNet.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ConsoleSample
{
	public class Program
	{
		static void Main(string[] arguments)
		{
			TryServiceStack();
			return;

			var client = ClientFactory.GetHttpClient();

			var response = client.GetAsync("apps").Result;
			var applications = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);

			foreach (var app in applications)
			{
				Console.WriteLine(app.name);
			}

			Console.WriteLine("Press the any key...");
			Console.ReadKey();
		}

		private static void TryServiceStack()
		{
			var client = ClientFactory.GetServiceStackClient();
			var response = client.Get<List<Application>>("apps");
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
