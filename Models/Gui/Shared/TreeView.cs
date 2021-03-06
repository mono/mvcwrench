﻿//
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

namespace MvcWrench.Models
{
	public class TreeViewModel
	{
		public List<TreeViewNode> Nodes { get; private set; }

		public TreeViewModel ()
		{
			Nodes = new List<TreeViewNode> ();
		}
	}

	public class TreeViewNode
	{
		private static int id_count = 0;

		public string Text { get; set; }
		public string Url { get; set; }
		public string ImageUrl { get; set; }
		public string ImageToolTip { get; set; }
		public string ID { get; private set; }
		public bool Expanded { get; set; }
		public object Tag { get; set; }

		public List<TreeViewNode> Nodes { get; private set; }

		public TreeViewNode ()
		{
			Nodes = new List<TreeViewNode> ();
			Expanded = true;

			ID = string.Format ("tvn{0}", id_count++);

			if (id_count >= 9999)
				id_count = 0;
		}

		public TreeViewNode (string text, string url, string imageurl)
			: this ()
		{
			Text = text;
			Url = url;
			ImageUrl = imageurl;
		}

		public TreeViewNode (string text, string url, string imageurl, string tooltip)
			: this (text, url, imageurl)
		{
			ImageToolTip = tooltip;
		}
	}
}
