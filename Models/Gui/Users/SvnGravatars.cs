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
using System.Xml;
using System.IO;

namespace MvcWrench.Models
{
	public class SvnGravatars
	{
		private static SvnGravatars instance;
		
		private Dictionary<string, string> gravatars;

		public SvnGravatars ()
		{
			gravatars = new Dictionary<string, string> ();
		}

		public static SvnGravatars GetInstance (string source)
		{
			if (instance == null) {
				SvnGravatars grav = new SvnGravatars ();

				using (StreamReader sr = new StreamReader (source)) {
					string line;
					
					while ((line = sr.ReadLine ()) != null) {
						string[] pieces = line.Split (',');
						grav.gravatars.Add (pieces[0], pieces[1]);
					}
				}

				instance = grav;
			}
			
			return instance;
		}
		
		public string Get (string svnuser)
		{
			if (gravatars.ContainsKey (svnuser))
				return gravatars[svnuser];
				
			return svnuser;
		}
	}
}
