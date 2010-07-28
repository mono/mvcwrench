<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%--
This is what we are building...

<table class="steplist">
  <thead>
    <tr>
      <th scope="col" style="width:16;"></th><th scope="col" style="width:550px;">Step</th><th scope="col" style="width:140px;text-align:center;">Elapsed Time</th><th scope="col" style="width:20px;">Log</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><img src="/MonkeyWrench/Media/pass.png" /></td><td>Update mono to revision</td><td style="text-align:center;">00:00:02</td><td><a href="/MonkeyWrench/BuildPages/ViewLog.aspx?id=31538"><img src="/MonkeyWrench/Media/report.png" /></a></td>
    </tr>
    <tr>
      <td><img src="/MonkeyWrench/Media/pass.png" /></td><td>Copy svn tree to workspace</td><td style="text-align:center;">00:00:07</td><td><a href="/MonkeyWrench/BuildPages/ViewLog.aspx?id=31539"><img src="/MonkeyWrench/Media/report.png" /></a></td>
    </tr>
  </tbody>
  <tfoot>
    <tr>
      <td scope="col" style="width:16;"></td><td scope="col" style="width:550px;">Total</td><td scope="col" style="width:140px;text-align:center;">00:00:00</td><td scope="col" style="width:20px;"></td>
    </tr>
  </tfoot>
</table>
--%>

<% MvcWrench.Models.BuildStepList list = (MvcWrench.Models.BuildStepList)Model; %>

<table class="steplist">
  <thead>
    <tr><%--<th scope="col" style="width:140px;text-align:center;">Elapsed Time</th>--%>
      <th scope="col" style="width:16;"></th><th scope="col" style="width:690px;">Step</th><th scope="col" style="width:20px;">Log</th>
    </tr>
  </thead>
  <tbody>
<% foreach (MvcWrench.Models.BuildStepListItem item in list.Items) { %>
    <tr>
      <td><img src="<%= Html.ResolveUrl (item.Image) %>" /></td>
      <td><%= item.Name %></td>
<%--      <td style="text-align:center;"><%= string.Format ("{0}:{1}:{2}", item.ElapsedTime.Hours.ToString ().PadLeft (2, '0'), item.ElapsedTime.Minutes.ToString ().PadLeft (2, '0'), item.ElapsedTime.Seconds.ToString ().PadLeft (2, '0')) %></td>
--%>      <td><a href="<%= Html.ResolveUrl (item.LogUrl) %>"><img src="<%= Html.GetImage ("report.png") %>" /></a></td>
    </tr>
<% } %>
<%--  <tfoot>
    <tr>
      <td scope="col" style="width:16;"></td>
      <td scope="col" style="width:550px;">Total</td>
     <td scope="col" style="width:140px;text-align:center;"><%= string.Format ("{0}:{1}:{2}", list.TotalTime.Hours.ToString ().PadLeft (2, '0'), list.TotalTime.Minutes.ToString ().PadLeft (2, '0'), list.TotalTime.Seconds.ToString ().PadLeft (2, '0'))%></td>
      <td scope="col" style="width:20px;"></td>
    </tr>
  </tfoot>--%>
</table>
