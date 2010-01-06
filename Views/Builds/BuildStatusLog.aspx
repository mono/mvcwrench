<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Builds/Builds.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["PageTitle"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="right_content_placeholder" runat="server">
<%--<% Html.RenderPartial ("BreadCrumbBar", ViewData["BreadCrumb"]); %>
--%><div class="right-content-pad">
<pre>
<%= Html.Encode (ViewData["Log"])%>
</pre>
</div>
</asp:Content>
