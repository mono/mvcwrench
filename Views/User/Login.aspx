<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
	MonkeyWrench - Log in
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% if (ViewData["Message"] != null) { %>
    <div style="border: solid 1px red">
        <%= Html.Encode(ViewData["Message"].ToString())%>
    </div>
    <% } %>
    
    <div class="center">
        <span style="font-size: 1.6em">To log in, or to register an account, enter your OpenID:</span>
        <br /><br /><br />
    
    <form action="Authenticate?ReturnUrl=<%=HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]) %>" method="post">
        <label for="openid_identifier">OpenID:</label>
        <input id="openid_identifier" name="openid_identifier" size="40" />
        <input id="openid_submit" type="submit" value="Login" />
    </form>
    
    <br /><br />
    Or click your OpenID provider:
    <div id="OIDother" style="padding-left: 195px;">
<%--        <a id="OIDnovell" onclick="document.getElementById('openid_identifier').value = 'http://novell.com/openid';document.getElementById('openid_submit').click()">Novell</a>--%>
        <a id="OIDgoogle" onclick="document.getElementById('openid_identifier').value = 'https://www.google.com/accounts/o8/id';document.getElementById('openid_submit').click()">Google</a>
        <a id="OIDyahoo" onclick="document.getElementById('openid_identifier').value = 'http://yahoo.com/';document.getElementById('openid_submit').click()">Yahoo!</a>
    </div>

    <script type="text/javascript">
        document.getElementById("openid_identifier").focus();
    </script>
</div>
</asp:Content>
