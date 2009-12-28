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
using System.Web.Mvc.Ajax;
using MvcWrench.Models;

namespace MvcWrench.Controllers
{
	public class StatusController : ApplicationController
	{
		//
		// GET: /Status/
		public ActionResult Class (string assembly, string profile, string reference)
		{
			string iframe = string.Format ("http://go-mono.com/status/status.aspx?reference={0}&profile={1}&assembly={2}", reference, profile, assembly);

			foreach (TreeViewNode node in (ViewData["TreeView"] as TreeViewModel).Nodes) {
				if (node.Tag.ToString () == string.Format ("{0}|{1}", profile, reference))
					node.Expanded = true;
			}
			
			return View ("Class", (object)iframe);
		}

		public ActionResult List (string profile, string reference)
		{
			foreach (TreeViewNode node in (ViewData["TreeView"] as TreeViewModel).Nodes) {
				if (node.Tag.ToString () == string.Format ("{0}|{1}", profile, reference))
					node.Expanded = true;
			}
			
			return View ("List", ClassStatus.GetInstance (Server.MapPath ("~/Content/classstatus.xml")).Profiles.Where (p => p.Profile == profile && p.Reference == reference).FirstOrDefault ());

		}

		public ActionResult Index ()
		{
			return View ("Index", ClassStatus.GetInstance (Server.MapPath ("~/Content/classstatus.xml")));

		}

		#region Global Data
		protected override void OnActionExecuting (ActionExecutingContext filterContext)
		{
			ViewData["TreeView"] = CreateBuildsTree ();

			base.OnActionExecuting (filterContext);
		}

		private TreeViewModel CreateBuildsTree ()
		{
			ClassStatus status = ClassStatus.GetInstance (Server.MapPath ("~/Content/classstatus.xml"));

			TreeViewModel tv = new TreeViewModel ();

			foreach (var profile in status.Profiles) {
				TreeViewNode node = new TreeViewNode (profile.Name, string.Format ("~/status/{0}/{1}", profile.Profile, profile.Reference), string.Format ("~/Media/{0}", profile.Icon));
				node.Expanded = false;
				node.Tag = string.Format ("{0}|{1}", profile.Profile, profile.Reference);
				
				foreach (string assem in profile.Assemblies)
					node.Nodes.Add (CreateNode (assem, profile.Profile, profile.Reference));

				tv.Nodes.Add (node);
			}

			return tv;
		}
		
		private static TreeViewNode CreateNode (string assembly, string profile, string reference)
		{
			return new TreeViewNode (assembly, string.Format ("~/status/{0}/{1}/{2}", profile, reference, assembly), "~/Media/assembly.png");
		}
		
		#endregion
	}

}
