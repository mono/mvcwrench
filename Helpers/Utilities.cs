using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWrench
{
	static class Utilities
	{
		public static string FormatRevision (string revision)
		{
			if (string.IsNullOrEmpty (revision))
				return revision;

			// This is likely a SVN revision
			if (revision.Length <= 6)
				return string.Format ("r{0}", revision);

			// This is likely a GIT revision
			return revision.Substring (0, 7);
		}
	}
}
