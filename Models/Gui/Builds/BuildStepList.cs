﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWrench.Models
{
	public class BuildStepList
	{
		public List<BuildStepListItem> Items { get; private set; }

		public TimeSpan TotalTime
		{
			get
			{
				TimeSpan ts = TimeSpan.Zero;

				foreach (BuildStepListItem item in Items) {
					ts += item.ElapsedTime;
				}

				return ts;
			}
		}

		public BuildStepList ()
		{
			Items = new List<BuildStepListItem> ();
		}
	}

	public class BuildStepListItem
	{
		public long BuildStepID { get; set; }
		public TimeSpan ElapsedTime { get; set; }
		public int ExitCode { get; set; }
		public int CompletionStatus { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public string LogUrl { get; set; }
		public string HistoryUrl { get; set; }
		public string Results { get; set; }

		public BuildStepListItem ()
		{
			Image = "~/Media/pass.png";
		}

		public BuildStepListItem (long id, TimeSpan time, int exitCode, int status, string name)
		{
			BuildStepID = id;
			ElapsedTime = time;
			ExitCode = exitCode;
			CompletionStatus = status;
			Name = name;

			switch (status) {
				case 3:
					Image = "~/Media/pass.png";
					break;
				case 6:
					Image = "~/Media/error.png";
					break;
				default:
					Image = "~/Media/fail.png";
					break;
			}
		}

		public string StatusClass {
			get {
				switch (CompletionStatus) {
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
		}
	}
}
