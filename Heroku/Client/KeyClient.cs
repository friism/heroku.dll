using Heroku.Model;
using System;
using System.Collections.Generic;

namespace Heroku.Client
{
	public class KeyClient : ResourceClient<Key>
	{
		private const string _path = "account/keys";

		public KeyClient(HerokuServiceClient herokuServiceClient)
			: base(herokuServiceClient, _path)
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

		public Key Get(string keyIdentifier)
		{
			return _herokuServiceClient.Get<Key>(string.Format("{0}/{1}", _path, keyIdentifier));
		}

		public IEnumerable<Key> GetAll()
		{
			return _herokuServiceClient.Get<IEnumerable<Key>>(_path);
		}
	}
}
