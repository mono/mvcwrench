<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	MonkeyWrench - Registration
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="center">
    <b>We can't find an account associated with the OpenID:</b><br />
    <i><%= (Model as MvcWrench.Models.User).OpenID %></i>
    <br /><br />
    <b>To create a MonkeyWrench account tied to this OpenID, please fill out the following fields:</b><br />
    
    <%= Html.ValidationSummary("Please correct the errors and try again.") %>
    <% using (Html.BeginForm ()) {
           MvcWrench.Models.User user = (MvcWrench.Models.User)Model; %>
        <p>
            <label for="Name">Username:</label><br />
            <%= Html.TextBox ("Name", user.Name, new { @class = "form-text" })%>
            <%= Html.ValidationMessage ("Name", "*")%>
        </p>
        <p>
            <label for="Email">Email:</label><br />
            <%= Html.TextBox("Email", user.Email, new { @class = "form-text" }) %>
            <%= Html.ValidationMessage("Email", "*") %>
        </p>
        <p>
            <input type="submit" value="Create Account" />
        </p>
    <% } %>
    
    <% Html.RenderPartial ("BlueBox", "If you want to associate this OpenID with an existing MonkeyWrench account, this will not do it.  That functionality is not available yet."); %>
</div>
</asp:Content>
