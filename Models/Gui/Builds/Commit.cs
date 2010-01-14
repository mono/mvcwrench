using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWrench.Models
{
	public class Commit
	{
		public string Revision { get; set; }
		public string Author { get; set; }
		public DateTime CommitTime { get; set; }
		public string Lane { get; set; }
		public string Host { get; set; }
		public string Builder { get; set; }
		public TimeSpan BuildDuration { get; set; }
		public string CommitLog { get; set; }
		public string Email { get; set; }
		public int CompletionStatus { get; set; }
		
		public string StatusText {
			get {
				switch (CompletionStatus) {
					case 1: return "In Progress";
					case 2: return "Build Failed";
					case 3: return "Success";
					case 4: return "Build Failed";
					case 5: return "Build Failed";
					case 6: case 8: return "Test(s) Failed";
					default:
						return "Queued";
				}
			}
		}
	}
}
