<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Builds/Builds.Master" Inherits="System.Web.Mvc.ViewPage<MvcWrench.MonkeyWrench.Public.Revision>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["PageTitle"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="right_content_placeholder" runat="server">
<div class="right-content-pad">
<% if (Model != null) { %>
    <div id="commit">
            <div class="human" style="width: 100%">
                <div class="revision">
                  Revision <%= Model.RevisionNumber%>
                </div>
                <div class="actor">
                    <div class="gravatar">
                        <img alt="" src="<%= MvcWrench.UserHelpers.EmailToGravatar (MvcWrench.Models.SvnGravatars.Get (Model.Author), 30) %>" />
                    </div>
                    <div class="name"><%= Model.Author %></div>
                    <div class="date">about <%= (DateTime.Now.Subtract (new TimeSpan (1, 0, 0)) - Model.Time).ToFriendlySpan ()%> ago</div>
                </div>
               <pre><%= Html.Encode (Model.SvnLog.TrimEnd ())%></pre>
            </div>
        </div>
<% } %>
<% if ((ViewData["Diff"]).GetType () == typeof(string)) { %>
<br /><%= ViewData["Diff"] %>
<% } else { %>
<% Html.RenderPartial ("DiffViewControl", ViewData["Diff"]); %>
<% } %>
</div>
</asp:Content>
