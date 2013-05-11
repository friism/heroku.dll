namespace Heroku.Model
{
	public class Key : ResourceBase
	{
		public string Email { get; set; }
		public string FingerPrint { get; set; }
		public string PublicKey { get; set; }

		public class CreateRequest : ICreateRequest<Key>
		{
			public string PublicKey { get; set; }
		}
	}
}
