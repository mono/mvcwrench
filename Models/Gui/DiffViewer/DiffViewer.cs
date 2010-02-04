using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace MvcWrench.Models
{
	public class DiffViewer
	{
		public List<DiffFile> Files { get; private set; }
		
		public DiffViewer (string diff)
		{
			Files = new List<DiffFile> ();
		
			ParseDiff (diff);
		}
		
		private void ParseDiff (string diff)
		{
			StringReader sr = new StringReader (diff);
			
			// Initialize some stuff
			string s;
			int leftline = 0;
			int rightline = 0;
			bool first_file = true;
			bool first_chunk = true;

			DiffFile file = null;

			while ((s = sr.ReadLine ()) != null) {
				if (s.StartsWith ("Index:")) {
					if (!first_file) {
						Files.Add (file);						
					}
					
					file = new DiffFile (s.Substring (7), string.Empty, string.Empty);
					first_file = false;
					first_chunk = true;
				} else if (s == "===================================================================") {

				} else if (s == "___________________________________________________________________") {

				} else if (s.StartsWith ("---")) {
					file.LeftHeader = s.Substring (s.IndexOf ("(") + 1).TrimEnd (')');
				} else if (s.StartsWith ("+++")) {
					file.RightHeader = s.Substring (s.IndexOf ("(") + 1).TrimEnd (')');
				} else if (s.StartsWith ("@@")) {
					leftline = int.Parse (s.Substring (s.IndexOf ('-') + 1, s.IndexOf (',') - s.IndexOf ('-') - 1));

					try {
						rightline = int.Parse (s.Substring (s.IndexOf ('+') + 1, s.IndexOf (',', s.IndexOf (',') + 1) - s.IndexOf ('+') - 1));
					} catch (ArgumentException) {
						// I think this means the file was deleted, and replaced with completely new content..
						rightline = 0;
					}

					if (!first_chunk)
						file.Lines.Add (new DiffLine (-1, "&nbsp;", -1, "&nbsp;", DiffLineType.None));

					first_chunk = false;
				} else if (s.Length == 0) {

				} else if (s.StartsWith ("-")) {
					if ((char)sr.Peek () == '+') {
						file.Lines.Add (new DiffLine (leftline, s.Substring (1), rightline, sr.ReadLine ().Substring (1), DiffLineType.Change));
						leftline++;
						rightline++;
					} else {
						file.Lines.Add (new DiffLine (leftline, s.Substring (1), -1, string.Empty, DiffLineType.None));
						leftline++;
					}
				} else if (s.StartsWith ("+")) {
					file.Lines.Add (new DiffLine (-1, string.Empty, rightline, s.Substring (1), DiffLineType.None));
					rightline++;
				} else if (s.StartsWith ("Cannot display") || s.StartsWith ("Property changes") || s.StartsWith ("Deleted:")) {
					//StartTable (writer, filename, "", "");
				} else {
					file.Lines.Add (new DiffLine (leftline, s, rightline, s, DiffLineType.None));
					leftline++;
					rightline++;
				}
			}

			if (file != null)
				Files.Add (file);
		}
	}
}
