using System;

namespace masmec.ate.utils
{
	public interface ICryptographer
	{
		string Encrypt(string value);

		string Decrypt(string value);

		string EncryptionKey{ get; set; }

	}
}

