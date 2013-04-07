using HerokuDotNet;
using System;

namespace ConsoleSample
{
	public class Program
	{
		static void Main(string[] arguments)
		{
			var client = new HerokuClient();
			var apps = client.Applications.GetAll();

			foreach (var app in apps)
			{
				Console.WriteLine(app.Name);
			}

			Console.ReadKey();
		}
	}
}
