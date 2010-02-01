<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcWrench.MonkeyWrench.Public.Revision[]>" %>

<% foreach (var item in Model) { %>
    <div id="commit" style="margin-left: 10px;">
            <div class="human" style="width: 100%">
                <div class="revision">Revision <%= item.RevisionNumber %></div>
                <div class="actor">
                    <div class="gravatar">
                        <img alt="" src="<%= MvcWrench.UserHelpers.EmailToGravatar (item.Author, 30) %>" />
                    </div>
                    <div class="name"><%= item.Author %></div>
                    <div class="date"><%= item.Time.ToString () %></div>
                </div>
               <pre><%= Html.Encode (item.SvnLog.TrimEnd ()) %></pre>
            </div>
        </div>
<% } %>
