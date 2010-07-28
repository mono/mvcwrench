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
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcWrench
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes (RouteCollection routes)
		{
			routes.IgnoreRoute ("{resource}.axd/{*pathInfo}");

			// Builds
			routes.MapRoute ("BuildsMsvcLog", "builds/msvc/{buildrevisionid}/{completedstepid}", new { controller = "Builds", action = "BuildStatusLog", id = "" });
			routes.MapRoute ("BuildsMonoExtended", "builds/monoextended", new { controller = "Builds", action = "MonoExtended", id = "" });
			routes.MapRoute ("BuildsOther", "builds/other", new { controller = "Builds", action = "Other", id = "" });
			routes.MapRoute ("BuildsMonoRevision", "builds/{project}/{platform}/{revision}", new { controller = "Builds", action = "RevisionDetails", id = "" });
			routes.MapRoute ("BuildsMsvc", "builds/msvc/{buildrevisionid}", new { controller = "Builds", action = "BuildStatus", id = "" });
			routes.MapRoute ("BuildsMonoRevisionDiff", "builds/{project}/{revision}", new { controller = "Builds", action = "RevisionDiff", id = "" });
			routes.MapRoute ("BuildsMonoDevelop", "builds/monodevelop", new { controller = "Builds", action = "MonoDevelop", id = "" });
			routes.MapRoute ("BuildsMono", "builds/mono", new { controller = "Builds", action = "Index", id = "" });
			routes.MapRoute ("BuildsOverview", "builds", new { controller = "Builds", action = "Index", id = "" });

			// Status
			routes.MapRoute ("StatusDisplay", "status/{profile}/{reference}/{assembly}", new { controller = "Status", action = "Class" });
			routes.MapRoute ("StatusList", "status/{profile}/{reference}", new { controller = "Status", action = "List" });
			routes.MapRoute ("Status", "status", new { controller = "Status", action = "Index" });

			// Bugs
			routes.MapRoute ("addtestcase", "bugs/view/{id}/addtestcase", new { controller = "Bugs", action = "AddTestCase" });
			
			
			routes.MapRoute ("User", "user/{action}", new { controller = "User", action = "Index" });
			routes.MapRoute ("UserID", "user/{action}/{id}", new { controller = "User", action = "Index" });
			
			routes.MapRoute (
			    "Default",                                              // Route name
			    "{controller}/{action}/{id}",                           // URL with parameters
			    new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
			);

		}

		protected void Application_Start ()
		{
			RegisterRoutes (RouteTable.Routes);
		}

		protected void Application_EndRequest (object sender, EventArgs e)
		{
			
		}

	}
}