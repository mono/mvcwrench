<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcWrench.Models.BuildStepList>" %>


<table id="build-steps">
    <thead>
        <tr>
            <th colspan="2">Step</th>
            <th style="text-align: center">Results</th>
            <th style="text-align: center">Duration</th>
            <th colspan="2" style="text-align: left">Log/Hist</th>
        </tr>
    </thead>
    <tbody>
    <% foreach (var item in Model.Items) { %>
           
        <tr class="even <%= item.StatusClass %>">
            <td class="status-column <%= item.StatusClass %>"></td>
            <td style="width: 150px"><%= item.Name %></td>

            <td class="center-text"><%= item.Results %></td>
            <td class="center-text wide"><%= string.IsNullOrEmpty (item.LogUrl) ? "" : item.ElapsedTime.ToHoursMinSec ()%></td>
            <% if (string.IsNullOrEmpty (item.LogUrl)) { %>
            <td class="icon-column">&nbsp;</td>
            <% } else { %>
            <td class="icon-column"><a href="<%= item.LogUrl %>"><img src="<%= Html.ResolveUrl ("~/Media/report.png") %>" alt="View Log" title="View Log" /></a></td>
            <% } %>
            <td class="icon-column"><a href="<%= item.HistoryUrl %>"><img src="<%= Html.ResolveUrl ("~/Media/calendar.png") %>" alt="View Step History" title="View Step History" /></a></td>
        </tr>
     <%  } %>
    </tbody>
</table>
