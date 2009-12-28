<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Builds/Builds.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["PageTitle"] %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="right_content_placeholder" runat="server">
<div class="right-content-pad">
<% foreach (MvcWrench.Models.StatusStrip strip in (List<MvcWrench.Models.StatusStrip>)Model) {
    Html.RenderPartial ("StatusStrip", strip); %>
           <br />
    <% } %>
</div>
</asp:Content>

