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
using System.ServiceModel.Syndication;
using System.Xml;

namespace MvcWrench.Helpers
{
	public static class BugzillaInterface
	{
		private static ExpiringCache cache = new ExpiringCache (10 * 60);
		
		private static List<SyndicationItem> GetLatestBugs ()
		{
			int count = 15;
			
			string url = @"https://bugzilla.novell.com/buglist.cgi?chfield=[Bug%20creation]&chfieldfrom=7d&chfieldto=Now&classification=Mono&product=Mono%20Tasks&product=Mono%3A%20Class%20Libraries%20&product=Mono%3A%20Compilers&product=Mono%3A%20Debugger&product=Mono%3A%20Doctools&product=Mono%3A%20Runtime&product=Mono%3A%20Tools&query_format=advanced&ctype=rss";

			SyndicationFeed feed = null;

			using (XmlTextReader r = new XmlTextReader (url))
				feed = SyndicationFeed.Load (r);

			IEnumerable<SyndicationItem> items = feed.Items.OrderByDescending (p => p.Id).Take (count);

			return items.ToList ();
		}
	}
}
