<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	MonkeyWrench
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%">
      <tr style="vertical-align: top;">
        <td style="width:100%; padding: 20px 0 0 20px;">
          See recent commits on <a href="http://github.com/mono/mono/commits/master">GitHub</a>.
<%--          <% Html.RenderPartial ("RecentRevisions", ViewData["Revisions"]); %>
--%>        </td>
        <td>
          <% if (!string.IsNullOrEmpty ((string)ViewData["BugCounts"])) Html.RenderPartial ("BugChart", (string)ViewData["BugCounts"]);  %>
          <% Html.RenderPartial ("BugList", Model); %>
        </td>
      </tr>
    </table>
</asp:Content>
