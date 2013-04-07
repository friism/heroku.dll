using System;

namespace HerokuDotNet.Model
{
	public class Account : UpdatableResourceBase
	{
		public bool AllowTracking { get; set; }
		public bool Beta { get; set; }
		public bool Confirmed { get; set; }
		public string Email { get; set; }
		public DateTime LastLogin { get; set; }
		public bool Verified { get; set; }
	}
}
