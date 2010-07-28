<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcWrench.MonkeyWrench.Public.Revision[]>" %>

<% foreach (var item in Model) { %>
    <div class="commit">
        <table class="wrapper"><tr>
            <td class="header">
                <div class="human">
                    <div class="revision">Revision <%= item.RevisionNumber %></div>
                    <div class="actor">
                        <div class="gravatar">
                            <img alt="" src="<%= MvcWrench.UserHelpers.EmailToGravatar (MvcWrench.Models.SvnGravatars.Get (item.Author), 30) %>">
                        </div>
                        <div class="name"><%= item.Author %></div>
                        <div class="date"><%= (DateTime.Now.Subtract (new TimeSpan (1, 0, 0)) - item.Time).ToFriendlySpan () %> ago</div>
                    </div>
                </div>
            </td>
            <td style="vertical-align: top;">
                <div class="diff">
                    <table><tr>
                        <td style="padding-top: 2px;">
                            <a href="<%= Html.ResolveUrl (string.Format ("~/builds/mono/{0}", item.RevisionNumber)) %>">
                                <img src="<%= Html.ResolveUrl ("~/Media/diff.png") %>" alt="View Diff">
                            </a>
                        </td>
                        <td>
                            <a href="<%= Html.ResolveUrl (string.Format ("~/builds/mono/{0}", item.RevisionNumber)) %>">
                                View Diff
                            </a>
                        </td></tr>
                    </table>
                </div>
                <pre><%= Html.Encode (item.SvnLog.TrimEnd ()) %></pre>
            </td></tr>
        </table>
    </div>
<% } %>
