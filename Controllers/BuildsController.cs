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
using System.Web.Mvc;
using MvcWrench.Models;
using MvcWrench.mono_build;
using MvcWrench.MonkeyWrench.Public;
using System.Net;
using System.Text.RegularExpressions;
using System.Linq;

namespace MvcWrench.Controllers
{
	public class BuildsController : ApplicationController
	{
		// GET: /Builds/Official
		public ActionResult Index ()
		{
			int[] trunk_rows = new int[] { 14, 41, 31, 110, 128, 129 };
			int[] mono26_rows = new int[] { 75, 100, 98, 122, 163, 164 };
			int[] mono24_rows = new int[] { 94, 101, 96, 123, 119, 120 };
			
			WebServices ws = new WebServices ();
			WebServiceLogin login = new WebServiceLogin ();

			DateTime start = DateTime.Now;
			FrontPageResponse data = ws.GetFrontPageData2 (login, 10, null, null);
			TimeSpan data_elapsed = DateTime.Now - start;
			
			List<StatusStrip> strips = new List<StatusStrip> ();
			
			StatusStrip strip = new StatusStrip ("Mono - Trunk");
			AddRowsToStrip (strip, "mono", trunk_rows, data);
			
			StatusStrip strip26 = new StatusStrip ("Mono - 2.6 Branch");
			AddRowsToStrip (strip26, "mono26", mono26_rows, data);

			StatusStrip strip24 = new StatusStrip ("Mono - 2.4 Branch");
			AddRowsToStrip (strip24, "mono24", mono24_rows, data);

			strips.Add (strip);
			strips.Add (strip26);
			strips.Add (strip24);

			// This adds the MSVC build to the page.
			// Disabled because the MSVC build doesn't support Git
			//start = DateTime.Now;
			//try {
			//        MonkeyWrench.Public.Public ws2 = new MvcWrench.MonkeyWrench.Public.Public ();
			//        var msvc = ws2.GetRecentData ("msvc");
				
			//        strip.Rows.Add (MonkeyWrenchHelper.GetRow (msvc));
			//        //strip.Rows.Insert (0, MonkeyWrenchHelper.GetHeaderRow (msvc));
			//} catch {
			//        // Carry on even if this fails
			//}
			//TimeSpan remote_elapsed = DateTime.Now - start;
			//ViewData["MsvcElapsed"] = remote_elapsed;

			ViewData["PageTitle"] = "MonkeyWrench - Mono Build Overview";
			ViewData["MonkeyWrenchElapsed"] = data_elapsed;

			return View ("Index", strips);
		}
		
		// GET: /Builds/monoextended
		public ActionResult MonoExtended ()
		{
			int[] trunk_dist_rows = new int[] { 14, 110, 111, 128, 129 };
			int[] trunk_rows = new int[] { 34, 35, 36, 37, 31, 41, 84 };
			int[] trunk_rpm_rows = new int[] { 39 };
			int[] trunk_40_rows = new int[] { 58 };
			int[] trunk_minimal_rows = new int[] { 38 };
			int[] mono_26_rows = new int[] { 75, 99, 98, 100, 116, 163, 164, 122, 125, 126 };
			int[] mono_26_rpm_rows = new int[] { 112 };
			int[] mono_243_rows = new int[] { 102, 94, 101, 96, 123, 119, 120, 97, 115, 124, 127 };

			WebServices ws = new WebServices ();
			WebServiceLogin login = new WebServiceLogin ();

			FrontPageResponse data = ws.GetFrontPageData2 (login, 10, null, null);

			List<StatusStrip> strips = new List<StatusStrip> ();

			StatusStrip strip_trunk_dist = new StatusStrip ("Mono - Trunk - Dist");
			AddRowsToStrip (strip_trunk_dist, null, trunk_dist_rows, data);

			StatusStrip strip_trunk = new StatusStrip ("Mono - Trunk");
			AddRowsToStrip (strip_trunk, null, trunk_rows, data);

			StatusStrip strip_rpm = new StatusStrip ("Mono - Trunk - rpm");
			AddRowsToStrip (strip_rpm, null, trunk_rpm_rows, data);

			StatusStrip strip_40 = new StatusStrip ("Mono - Trunk - 4.0");
			AddRowsToStrip (strip_40, null, trunk_40_rows, data);

			StatusStrip strip_trunk_min = new StatusStrip ("Mono - Trunk - Minimal");
			AddRowsToStrip (strip_trunk_min, null, trunk_minimal_rows, data);

			StatusStrip strip_26 = new StatusStrip ("Mono - 2.6");
			AddRowsToStrip (strip_26, null, mono_26_rows, data);

			StatusStrip strip_rpm_26 = new StatusStrip ("Mono - 2.6 - rpm");
			AddRowsToStrip (strip_rpm_26, null, mono_26_rpm_rows, data);

			StatusStrip strip24 = new StatusStrip ("Mono - 2.4.3");
			AddRowsToStrip (strip24, null, mono_243_rows, data);

			strips.Add (strip_trunk_dist);
			strips.Add (strip_trunk);
			strips.Add (strip_rpm);
			strips.Add (strip_40);
			strips.Add (strip_26);
			strips.Add (strip_rpm_26);
			strips.Add (strip24);

			ViewData["PageTitle"] = "MonkeyWrench - Mono Extended Build Overview";

			return View ("Index", strips);
		}

