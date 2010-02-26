<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcWrench.Models.Commit>" %>
    <div id="commit" style="padding-bottom: 0px;">
            <div class="human">
                <div class="actor">
                    <div class="gravatar">
                        <img alt="" src="<%= MvcWrench.UserHelpers.EmailToGravatar (Model.Email, 30) %>" />
                    </div>
                    <div class="name"><%= Model.Author %></div>
                    <div class="date"><%= Model.CommitTime.ToString () %></div>
                </div>
               <pre><%= Model.CommitLog %></pre>
               <table><tr><td><a href="<%= Html.ResolveUrl (string.Format ("~/builds/{1}/{0}", Model.Revision, Model.ProjectLinkName)) %>"><img src="<%= Html.ResolveUrl ("~/Media/diff.png") %>" alt="View Diff" /></a></td><td><a href="<%= Html.ResolveUrl (string.Format ("~/builds/{1}/{0}", Model.Revision, Model.ProjectLinkName)) %>" style="font-weight: normal;">View Diff</a></td></tr></table>
            </div>
            <div class="machine">
                Revision: <%= Model.Revision %><br />
                Status:&nbsp;&nbsp;&nbsp;<%= Model.StatusText %><br />
                Build:&nbsp;&nbsp;&nbsp;&nbsp;<%= Model.Lane %><br />
                Arch:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%= Model.Host %><br />
                Host:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%= Model.Builder %><br />
                Duration: <%= Model.BuildDuration == TimeSpan.Zero ? "" : Model.BuildDuration.ToHoursMinSec () %><br />
            </div>
        </div>
