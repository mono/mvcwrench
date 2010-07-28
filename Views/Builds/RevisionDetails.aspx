<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Builds/Builds.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["PageTitle"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="right_content_placeholder" runat="server">
<div class="right-content-pad">
    <% Html.RenderPartial ("CommitHeader", ViewData["commit"]); %>
    <% Html.RenderPartial ("BuildStepTable", ViewData["steps"]); %>
<%--    <table id="build-steps">
        <thead>
            <tr>
                <th colspan="2">Step</th>
                <th style="text-align: center">Duration</th>
                <th style="text-align: center">Results</th>
                <th colspan="2" style="text-align: left">Log</th>
            </tr>
        </thead>
        <tbody>
            <tr class="even">
                <td class="status-column"></td>
                <td style="width: 500px">build</td>

                <td class="center-text wide">22 minutes</td>
                <td class="center-text wide">3 Tests Failed</td>
                <td class="icon-column"><img src="<%= Html.ResolveUrl ("~/Media/report.png") %>" alt="View Log" title="View Log" /></td>
                <td class="icon-column"><img src="<%= Html.ResolveUrl ("~/Media/calendar.png") %>" alt="View Step History" title="View Step History" /></td>
            </tr>
            <tr class="odd">
                <td class="status-column"></td>
                <td>build</td>

                <td class="center-text">22 minutes</td>
                <td class="center-text"></td>
                <td class="icon-column"><img src="<%= Html.ResolveUrl ("~/Media/report.png") %>" /></td>
                <td class="icon-column"><img src="<%= Html.ResolveUrl ("~/Media/calendar.png") %>" /></td>
            </tr>

            <tr class="even">
                <td class="status-column"></td>
                <td>build</td>

                <td class="center-text">22 minutes</td>
                <td class="center-text"></td>
                <td class="icon-column"><img src="<%= Html.ResolveUrl ("~/Media/report.png") %>" /></td>
                <td class="icon-column"><img src="<%= Html.ResolveUrl ("~/Media/calendar.png") %>" /></td>
            </tr>
            <tr class="odd">
                <td class="status-column"></td>
                <td>build</td>

                <td class="center-text">22 minutes</td>
                <td class="center-text"></td>
                <td class="icon-column"><img src="<%= Html.ResolveUrl ("~/Media/report.png") %>" /></td>
                <td class="icon-column"><img src="<%= Html.ResolveUrl ("~/Media/calendar.png") %>" /></td>
            </tr>
            <tr class="even">
                <td class="status-column"></td>
                <td>build</td>

                <td class="center-text">22 minutes</td>
                <td class="center-text"></td>
                <td class="icon-column"><img src="<%= Html.ResolveUrl ("~/Media/report.png") %>" /></td>
                <td class="icon-column"><img src="<%= Html.ResolveUrl ("~/Media/calendar.png") %>" /></td>
            </tr>
        </tbody>
    </table>
--%></div>
</asp:Content>