		// GET: /Builds/monodevelop
		public ActionResult MonoDevelop ()
		{
			WebServices ws = new WebServices ();
			WebServiceLogin login = new WebServiceLogin ();

			FrontPageResponse data = ws.GetFrontPageData2 (login, 10, null, null);

			List<StatusStrip> strips = new List<StatusStrip> ();

			StatusStrip strip_md = new StatusStrip ("MonoDevelop - Trunk");
			AddRowsToStrip (strip_md, "monodevelop", new int[] { 131 }, data);
			strips.Add (strip_md);

			ViewData["PageTitle"] = "MonkeyWrench - MonoDevelop";

			return View ("Index", strips);
		}

		// GET: /Builds/other
		public ActionResult Other ()
		{
			WebServices ws = new WebServices ();
			WebServiceLogin login = new WebServiceLogin ();

			FrontPageResponse data = ws.GetFrontPageData2 (login, 10, null, null);

			List<StatusStrip> strips = new List<StatusStrip> ();

			StatusStrip strip_md = new StatusStrip ();
			strip_md.Name = "MonoDevelop - 2.2 - Dist";
			strip_md.Rows.Add (MonkeyWrenchHelper.GetRow (49, data, "dist"));
			strip_md.Rows.Add (MonkeyWrenchHelper.GetRow (50, data, "database-dist"));
			strip_md.Rows.Add (MonkeyWrenchHelper.GetRow (51, data, "boo-dist"));
			strip_md.Rows.Add (MonkeyWrenchHelper.GetRow (52, data, "java-dist"));
			strip_md.Rows.Add (MonkeyWrenchHelper.GetRow (53, data, "vala-dist"));
			strip_md.Rows.Add (MonkeyWrenchHelper.GetRow (54, data, "debugger-gdb-dist"));
			strip_md.Rows.Add (MonkeyWrenchHelper.GetRow (55, data, "debugger-mdb-dist"));
			strip_md.Rows.Add (MonkeyWrenchHelper.GetRow (56, data, "python-dist"));

			StatusStrip strip_tools = new StatusStrip ();
			strip_tools.Name = "Tools - Trunk";
			strip_tools.Rows.Add (MonkeyWrenchHelper.GetRow (10, data, "libgdiplus - dist"));
			strip_tools.Rows.Add (MonkeyWrenchHelper.GetRow (43, data, "libgdiplus - check"));
			strip_tools.Rows.Add (MonkeyWrenchHelper.GetRow (44, data, "mono-tools - dist"));
			strip_tools.Rows.Add (MonkeyWrenchHelper.GetRow (47, data, "xsp - dist"));
			strip_tools.Rows.Add (MonkeyWrenchHelper.GetRow (48, data, "debugger - dist"));

			StatusStrip strip_tools_26 = new StatusStrip ();
			strip_tools_26.Name = "Tools - 2.6";
			strip_tools_26.Rows.Add (MonkeyWrenchHelper.GetRow (76, data, "libgdiplus - dist"));
			strip_tools_26.Rows.Add (MonkeyWrenchHelper.GetRow (78, data, "mono-tools - dist"));
			strip_tools_26.Rows.Add (MonkeyWrenchHelper.GetRow (79, data, "xsp - dist"));
			strip_tools_26.Rows.Add (MonkeyWrenchHelper.GetRow (77, data, "debugger - dist"));
			strip_tools_26.Rows.Add (MonkeyWrenchHelper.GetRow (80, data, "mono-basic - dist"));
			strip_tools_26.Rows.Add (MonkeyWrenchHelper.GetRow (81, data, "mod_mono - dist"));
			strip_tools_26.Rows.Add (MonkeyWrenchHelper.GetRow (82, data, "gluezilla - dist"));

			StatusStrip strip_tools_24 = new StatusStrip ();
			strip_tools_24.Name = "Tools - 2.4.3";
			strip_tools_24.Rows.Add (MonkeyWrenchHelper.GetRow (108, data, "libgdiplus - dist"));
			strip_tools_24.Rows.Add (MonkeyWrenchHelper.GetRow (106, data, "mono-tools - dist"));
			strip_tools_24.Rows.Add (MonkeyWrenchHelper.GetRow (107, data, "xsp - dist"));
			strip_tools_24.Rows.Add (MonkeyWrenchHelper.GetRow (103, data, "debugger - dist"));
			strip_tools_24.Rows.Add (MonkeyWrenchHelper.GetRow (109, data, "mono-basic - dist"));
			strip_tools_24.Rows.Add (MonkeyWrenchHelper.GetRow (105, data, "mod_mono - dist"));
			strip_tools_24.Rows.Add (MonkeyWrenchHelper.GetRow (104, data, "gluezilla - dist"));

			StatusStrip strip_mw = new StatusStrip ();
			strip_mw.Name = "MonkeyWrench";
			strip_mw.Rows.Add (MonkeyWrenchHelper.GetRow (57, data));

			strips.Add (strip_md);
			strips.Add (strip_tools);
			strips.Add (strip_tools_26);
			strips.Add (strip_tools_24);
			strips.Add (strip_mw);

			ViewData["PageTitle"] = "MonkeyWrench - Other Projects Build Overview";

			return View ("Index", strips);
		}

