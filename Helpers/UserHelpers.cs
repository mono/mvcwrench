//
// Authors:
// Jonathan Pobst (monkey@jpobst.com)
//
// Copyright (C) 2009 Jonathan Pobst
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Security.Principal;
using MvcWrench.Models;

namespace MvcWrench
{
	public class UserHelpers
	{
		public static string EmailToGravatar (string email, int size)
		{
			if (!string.IsNullOrEmpty (email)) {
				// build up image url, including MD5 hash for supplied email:
				MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider ();

				UTF8Encoding encoder = new UTF8Encoding ();
				MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider ();

				byte[] hashedBytes = md5Hasher.ComputeHash (encoder.GetBytes (email));

				StringBuilder sb = new StringBuilder (hashedBytes.Length * 2);
				for (int i = 0; i < hashedBytes.Length; i++) {
					sb.Append (hashedBytes[i].ToString ("X2"));
				}

				string newurl = string.Format ("http://www.gravatar.com/avatar/{0}?s={1}&r={2}&d=identicon", sb.ToString ().ToLower (), size, "pg");
				return newurl;
			}

			return string.Empty;
		}

		public static string SmallUser (string name, string email)
		{
			return string.Format ("<img class='image-small' src='{0}' />{1}", EmailToGravatar (email, 16), name);
		}
	}
}
