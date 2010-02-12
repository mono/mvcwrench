<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcWrench.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    MonkeyWrench - Edit Profile
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding-left: 15px; font-size: 12pt;">
    <h1>Your Profile</h1>
    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>
    <% using (Html.BeginForm ()) { %>
    <table width="600" cellpadding="5px">
        <%= Html.Hidden ("ID", Model.ID) %>
        <%= Html.Hidden ("Name", Model.Name)%>
        <tr>
            <td>Username</td>
            <td><%= Model.IsNovell ? string.Format ("<img src=\"{0}\" />", Html.ResolveUrl ("~/Media/novell16.png")) : "" %> <%= Model.Name %> </td>
        </tr>
        <tr>
            <td style="vertical-align: top;">Email</td>
            <td>
                <%= Html.TextBox ("Email", Model.Email, new { @class = "form-text", style = "width: 260px;" }) %>
                <%= Html.ValidationMessage ("Email", "*") %>
                <div class="form-item-info">notifications</div>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top;">
                Gravatar
            </td>
            <td>
                <%= Html.TextBox ("Gravatar", Model.Gravatar, new { @class = "form-text", style = "width: 260px;" })%>
                <%= Html.ValidationMessage ("Gravatar", "*")%>
                <div class="form-item-info">optional, email used to get your <a href="http://www.gravatar.com/" target="_blank">Gravatar</a></div>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top;">
                Svn Account
            </td>
            <td>
                <%= Html.TextBox ("SvnAccount", Model.SvnAccount, new { @class = "form-text", style = "width: 260px;" })%>
                <%= Html.ValidationMessage ("SvnAccount", "*")%>
                <div class="form-item-info">optional, if you have a <a href="http://mono-project.com/SVN" target="_blank">Mono SVN</a> account</div>
            </td>
        </tr>
    </table>
    <input type="submit" value="Save" />
    <% } %>
    </div>
</asp:Content>