		// GET: /Builds/msvc/{buildrevisionid}
		public ActionResult BuildStatus (string buildrevisionid)
		{
			// Build the build step list model
			BuildStepList list = new BuildStepList (); 
			
			MonkeyWrench.Public.Public ws2 = new MvcWrench.MonkeyWrench.Public.Public ();
			var steps = ws2.GetCompletedSteps (long.Parse (buildrevisionid));

			foreach (CompletedBuildStep step in steps) {
				BuildStepListItem item = new BuildStepListItem (step.Id, TimeSpan.Zero, step.ExitCode, step.CompletionStatus, step.StepName);
				item.LogUrl = string.Format ("~/builds/msvc/{0}/{1}", buildrevisionid, step.Id);

				list.Items.Add (item);
			}

			//// Build the bread crumb bar model
			//BreadCrumb bc = new BreadCrumb ();

			//bc.Crumbs.Add (new Crumb ("Projects", UrlBuilder.Builds));
			//bc.Crumbs.Add (new Crumb (p.Name, UrlBuilder.ProductBuild (p)));
			//bc.Crumbs.Add (new Crumb (string.Format ("Revision {0}", pr.Revision), UrlBuilder.RevisionDetails (pr)));
			//bc.Crumbs.Add (new Crumb (plat.Name));

			//ViewData["Platform"] = platform;
			//ViewData["BreadCrumb"] = bc;
			ViewData["BuildStepList"] = list;
			//ViewData["Installer"] = installer;
			ViewData["PageTitle"] = "MonkeyWrench - Msvc Build Overview";

			return View ("BuildStatus");
		}
		
		// GET: /Builds/{product}/{revision}/{platform}/log/{id}
		public ActionResult BuildStatusLog (string buildrevisionid, string completedstepid)
		{
			MonkeyWrench.Public.Public ws2 = new MvcWrench.MonkeyWrench.Public.Public ();
			string log = ws2.GetBuildLog (int.Parse (completedstepid));

			ViewData["PageTitle"] = "MonkeyWrench - View Log";
			ViewData["Log"] = log;
			return View ("BuildStatusLog");//, log);
		}
		
