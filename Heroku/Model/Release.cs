
namespace Heroku.Model
{
	public class Release : ResourceBase
	{
		public string Description { get; set; }
		public int Version { get; set; }
		public User User { get; set; }
	}
}
