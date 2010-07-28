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

using System.Collections.Generic;

namespace MvcWrench.Models
{
	public class StatusStrip
	{
		public string Name { get; set; }
		public string Url { get; set; }
		public List<StatusStripRow> Rows { get; private set; }
		
		public StatusStrip ()
		{
			Rows = new List<StatusStripRow> ();
		}

		public StatusStrip (string name) : this ()
		{
			Name = name;
		}
	}
	
	public class StatusStripRow
	{
		public string HeaderText { get; set; }
		public string HeaderUrl { get; set; }
		public bool IsHeader { get; set; }
		
		public List<StatusStripCell> Cells { get; private set; }

		public StatusStripRow ()
		{
			Cells = new List<StatusStripCell> ();
		}
	}
	
	public class StatusStripCell
	{
		public string Text { get; set; }
		public int Status { get; set; }
		public string Url { get; set; }
		public bool IsHeader { get; set; }
		
		public string GetCss (StatusStripCell next)
		{
			if (IsHeader && next == null)
				return "cell-header stripend";
			else if (IsHeader)
				return "cell-header";
				
			string css1 = StatusToCss (Status);
			string css2 = string.Empty;
			
			if (next == null)
				css2 = "stripend";
			else if (string.IsNullOrEmpty (Text) && string.IsNullOrEmpty (next.Text))
				return string.Format ("{0}", css1);
			else
				css2 = GetTransitionClass (this, next);
				
			return string.Format ("{0} {1}", css1, css2);
			
			
		}
		
		private string StatusToCss (int status)
		{
			switch (status) {
				case 1: return "executing";
				case 0: return "notrun";
				case 2: return "fail";
				case 3: return "success";
				case 4: return "fail";
				case 5: return "fail";
				case 6: return "testfail";
				default:
					return "notrun";
			}
		}
		
		private string GetTransitionClass (StatusStripCell cell1, StatusStripCell cell2)
		{
			return string.Format ("{0}_{1}", GetStatusColor (cell1.Status), GetStatusColor (cell2.Status));
		}
		
		public static string GetStatusColor (int status)
		{
			switch (status) {
				case 1: return "y";
				case 0: return "gr";
				case 2: return "r";
				case 3: return "g";
				case 4: return "r";
				case 5: return "r";
				case 6: return "o";
				default:
					return "gr";
			}
		}
	}
}
