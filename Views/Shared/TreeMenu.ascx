<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% 
    MvcWrench.Models.TreeViewModel model = (MvcWrench.Models.TreeViewModel)Model;
%>
<ul>
  <li>
    <% foreach (MvcWrench.Models.TreeViewNode node in model.Nodes) { %>
    <span class="<%= node.Nodes.Count > 0 ? node.Expanded ? "collapse" : "expand" : "none" %>" onclick="<%= node.Nodes.Count > 0 ? string.Format ("ToggleVisibility(this, '{0}')", node.ID) : "#" %>">&nbsp;</span>
    <% if (!string.IsNullOrEmpty (node.Url)) { %>  <a href="<%= Html.ResolveUrl (node.Url) %>"><img src="<%= Html.ResolveUrl (node.ImageUrl) %>" title="<%= Html.Encode (node.ImageToolTip) %>" /><%= Html.Encode (node.Text) %></a><br /><% } %>
        <ul id="<%= node.ID %>" style="<%= node.Expanded ? "" : "display: none;" %>">
        <%   foreach (var child in node.Nodes) { %>
          <li class="leaf"><span>&nbsp;</span><% if (!string.IsNullOrEmpty (child.Url)) { %><a href="<%= Html.ResolveUrl (child.Url) %>"><% } %><% if (!string.IsNullOrEmpty (child.ImageUrl)) { %><img src="<%= Html.ResolveUrl (child.ImageUrl) %>" title="<%= Html.Encode (child.ImageToolTip) %>" /><% } %><%= Html.Encode (child.Text)%><% if (!string.IsNullOrEmpty (child.Url)) { %></a><% } %></li>
        <%  } %>
    </ul>           
    <% } %>

  </li>
</ul>
