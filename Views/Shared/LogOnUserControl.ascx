<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
      MvcWrench.Models.User CurrentUser = (MvcWrench.Models.User)ViewData["CurrentUser"];
%>
<div class="userimage">
    <img alt="user gravatar" src="<%= CurrentUser.GetGravatar (32) %>" />
</div>
<div class="usertext">
    <b><%= Html.Encode (CurrentUser.Name)%></b>
    <br />
    <span style="font-size: .8em"><%= Html.ActionLink("Profile", "profile", "user") %> | 
    <%= Html.ActionLink("Logout", "logout", "user") %></span>
</div>
<%
    } else {
%>
<%= Html.ActionLink("Sign in / Create account", "login", "user") %>
<%
    }
%>
