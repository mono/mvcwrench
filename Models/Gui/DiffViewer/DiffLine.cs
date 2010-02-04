using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWrench.Models
{
	public class DiffLine
	{
		public int LeftLineNumber { get; set; }
		public string LeftLineText { get; set; }
		public int RightLineNumber { get; set; }
		public string RightLineText { get; set; }

		public DiffLineType Type { get; set; }

		public DiffLine (int left, string lefttext, int right, string righttext, DiffLineType type)
		{
			Type = DiffLineType.None;

			LeftLineNumber = left;
			LeftLineText = lefttext;
			RightLineNumber = right;
			RightLineText = righttext;

			if (type == DiffLineType.Change)
				Type = type;
			else if (left > 0 && right < 0)
				Type = DiffLineType.Delete;
			else if (left < 0 && right > 0)
				Type = DiffLineType.Add;
		}

		public string CssClass {
			get {
				switch (Type) {
					case DiffLineType.None:
					default:
						return "";
					case DiffLineType.Add:
						return "insert";
					case DiffLineType.Delete:
						return "delete";
					case DiffLineType.Change:
						return "replace";
				}
			}
		}
	}
}
