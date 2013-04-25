using ServiceStack.ServiceClient.Web;
using System;

namespace Heroku
{
	public class ApiException : Exception
	{
		public ApiException(string message, WebServiceException innerException)
			: base(message, innerException)
		{
		}
	}
}
