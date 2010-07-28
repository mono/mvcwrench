<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<MvcWrench.BugzillaEntry>>" %>
<div class="buglist">
<div class="bugtitle"><a href="http://www.mono-project.com/Bugs">Latest Reported Bugs</a></div>
<table cellspacing="5">
<% foreach (var item in Model) { %>
    <tr>
        <td><a href="<%= item.Url %>"><img alt="bug" src="<%= ResolveClientUrl ("~/Media/bug.png") %>" /></a></td>
        <td class="<%= item.Status == MvcWrench.BugzillaStatus.Resolved ? "strike" : "" %>"><a href="<%= item.Url %>"><%= item.Title %></a></td>
    </tr>
<% } %>
</table>
</div>