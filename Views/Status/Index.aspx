<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Status/Status.Master" Inherits="System.Web.Mvc.ViewPage<MvcWrench.Models.ClassStatus>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	MonkeyWrench - Class Status
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="right_content_placeholder" runat="server">
<ul>
<% foreach (MvcWrench.Models.StatusProfile profile in Model.Profiles) { %>
<li><a href="<%= Html.ResolveUrl (string.Format ("~/status/{0}/{1}", profile.Profile, profile.Reference)) %>"><%= profile.Name%></a></li>
<% } %>
</ul>
</asp:Content>
