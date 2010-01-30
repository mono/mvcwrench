<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	MonkeyWrench
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%">
      <tr style="vertical-align: top;">
        <td style="width:100%;">
          <% Html.RenderPartial ("RecentRevisions", ViewData["Revisions"]); %>
        </td>
        <td>
          <% Html.RenderPartial ("BugChart", Model); %>
          <% Html.RenderPartial ("BugList", Model); %>
        </td>
      </tr>
    </table>
</asp:Content>
