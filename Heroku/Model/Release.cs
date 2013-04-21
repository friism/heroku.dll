
namespace Heroku.Model
{
	public class Release : IdentifiableResourceBase
	{
		public string Description { get; set; }
		public string Name { get; set; }
		public User User { get; set; }
	}
}
