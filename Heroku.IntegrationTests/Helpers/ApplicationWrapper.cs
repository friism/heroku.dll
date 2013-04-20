using Heroku.Model;
using System;

namespace Heroku.IntegrationTests.Helpers
{
	public class ApplicationWrapper : IDisposable
	{
		private readonly HerokuClient _client;
		private readonly Lazy<Application> _application;

		public ApplicationWrapper(HerokuClient client)
		{
			_client = client;
			_application = new Lazy<Application>(() => _client.Applications.Create(
				new Application.CreateRequest {
					Name = "a" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 28)
				}));
		}

		public Application Application
		{
			get
			{
				return _application.Value;
			}
		}

		public void Dispose()
		{
			if (_application.IsValueCreated)
			{
				_client.Applications.Delete(_application.Value.Id);
			}
		}
	}
}
