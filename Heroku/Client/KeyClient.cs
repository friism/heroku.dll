using Heroku.Model;
using System;
using System.Collections.Generic;

namespace Heroku.Client
{
	public class KeyClient : ResourceClient<Key>
	{
		private const string _path = "account/keys";

		public KeyClient()
			: base(_path)
		{
		}

		public Key Create(string publicKey)
		{
			return base.Create(new Key.CreateRequest { PublicKey = publicKey });
		}

		public void Delete(Guid keyId)
		{
			base.Delete(keyId);
		}

		public Key Get(Guid id)
		{
			return Get<Key>(string.Format("{0}/{1}", _path, id));
		}

		public IEnumerable<Key> GetAll()
		{
			return Get<IEnumerable<Key>>(_path);
		}
	}
}
