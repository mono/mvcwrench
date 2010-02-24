<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% 
    List<MvcWrench.Models.Tab> tabs = (List<MvcWrench.Models.Tab>)ViewData["TabMenu"];
%>
<ul>
<%   foreach (var tab in tabs) { %>  <li><a style="background-image: url(<%= Html.ResolveUrl (tab.Image) %>);" href="<%= Html.ResolveUrl (tab.Url) %>"><%= Html.Encode (tab.Name) %></a></li>
<%  } %></ul>