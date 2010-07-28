<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Status/Status.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	MonkeyWrench - Class Status
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="right_content_placeholder" runat="server">
<iframe src="<%= Model %>" width="100%" height="100%" frameborder="0" style="margin-bottom: -5px;">
  <p>Your browser does not support iframes.</p>
</iframe>
</asp:Content>
