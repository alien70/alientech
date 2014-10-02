
// <copyright file="ICryptographer.cs" company="AlienTech">
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

namespace masmec.ate.utils
{
	public interface ICryptographer
	{
		string Encrypt(string value);

		string Decrypt(string value);

		string EncryptionKey{ get; set; }

	}
}

