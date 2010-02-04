<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcWrench.MonkeyWrench.Public.Revision[]>" %>

<% foreach (var item in Model) { %>
    <div id="commit" style="margin-left: 10px;">
            <div class="human" style="width: 100%">
                <div class="revision">
                  Revision <%= item.RevisionNumber %><br />
                  <div style="text-align: right"><table style="margin-left: 29px;"><tr><td><a href="<%= Html.ResolveUrl (string.Format ("~/builds/mono/{0}", item.RevisionNumber)) %>"><img src="<%= Html.ResolveUrl ("~/Media/diff.png") %>" alt="View Diff" /></a></td><td><a href="<%= Html.ResolveUrl (string.Format ("~/builds/mono/{0}", Model.RevisionNumber)) %>" style="font-weight: normal;">View Diff</a></td></tr></table></div>
                </div>
                <div class="actor">
                    <div class="gravatar">
                        <img alt="" src="<%= MvcWrench.UserHelpers.EmailToGravatar (MvcWrench.Models.SvnGravatars.GetInstance (Server.MapPath ("~/Content/gravatars.txt")).Get (item.Author), 30) %>" />
                    </div>
                    <div class="name"><%= item.Author %></div>
                    <div class="date">about <%= (DateTime.Now.Subtract (new TimeSpan (1, 0, 0)) - item.Time).ToFriendlySpan () %> ago</div>
                </div>
               <pre><%= Html.Encode (item.SvnLog.TrimEnd ()) %></pre>
            </div>
        </div>
<% } %>
