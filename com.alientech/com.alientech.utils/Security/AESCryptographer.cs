
// <copyright file="AESCryptographer.cs" company="AlienTech">
// Copyright (c) 2011, 2111 All Right Reserved
//
// This source is subject to the maurizio.attanasi Permissive License.
// All other rights reserved.
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY 
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// </copyright>
// <author>maurizio.attanasi</author>
// <email>maurizio.attanasi@gmail.com</email>
// <date>2/10/2014</date>
// <summary></summary>

using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace masmec.ate.utils
{
	public class AESCryptographer : IDisposable, ICryptographer
	{
		public AESCryptographer (string encryptionKey)
		{
			this.EncryptionKey = encryptionKey;
		}

		#region IDisposable implementation

		public void Dispose ()
		{
			if (!this.disposed) {
				this.disposed = true;
				GC.SuppressFinalize (this);
			}
		}

		#endregion

		#region ICryptography implementation

		public string Encrypt (string value)
		{
			byte[] clearBytes = Encoding.Unicode.GetBytes (value);
			using (Aes encryptor = Aes.Create ()) {
				Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes (this.EncryptionKey, this.Salt);
				encryptor.Key = pdb.GetBytes(32);
				encryptor.IV = pdb.GetBytes (16);

				using (MemoryStream ms = new MemoryStream ()) {
					using (CryptoStream cs = new CryptoStream (ms, encryptor.CreateEncryptor (), CryptoStreamMode.Write)) {
						cs.Write (clearBytes, 0, clearBytes.Length);
						cs.Close ();
					}

					value = Convert.ToBase64String (ms.ToArray());
				}

			}

			return value;
		}

		public string Decrypt (string value)
		{
			byte[] cipherBytes = Convert.FromBase64String(value);
			using (Aes encryptor = Aes.Create ()) {
				Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes (this.EncryptionKey, this.Salt);
				encryptor.Key = pdb.GetBytes(32);
				encryptor.IV = pdb.GetBytes (16);

				using (MemoryStream ms = new MemoryStream ()) {
					using (CryptoStream cs = new CryptoStream (ms, encryptor.CreateDecryptor (), CryptoStreamMode.Write)) {
						cs.Write (cipherBytes, 0, cipherBytes.Length);
						cs.Close ();
					}

					value = Encoding.Unicode.GetString(ms.ToArray());
				}

			}

			return value;

		}

		#endregion

		public string EncryptionKey { get; set; }

		private byte[] Salt = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };

		private bool disposed = false;
	}
}

