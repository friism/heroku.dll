using Heroku.Model;
using System;
using System.Net;

namespace Heroku
{
	public class ApiException : Exception
	{
		private readonly ApiError _apiError;

		public ApiException(ApiError apiError, WebException innerException)
			: base(apiError.Message, innerException)
		{
			_apiError = apiError;
		}

		public ApiError ApiError { get { return _apiError; } }
	}
}
