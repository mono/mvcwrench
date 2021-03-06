//
// Authors:
// Jonathan Pobst (monkey@jpobst.com)
//
// Copyright (C) 2010 Jonathan Pobst
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
using System.Web.Mvc;
using MvcWrench.MonkeyWrench.Public;
using System.Text;

namespace MvcWrench.Controllers
{
	public class HomeController : ApplicationController
	{
		public ActionResult Index ()
		{
			List<BugzillaEntry> bugs;

			try {
				bugs = (List<BugzillaEntry>)Cache.Instance.Get ("buglist");

				if (bugs == null) {
					bugs = BugzillaInterface.GetLatestBugs ();
					//bugs = new List<BugzillaEntry> ();
					Cache.Instance.Add ("buglist", bugs, 3 * 60);
				}				
			} catch (Exception ex) {
				bugs = new List<BugzillaEntry> ();
				//throw;
			}
			

			Revision[] recent_revisions = (Revision[])Cache.Instance.Get ("recent_revisions");
			
			if (recent_revisions == null) {
				try {
					MonkeyWrench.Public.Public ws = new MvcWrench.MonkeyWrench.Public.Public ();
					recent_revisions = ws.GetProductLatestRevisions (1, 20);
					Cache.Instance.Add ("recent_revisions", recent_revisions, 5 * 60);
				} catch (Exception) {
					recent_revisions = new Revision[0];
				}
			}

			string bugcounts = (string)Cache.Instance.Get ("bugcounts");

			if (bugcounts == null) {
				try {
					MonkeyWrench.Public.Public ws = new MvcWrench.MonkeyWrench.Public.Public ();
					string[] counts = ws.GetLatestBugCounts (60);
					
					StringBuilder sb = new StringBuilder ();

					foreach (string item in counts)
						sb.AppendFormat ("{0},", (int)(int.Parse (item.Split (',')[0]) / 25f));
						
					sb.Remove (sb.Length - 1, 1);
					sb.Append ("|");

					foreach (string item in counts)
						sb.AppendFormat ("{0},", (int)(int.Parse(item.Split (',')[1]) / 25f));

					sb.Remove (sb.Length - 1, 1);

					bugcounts = sb.ToString ();

					Cache.Instance.Add ("bugcounts", bugcounts, 60 * 60);
				} catch (Exception) {
					bugcounts = null;
				}
			}
			
			ViewData["Revisions"] = recent_revisions;
			ViewData["BugCounts"] = bugcounts;
			
			return View ("Home", bugs);
		}
	}
}
