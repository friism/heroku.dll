using System.Runtime.Serialization;

namespace Heroku.Model
{
	public class ApiError
	{
		[DataMember(Name="id")]
		public string Id { get; set; }
		[DataMember(Name = "message")]
		public string Message { get; set; }
	}
}
