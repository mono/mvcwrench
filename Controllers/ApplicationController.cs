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
	public abstract class ApplicationController : Controller
	{
		private User current_user;

		protected override void OnActionExecuting (ActionExecutingContext filterContext)
		{
			if (User.Identity.IsAuthenticated) {
				User user = UserRepository.GetUser (User.Identity.Name);
				current_user = user;
				
				ViewData["CurrentUser"] = current_user;
			}
			
			base.OnActionExecuting (filterContext);
		}
		
		protected override void OnActionExecuted (ActionExecutedContext filterContext)
		{
			List<Tab> tabs = new List<Tab> ();

			tabs.Add (new Tab ("Home", "~/", "~/Media/house.png", 1));
			tabs.Add (new Tab ("Builds", "~/builds", "~/Media/bricks.png", 1));
			tabs.Add (new Tab ("Class Status", "~/status", "~/Media/chart_line.png", 1));

			ViewData["TabMenu"] = tabs;

			base.OnActionExecuted (filterContext);
		}
		
		public User CurrentUser { get { return current_user; } }
	}

}