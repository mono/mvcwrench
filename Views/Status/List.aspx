<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Status/Status.Master" Inherits="System.Web.Mvc.ViewPage<MvcWrench.Models.StatusProfile>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	MonkeyWrench - Class Status - <%= Model.Name %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="right_content_placeholder" runat="server">
<ul>
<% foreach (string assem in Model.Assemblies) { %>
<li><a href="<%= Html.ResolveUrl (string.Format ("~/status/{0}/{1}/{2}", Model.Reference, Model.Profile, assem)) %>"><%= assem %></a></li>
<% } %>
</ul>
</asp:Content>
