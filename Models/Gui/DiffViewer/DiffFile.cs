using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWrench.Models
{
	public class DiffFile
	{
		public string File { get; set; }
		public string LeftHeader { get; set; }
		public string RightHeader { get; set; }
		
		public List<DiffLine> Lines { get; private set; }

		public DiffFile (string file, string leftheader, string rightheader)
		{
			Lines = new List<DiffLine> ();
			
			File = file;
			LeftHeader = leftheader;
			RightHeader = rightheader;
		}
	}
}
