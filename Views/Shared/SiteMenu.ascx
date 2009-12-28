<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% 
    List<MvcWrench.Models.Tab> tabs = (List<MvcWrench.Models.Tab>)ViewData["TabMenu"];
%>
<ul>
<%   foreach (var tab in tabs) { %>  <li><a href="<%= Html.ResolveUrl (tab.Url) %>"><img src="<%= Html.ResolveUrl (tab.Image) %>" alt="<%= Html.Encode (tab.Name) %>" /><%= Html.Encode (tab.Name) %></a></li>
<%  } %></ul>