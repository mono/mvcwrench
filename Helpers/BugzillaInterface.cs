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
using System.Net;
//using System.ServiceModel.Syndication;
using System.Xml;

namespace MvcWrench
{
	public static class BugzillaInterface
	{
		private static ExpiringCache cache = new ExpiringCache ();

		public static List<BugzillaEntry> GetLatestBugs ()
		{
			List<BugzillaEntry> bugs = (List<BugzillaEntry>)cache.Get ("bugs");

			if (bugs == null) {
				int count = 10;

				string url = @"https://bugzilla.novell.com/buglist.cgi?chfield=[Bug%20creation]&chfieldfrom=7d&chfieldto=Now&classification=Mono&product=Mono%20Tasks&product=Mono%3A%20Class%20Libraries%20&product=Mono%3A%20Compilers&product=Mono%3A%20Debugger&product=Mono%3A%20Doctools&product=Mono%3A%20Runtime&product=Mono%3A%20Tools&query_format=advanced&ctype=rss";

				XmlDocument doc = new XmlDocument ();

				using (WebClient wc = new WebClient ()) {
					string xml = wc.DownloadString (url);
					doc.LoadXml (xml);
				}
					
				bugs = new List<BugzillaEntry> ();

				foreach (XmlElement item in doc["feed"].GetElementsByTagName ("entry"))
					bugs.Add (new BugzillaEntry (item));
					
				bugs = bugs.OrderByDescending (p => p.Number).Take (count).ToList ();
					
				cache.Add ("bugs", bugs, 10 * 60);
			}
			
			return bugs;
		}
	}

	public class BugzillaEntry
	{
		public string Number { get; set; }
		public string Url { get; set; }
		public string Title { get; set; }
		public DateTimeOffset Date { get; set; }
		public string Product { get; set; }
		public string Component { get; set; }
		public string Reporter { get; set; }
		public string AssignedTo { get; set; }
		public BugzillaStatus Status { get; set; }

		public BugzillaEntry ()
		{
		}

		//public BugzillaEntry (SyndicationItem entry)
		//{
		//        Url = entry.Id;
		//        Title = entry.Title.Text;
		//        Number = Url.Substring (Url.Length - 6);
		//        Date = entry.LastUpdatedTime;

		//        XmlDocument doc = new XmlDocument ();
		//        doc.LoadXml (entry.Summary.Text);

		//        Product = GetData (doc, "bz_feed_product");
		//        Component = GetData (doc, "bz_feed_component");
		//        Reporter = GetData (doc, "bz_feed_reporter");
		//        AssignedTo = GetData (doc, "bz_feed_assignee");

		//        string status = GetData (doc, "bz_feed_bug_status");

		//        switch (status.ToLowerInvariant ()) {
		//                case "new":
		//                case "assigned":
		//                        Status = BugzillaStatus.New;
		//                        break;
		//                case "reopened":
		//                        Status = BugzillaStatus.Reopened;
		//                        break;
		//                case "resolved":
		//                        Status = BugzillaStatus.Resolved;
		//                        break;
		//        }
		//}

		public BugzillaEntry (XmlElement xe)
		{
			Url = xe["id"].InnerText;
			Title = xe["title"].InnerText;
			Number = Url.Substring (Url.Length - 6);
			Date = DateTimeOffset.Parse (xe["updated"].InnerText);

			XmlDocument doc = new XmlDocument ();
			doc.LoadXml (xe["summary"].InnerText);

			Product = GetData (doc, "bz_feed_product");
			Component = GetData (doc, "bz_feed_component");
			Reporter = GetData (doc, "bz_feed_reporter");
			AssignedTo = GetData (doc, "bz_feed_assignee");

			string status = GetData (doc, "bz_feed_bug_status");

			switch (status.ToLowerInvariant ()) {
				case "new":
				case "assigned":
					Status = BugzillaStatus.New;
					break;
				case "reopened":
					Status = BugzillaStatus.Reopened;
					break;
				case "resolved":
					Status = BugzillaStatus.Resolved;
					break;
			}
		}
		
		private string GetData (XmlDocument doc, string type)
		{
			XmlElement xe = (XmlElement)doc.SelectSingleNode (string.Format ("//table/tr[@class = \"{0}\"]", type));

			if (xe == null)
				return string.Empty;

			XmlElement child = (XmlElement)xe.LastChild;

			if (child == null)
				return string.Empty;

			return child.InnerText;
		}
	}

	public enum BugzillaStatus
	{
		New,
		Reopened,
		Resolved
	}
}
