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

namespace MvcWrench.Models
{
	public class ClassStatus
	{
		private static ClassStatus instance;
		
		public List<StatusProfile> Profiles { get; private set; }
		
		public ClassStatus ()
		{
			Profiles = new List<StatusProfile> ();
		}
		
		public static ClassStatus GetInstance (string source)
		{
			if (instance == null) {
				ClassStatus status = new ClassStatus ();
				
				XmlDocument doc = new XmlDocument ();
				doc.Load (source);

				foreach (XmlElement p in doc.DocumentElement.SelectNodes ("/profiles/profile")) {
					StatusProfile sp = new StatusProfile ();
					sp.Name = p.GetAttribute ("name");
					sp.Profile = p.GetAttribute ("profile");
					sp.Reference = p.GetAttribute ("reference");
					sp.Icon = p.GetAttribute ("icon");
					
					foreach (XmlElement child in p.ChildNodes)
						sp.Assemblies.Add (child.InnerText);
					
					status.Profiles.Add (sp);
				}
				
				instance = status;
			}
			
			return instance;
		}
	}
	
	public class StatusProfile
	{
		public string Name { get; set; }
		public string Profile { get; set; }
		public string Reference { get; set; }
		public string Icon { get; set; }
		
		public List<string> Assemblies { get; private set; }
		
		public StatusProfile ()
		{
			Assemblies = new List<string> ();
		}
	}
}
