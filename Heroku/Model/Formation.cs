namespace Heroku.Model
{
	public class Formation : ResourceBase
	{
		public string Command { get; set; }
		public int Quantity { get; set; }
		public int Size { get; set; }
		public string Type { get; set; }

		public class UpdateRequest : IUpdateRequest<Formation>
		{
			public int Quantity { get; set; }
		}
	}
}
