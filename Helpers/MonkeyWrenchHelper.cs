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
using MvcWrench.Models;
using MvcWrench.mono_build;
using MvcWrench.MonkeyWrench.Public;

namespace MvcWrench
{
	public class MonkeyWrenchHelper
	{
		private static string rev_link = "http://build.mono-project.com/ViewLane.aspx?lane_id={0}&host_id={1}&revision_id={2}";
		private static string host_link = "http://build.mono-project.com/ViewTable.aspx?lane_id={0}&host_id={1}";
		
		public static void ListWorkItems (FrontPageResponse data)
		{
			
			foreach (int item in data.RevisionWorkHostLaneRelation) {
				DBHostLane dbhostlane = data.HostLanes.Where (p => p.id == item).FirstOrDefault ();
				DBLane dblane = data.Lanes.Where (p => p.id == dbhostlane.lane_id).FirstOrDefault ();
				DBHost dbhost = data.Hosts.Where (p => p.id == dbhostlane.host_id).FirstOrDefault ();

				System.Diagnostics.Trace.WriteLine (string.Format ("HostLane: {0} - Lane: {1} - Host: {2}", dbhostlane.id, dblane.lane, dbhost.host));
			}
			
		}
		
		public static StatusStripRow GetRow (int hostlane, FrontPageResponse data)
		{
			return GetRow (hostlane, data, "LOOKUP");
		}
		
		public static StatusStripRow GetRow (int hostlane, FrontPageResponse data, string header)
		{
			StatusStripRow row = new StatusStripRow ();
			try {
			DBHostLane dbhostlane = data.HostLanes.Where (p => p.id == hostlane).FirstOrDefault ();
			DBLane dblane = data.Lanes.Where (p => p.id == dbhostlane.lane_id).FirstOrDefault ();
			DBHost dbhost = data.Hosts.Where (p => p.id == dbhostlane.host_id).FirstOrDefault ();
			
			int index = data.RevisionWorkHostLaneRelation.ToList ().IndexOf (dbhostlane.id);
			
			DBRevisionWorkView2[] revs = data.RevisionWorkViews[index];
			IEnumerable<DBRevisionWorkView2> revisions = revs.Take (10);

			foreach (DBRevisionWorkView2 r in revisions) {
				StatusStripCell cell = new StatusStripCell ();
				cell.Text = r.revision;
				cell.Status = ConvertState (r.state);

                if ((r.state == 3 || r.state == 8) && !r.completed)
                    cell.Status = 1;

				cell.Url = string.Format (rev_link, dblane.id, dbhost.id, r.revision_id);
				
				row.Cells.Add (cell);
			}

			if (header == "LOOKUP")
				row.HeaderText = dbhost.host;
			else
				row.HeaderText = header;
				
			row.HeaderUrl = string.Format (host_link, dblane.id, dbhost.id);

			while (row.Cells.Count < 10)
				row.Cells.Add ((new StatusStripCell () { Text = string.Empty, Status = 0 }));

			return row;
			} catch {
				throw new Exception (string.Format ("Hostlane {0} no longer exists", hostlane));
			}
		}
		
		public static StatusStripRow GetRow (BuildRevision[] revs)
		{
			StatusStripRow row = new StatusStripRow ();
			row.HeaderText = "msvc: windows";

			foreach (var item in revs) {
				StatusStripCell cell = new StatusStripCell ();
				cell.Text = string.Format ("{0}", item.RevisionNumber);
				cell.Status = item.Status;

				cell.Url = string.Format ("~/builds/msvc/{0}", item.Id);

				row.Cells.Add (cell);
			}
			
			return row;
		}

		public static StatusStripRow GetHeaderRow (BuildRevision[] revs)
		{
			StatusStripRow row = new StatusStripRow ();
			row.IsHeader = true;
			row.HeaderText = "Mono - Trunk";

			foreach (var item in revs) {
				StatusStripCell cell = new StatusStripCell ();
				cell.Text = item.Author;
				//cell.Status = item.Status;

				//cell.Url = string.Format ("~/builds/msvc/{0}", item.Id);
				cell.IsHeader = true;
				row.Cells.Add (cell);
			}

			return row;
		}
		
		private static int ConvertState (int state)
		{
			// 0 not done, 1 executing, 2 failed, 3 success, 4 aborted, 5 timeout, 6 testfail
			switch (state) {
				case 0:	case 9: return 0;
				case 1: return 1;
				case 2: return 2;
				case 3: return 3;
				case 8:	return 6;
				
				default:
					return 0;
			}
		}
	}
}
