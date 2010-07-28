<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%--
This is what we are building...

<ul class="breadcrumb">
  <li><a href="/MonkeyWrench/builds">Projects</a></li>
  <li>Mono (Trunk)</li>
</ul>
--%>


<% MvcWrench.Models.BreadCrumb breadcrumb = (MvcWrench.Models.BreadCrumb)Model; %>

<ul class="breadcrumb">
<% foreach (MvcWrench.Models.Crumb crumb in breadcrumb.Crumbs) { %>
<%   if (!string.IsNullOrEmpty (crumb.Url)) { %>
  <li><a href="<%= Html.ResolveUrl (crumb.Url) %>"><%= Html.Encode (crumb.Text)%></a></li>
<%   } else { %>
  <li><%= Html.Encode (crumb.Text)%></li>
<%   } %>
<% } %>
</ul>