		public ActionResult RevisionDetails (string project, string platform, string revision)
		{
			int lane_id;
			int host_id;
			int revision_id;
			
			if (!FindHostAndLane (project, platform, out host_id, out lane_id))
				return View ("Error");
				
			WebServices ws = new WebServices ();
			WebServiceLogin login = new WebServiceLogin ();

			var rev = ws.FindRevisionForLane (login, null, revision, lane_id, null);
			revision_id = rev.Revision.id;
			
			GetViewLaneDataResponse data = ws.GetViewLaneData (login, lane_id, null, host_id, null, revision_id, null);

			Commit commit = new Commit ();
			
			commit.CompletionStatus = data.RevisionWork.state;
			commit.Revision = data.Revision.revision;
			commit.Author = data.Revision.author;
			commit.CommitTime = data.Revision.date;
			commit.Lane = data.Lane.lane;
			commit.Host = data.Host.host;
			commit.Builder = data.WorkHost == null ? "" : data.WorkHost.host;
			commit.BuildDuration = TimeSpan.Zero;
			commit.CommitLog = "";
			commit.Email = SvnGravatars.Get (commit.Author);
			commit.ProjectLinkName = project;
			
			// Download the commit log to add
			string url = string.Format ("http://build.mono-project.com/GetRevisionLog.aspx?id={0}", data.Revision.id);

			WebClient wc = new WebClient ();
			string content = wc.DownloadString (url);
			
			Regex reg = new Regex (@"\<pre\ id\=\""ctl00_content_log\""\>(?<data>(?:.|\n)*?)\<\/pre\>", RegexOptions.Multiline);
			Match m = reg.Match (content);
			commit.CommitLog = m.Groups["data"].Value.Trim ();

			// Build the list of steps
			BuildStepList bsl = new BuildStepList ();

			string history_url = @"http://build.mono-project.com/ViewWorkTable.aspx?lane_id={0}&host_id={1}&command_id={2}";
			string log_url = @"http://build.mono-project.com/GetFile.aspx?id={0}";
			
			DateTime start_time = DateTime.MinValue;
			
			for (int j = 0; j < data.WorkViews.Length; j++) {
				var item = data.WorkViews[j];
				var log = data.WorkFileViews[j];
				
				if (j == 0)
					start_time = item.starttime;
					
				BuildStepListItem i = new BuildStepListItem ();
				
				i.BuildStepID = item.id;
				i.ElapsedTime = item.endtime.Subtract (item.starttime);
				i.HistoryUrl = string.Format (history_url, lane_id, host_id, item.command_id);
				i.Name = item.command;
				i.Results = item.summary;
				i.CompletionStatus = item.state;
				
				if (log != null && log.Length > 0)
					i.LogUrl = string.Format (log_url, log[0].id);
					
				bsl.Items.Add (i);
			}
			
			if (data.RevisionWork.completed)
				commit.BuildDuration = data.RevisionWork.endtime.Subtract (start_time);
			
			//ws.getre
			ViewData["commit"] = commit;
			ViewData["steps"] = bsl;
			ViewData["PageTitle"] = string.Format ("MonkeyWrench - Revision {0} - Host {1}", commit.Revision, commit.Host);
			
			return View ("RevisionDetails");
		}

		public ActionResult RevisionDiff (string project, string revision)
		{
			MonkeyWrench.Public.Public ws2 = new Public ();
			Revision r = ws2.GetRevisionByRevision (int.Parse (revision));

			ViewData["PageTitle"] = string.Format ("MonkeyWrench - Revision {0}", revision);

			if (r == null || string.IsNullOrEmpty (r.FileDiff))
				ViewData["Diff"] = "Diff not available";
			else {
				try {
					ViewData["Diff"] = new DiffViewer (r.FileDiff);
				} catch {
					ViewData["Diff"] = r.FileDiff;
				}
			}

			return View ("RevisionDiff", r);

			
			//int revision_id;

			//WebServices ws = new WebServices ();
			//WebServiceLogin login = new WebServiceLogin ();

			//var rev = ws.FindRevision (login, null, revision);
			//revision_id = rev.Revision.id;

			//string log;
			//string diff;
			
			//// Download the commit log to add
			//string url = string.Format ("http://build.mono-project.com/GetRevisionLog.aspx?id={0}", revision_id);

			//WebClient wc = new WebClient ();
			//string content = wc.DownloadString (url);

			//Regex reg = new Regex (@"\<pre\ id\=\""ctl00_content_log\""\>(?<data>(?:.|\n)*?)\<\/pre\>", RegexOptions.Multiline);
			//Match m = reg.Match (content);
			//log = m.Groups["data"].Value.Trim ();

			//reg = new Regex (@"\<pre\ id\=\""ctl00_content_diff\""\>(?<data>(?:.|\n)*?)\<\/pre\>", RegexOptions.Multiline);
			//m = reg.Match (content);
			//diff = m.Groups["data"].Value.Trim ();

			//Revision r = new Revision ();
			
			//r.Author = rev.Revision.author;
			//r.SvnLog = System.Web.HttpUtility.HtmlDecode (log);
			//r.RevisionNumber = int.Parse (revision);
			//r.Time = rev.Revision.date;

			//ViewData["PageTitle"] = string.Format ("MonkeyWrench - Revision {0}", r.RevisionNumber);

			//if (string.IsNullOrEmpty (diff))
			//        ViewData["Diff"] = "Diff not available";
			//else {
			//        try {
			//                ViewData["Diff"] = new DiffViewer (System.Web.HttpUtility.HtmlDecode (diff));
			//        } catch {
			//                ViewData["Diff"] = System.Web.HttpUtility.HtmlDecode (diff);
			//        }
			//}

			//return View ("RevisionDiff", r);
		}

		private void AddRowsToStrip (StatusStrip strip, string projectLink, int[] hosts, FrontPageResponse data)
		{
			string new_rev_link = "~/builds/{0}/{1}/{2}";

			foreach (int i in hosts) {
				StatusStripRow row = MonkeyWrenchHelper.GetRow (i, data);

				if (row != null)
					strip.Rows.Add (row);
			}

			// Update each cell's link to the wrench URL, not the old MW URL
			foreach (var row in strip.Rows) {
				foreach (var cell in row.Cells) {
					if (cell.IsHeader || cell.Text == "msvc: windows")
						continue;
						
					if (!string.IsNullOrEmpty (projectLink))
						cell.Url = string.Format (new_rev_link, projectLink, row.HeaderText.Replace (": ", "-"), cell.Text.TrimStart ('r'));
					
					cell.Text = Utilities.FormatRevision (cell.Text);
				}
			}
		}
		
		private bool FindHostAndLane (string project, string platform, out int host, out int lane)
		{
			host = -1;
			lane = -1;

			switch (string.Format ("{0}|{1}", project, platform).ToLowerInvariant ()) {
				case "mono|sle-11-i586":
					lane = 17;
					host = 23;
					return true;
				case "mono|dist":
					lane = 2;
					host = 2;
					return true;
				case "mono|sle-11-x86_64":
					lane = 17;
					host = 3;
					return true;
				case "mono|windows-5.1-i586":
					lane = 40;
					host = 8;
					return true;
				case "mono|macos-10.4-i386":
					lane = 40;
					host = 51;
					return true;
				case "mono|macos-10.4-ppc":
					lane = 40;
					host = 5;
					return true;
				case "mono|eglib-sle-11-i586":
					lane = 12;
					host = 23;
					return true;
				case "mono|eglib-sle-11-x64":
					lane = 12;
					host = 3;
					return true;
				case "mono26|dist":
					lane = 41;
					host = 2;
					return true;
				case "mono26|sle-11-i586":
					lane = 62;
					host = 23;
					return true;
				case "mono26|sle-11-x86_64":
					lane = 62;
					host = 3;
					return true;
				case "mono26|windows-5.1-i586":
					lane = 62;
					host = 8;
					return true;
				case "mono26|macos-10.4-i386":
					lane = 62;
					host = 51;
					return true;
				case "mono26|macos-10.4-ppc":
					lane = 62;
					host = 5;
					return true;
				case "mono24|dist":
					lane = 61;
					host = 2;
					return true;
				case "mono24|sle-11-i586":
					lane = 60;
					host = 23;
					return true;
				case "mono24|sle-11-x86_64":
					lane = 60;
					host = 3;
					return true;
				case "mono24|windows-5.1-i586":
					lane = 60;
					host = 8;
					return true;
				case "mono24|macos-10.4-i386":
					lane = 60;
					host = 51;
					return true;
				case "mono24|macos-10.4-ppc":
					lane = 60;
					host = 5;
					return true;
				case "monodevelop|sle-11-i586":
					lane = 75;
					host = 23;
					return true;
				case "mono|macos-10.5-i386":
					lane = 40;
					host = 53;
					return true;
				case "mono|macos-10.5-ppc":
					lane = 40;
					host = 55;
					return true;
				case "mono26|macos-10.5-i386":
					lane = 62;
					host = 53;
					return true;
				case "mono26|macos-10.5-ppc":
					lane = 62;
					host = 55;
					return true;
			}
			
			return false;
		}
		
		#region Global Data
		protected override void OnActionExecuted (ActionExecutedContext filterContext)
		{
			ViewData["TreeView"] = CreateBuildsTree ();

			base.OnActionExecuted (filterContext);
		}

		private TreeViewModel CreateBuildsTree ()
		{
			TreeViewModel tv = new TreeViewModel ();

			tv.Nodes.Add (new TreeViewNode ("Mono", "~/builds/mono", "~/Media/mono.png"));
			tv.Nodes.Add (new TreeViewNode ("Mono - Extended", "~/builds/monoextended", "~/Media/mono.png"));
			tv.Nodes.Add (new TreeViewNode ("MonoDevelop", "~/builds/monodevelop", "~/Media/monodevelop.png"));
			tv.Nodes.Add (new TreeViewNode ("Other Projects", "~/builds/other", "~/Media/bricks.png"));

			return tv;
		}
		#endregion
	}
}
