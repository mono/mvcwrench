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

namespace MvcWrench.Controllers
{
	public class BuildsController : ApplicationController
	{
		// GET: /Builds/Official
		public ActionResult Index ()
		{
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
