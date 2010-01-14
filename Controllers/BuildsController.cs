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
			string new_rev_link = "builds/{0}/{1}/{2}";

			WebServices ws = new WebServices ();
			WebServiceLogin login = new WebServiceLogin ();

			FrontPageResponse data = ws.GetFrontPageData2 (login, 10, null, null);

			List<StatusStrip> strips = new List<StatusStrip> ();
			StatusStrip strip = new StatusStrip ();

			strip.Name = "Mono - Trunk";

			strip.Rows.Add (MonkeyWrenchHelper.GetRow (14, data));
			strip.Rows.Add (MonkeyWrenchHelper.GetRow (41, data));
			strip.Rows.Add (MonkeyWrenchHelper.GetRow (111, data));
			strip.Rows.Add (MonkeyWrenchHelper.GetRow (110, data));
			strip.Rows.Add (MonkeyWrenchHelper.GetRow (117, data));
			strip.Rows.Add (MonkeyWrenchHelper.GetRow (66, data));
			strip.Rows.Add (MonkeyWrenchHelper.GetRow (74, data, "eglib: sle-11-i586"));
			strip.Rows.Add (MonkeyWrenchHelper.GetRow (21, data, "eglib: sle-11-x64"));

			StatusStrip strip26 = new StatusStrip ();
			strip26.Name = "Mono - 2.6 Branch";
			strip26.Rows.Add (MonkeyWrenchHelper.GetRow (75, data));
			strip26.Rows.Add (MonkeyWrenchHelper.GetRow (100, data));
			strip26.Rows.Add (MonkeyWrenchHelper.GetRow (98, data));
			strip26.Rows.Add (MonkeyWrenchHelper.GetRow (122, data));
			strip26.Rows.Add (MonkeyWrenchHelper.GetRow (118, data));
			strip26.Rows.Add (MonkeyWrenchHelper.GetRow (121, data));

			StatusStrip strip24 = new StatusStrip ();
			strip24.Name = "Mono - 2.4 Branch";
			strip24.Rows.Add (MonkeyWrenchHelper.GetRow (94, data));
			strip24.Rows.Add (MonkeyWrenchHelper.GetRow (101, data));
			strip24.Rows.Add (MonkeyWrenchHelper.GetRow (96, data));
			strip24.Rows.Add (MonkeyWrenchHelper.GetRow (123, data));
			strip24.Rows.Add (MonkeyWrenchHelper.GetRow (119, data));
			strip24.Rows.Add (MonkeyWrenchHelper.GetRow (120, data));

			strips.Add (strip);
			strips.Add (strip26);
			strips.Add (strip24);

			foreach (var row in strip.Rows) {
				foreach (var cell in row.Cells) {
					if (cell.IsHeader || cell.Text == "msvc: windows")
						continue;
						
					cell.Url = string.Format (new_rev_link, "mono", row.HeaderText.Replace (": ", "-"), cell.Text.TrimStart ('r'));
				}
			}

			foreach (var row in strip26.Rows) {
				foreach (var cell in row.Cells) {
					if (cell.IsHeader)
						continue;

					cell.Url = string.Format (new_rev_link, "mono26", row.HeaderText.Replace (": ", "-"), cell.Text.TrimStart ('r'));
				}
			}

			foreach (var row in strip24.Rows) {
				foreach (var cell in row.Cells) {
					if (cell.IsHeader)
						continue;

					cell.Url = string.Format (new_rev_link, "mono24", row.HeaderText.Replace (": ", "-"), cell.Text.TrimStart ('r'));
				}
			}

			try {
				MonkeyWrench.Public.Public ws2 = new MvcWrench.MonkeyWrench.Public.Public ();
				var msvc = ws2.GetRecentData ("msvc");
				
				strip.Rows.Add (MonkeyWrenchHelper.GetRow (msvc));
				//strip.Rows.Insert (0, MonkeyWrenchHelper.GetHeaderRow (msvc));
			} catch {
				// Carry on even if this fails
			}
			
			ViewData["PageTitle"] = "MonkeyWrench - Mono Build Overview";

			return View ("Index", strips);
		}
		
		// GET: /Builds/monoextended
		public ActionResult MonoExtended ()
		{
			WebServices ws = new WebServices ();
			WebServiceLogin login = new WebServiceLogin ();

			FrontPageResponse data = ws.GetFrontPageData2 (login, 10, null, null);

			List<StatusStrip> strips = new List<StatusStrip> ();

			StatusStrip strip_trunk_dist = new StatusStrip ();
			strip_trunk_dist.Name = "Mono - Trunk - Dist";
			strip_trunk_dist.Rows.Add (MonkeyWrenchHelper.GetRow (14, data));
			strip_trunk_dist.Rows.Add (MonkeyWrenchHelper.GetRow (66, data));
			strip_trunk_dist.Rows.Add (MonkeyWrenchHelper.GetRow (110, data));
			strip_trunk_dist.Rows.Add (MonkeyWrenchHelper.GetRow (111, data));
			strip_trunk_dist.Rows.Add (MonkeyWrenchHelper.GetRow (117, data));
			strip_trunk_dist.Rows.Add (MonkeyWrenchHelper.GetRow (128, data));
			strip_trunk_dist.Rows.Add (MonkeyWrenchHelper.GetRow (129, data));

			StatusStrip strip_trunk = new StatusStrip ();
			strip_trunk.Name = "Mono - Trunk";
			strip_trunk.Rows.Add (MonkeyWrenchHelper.GetRow (73, data));
			strip_trunk.Rows.Add (MonkeyWrenchHelper.GetRow (34, data));
			strip_trunk.Rows.Add (MonkeyWrenchHelper.GetRow (35, data));
			strip_trunk.Rows.Add (MonkeyWrenchHelper.GetRow (36, data));
			strip_trunk.Rows.Add (MonkeyWrenchHelper.GetRow (37, data));
			strip_trunk.Rows.Add (MonkeyWrenchHelper.GetRow (31, data));
			strip_trunk.Rows.Add (MonkeyWrenchHelper.GetRow (41, data));
			strip_trunk.Rows.Add (MonkeyWrenchHelper.GetRow (84, data));

			StatusStrip strip_eglib = new StatusStrip ();
			strip_eglib.Name = "Mono - Trunk - eglib";
			strip_eglib.Rows.Add (MonkeyWrenchHelper.GetRow (74, data));
			strip_eglib.Rows.Add (MonkeyWrenchHelper.GetRow (21, data));

			StatusStrip strip_rpm = new StatusStrip ();
			strip_rpm.Name = "Mono - Trunk - rpm";
			strip_rpm.Rows.Add (MonkeyWrenchHelper.GetRow (39, data));

			StatusStrip strip_40 = new StatusStrip ();
			strip_40.Name = "Mono - Trunk - 4.0";
			strip_40.Rows.Add (MonkeyWrenchHelper.GetRow (58, data));

			StatusStrip strip_trunk_min = new StatusStrip ();
			strip_trunk_min.Name = "Mono - Trunk - Minimal";
			strip_trunk_min.Rows.Add (MonkeyWrenchHelper.GetRow (38, data));

			StatusStrip strip_26 = new StatusStrip ();
			strip_26.Name = "Mono - 2.6";
			strip_26.Rows.Add (MonkeyWrenchHelper.GetRow (75, data));
			strip_26.Rows.Add (MonkeyWrenchHelper.GetRow (99, data));
			strip_26.Rows.Add (MonkeyWrenchHelper.GetRow (98, data));
			strip_26.Rows.Add (MonkeyWrenchHelper.GetRow (100, data));
			strip_26.Rows.Add (MonkeyWrenchHelper.GetRow (116, data));
			strip_26.Rows.Add (MonkeyWrenchHelper.GetRow (118, data));
			strip_26.Rows.Add (MonkeyWrenchHelper.GetRow (121, data));
			strip_26.Rows.Add (MonkeyWrenchHelper.GetRow (122, data));
			strip_26.Rows.Add (MonkeyWrenchHelper.GetRow (125, data));
			strip_26.Rows.Add (MonkeyWrenchHelper.GetRow (126, data));

			StatusStrip strip_rpm_26 = new StatusStrip ();
			strip_rpm_26.Name = "Mono - 2.6 - rpm";
			strip_rpm_26.Rows.Add (MonkeyWrenchHelper.GetRow (112, data));

			StatusStrip strip24 = new StatusStrip ();
			strip24.Name = "Mono - 2.4.3";
			strip24.Rows.Add (MonkeyWrenchHelper.GetRow (102, data));
			strip24.Rows.Add (MonkeyWrenchHelper.GetRow (94, data));
			strip24.Rows.Add (MonkeyWrenchHelper.GetRow (101, data));
			strip24.Rows.Add (MonkeyWrenchHelper.GetRow (96, data));
			strip24.Rows.Add (MonkeyWrenchHelper.GetRow (123, data));
			strip24.Rows.Add (MonkeyWrenchHelper.GetRow (119, data));
			strip24.Rows.Add (MonkeyWrenchHelper.GetRow (120, data));
			strip24.Rows.Add (MonkeyWrenchHelper.GetRow (97, data));
			strip24.Rows.Add (MonkeyWrenchHelper.GetRow (115, data));
			strip24.Rows.Add (MonkeyWrenchHelper.GetRow (124, data));
			strip24.Rows.Add (MonkeyWrenchHelper.GetRow (127, data));

			strips.Add (strip_trunk_dist);
			strips.Add (strip_trunk);
			strips.Add (strip_eglib);
			strips.Add (strip_rpm);
			strips.Add (strip_40);
			strips.Add (strip_26);
			strips.Add (strip_rpm_26);
			strips.Add (strip24);

			ViewData["PageTitle"] = "MonkeyWrench - Mono Extended Build Overview";

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
			commit.Email = UserHelpers.SvnUserToEmail (SvnGravatars.GetInstance (Server.MapPath ("~/Content/gravatars.txt")).Get (commit.Author));
			
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
					lane = 40;
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
					host = 2;
					return true;
				case "mono24|dist":
					lane = 60;
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
					host = 2;
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
			tv.Nodes.Add (new TreeViewNode ("Other Projects", "~/builds/other", "~/Media/bricks.png"));

			return tv;
		}
		#endregion
	}
}
