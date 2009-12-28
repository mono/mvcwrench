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
using System.Security.Principal;
using System.Web.Mvc;
using MvcWrench.Models;

public static class IncludeExtensions
{
	public static string IncludeCSS (this HtmlHelper html, string cssFile)
	{
		string cssPath = cssFile.Contains ("~") ? cssFile : ("~/Media/" + cssFile);
		string url = html.ResolveUrl (cssPath);
		return string.Format ("<link type=\"text/css\" rel=\"stylesheet\" href=\"{0}\" />\n", url);
	}

	public static string IncludeJS (this HtmlHelper html, string jsFile)
	{
		string jsPath = jsFile.Contains ("~") ? jsFile : ("~/Media/" + jsFile);
		string url = html.ResolveUrl (jsPath);
		return string.Format ("<script type=\"text/javascript\" src=\"{0}\"></script>\n", url);
	}

	public static string IncludeFavicon (this HtmlHelper html, string icon)
	{
		string iconPath = icon.Contains ("~") ? icon : ("~/" + icon);
		string url = html.ResolveUrl (iconPath);
		return string.Format ("<link rel=\"shortcut icon\" href=\"{0}\" />\n", url);
	}

	public static string IncludeScript (this HtmlHelper html, string script)
	{
		return string.Format ("<script type=\"text/javascript\">{0}</script>\n", script);
	}

	public static string ResolveUrl (this HtmlHelper html, string relativeUrl)
	{
		if (relativeUrl == null) { return null; }
		if (!relativeUrl.StartsWith ("~")) { return relativeUrl; }

		return (html.ViewContext.HttpContext.Request.ApplicationPath + relativeUrl.Substring (1)).Replace ("//", "/");
	}

	public static string GetImage (this HtmlHelper html, string image)
	{
		return (html.ResolveUrl (string.Format ("~/Media/{0}", image)));
	}

	public static string GetImage (this HtmlHelper html, bool conditional, string trueImage, string falseImage)
	{
		if (conditional)
			return html.GetImage (trueImage);
		else
			return html.GetImage (falseImage);
	}
}
