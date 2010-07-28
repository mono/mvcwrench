<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcWrench.Models.StatusStrip>" %>

<%--
This is what we are building...

	<ul class="statusstrip">
		<li class="title gr_r" style="width: 115px"><a href="/" title=""><em style="width: 115px">sle-11-x86_64</em></a></li>
		<li class="fail r_y"><a href="/1"><em>r148153</em></a></li>
		<li class="executing y_g"><a href="/2"><em>r148152</em></a></li>
		<li class="success g_g"><a href="/3"><em>r148151</em></a></li>
		<li class="success g_r"><a href="/4"><em>r148150</em></a></li>
		<li class="fail r_r"><a href="/5"><em>r148149</em></a></li>
		<li class="fail r_g"><a href="/6"><em>r148148</em></a></li>
		<li class="success g_g"><a href="/7"><em>r148147</em></a></li>
		<li class="success g_gr"><a href="/8"><em>r148146</em></a></li>
		<li class="notdone gr_g"><a href="/9"><em>r148145</em></a></li>
		<li class="mainNavNoBg success" style="width: 67px"><a href="/10"><em>r148144</em></a></li>
	</ul>
--%>

<% if (string.IsNullOrEmpty (Model.Url)) { %>
    <span style="font-weight: bold; padding-bottom: 3px"><%= Model.Name %></span>
<% } else { %>
    <span style="font-weight: bold;"><a href="<%= Html.ResolveUrl (Model.Url) %>" style="color: #000000"><%= Model.Name %></a></span>
<% } %>

<% foreach (MvcWrench.Models.StatusStripRow row in Model.Rows) { %><ul class="statusstrip">
<% if (string.IsNullOrEmpty (row.HeaderUrl)) { %>
  <li class="title <%= string.Format ("gr_{0}", MvcWrench.Models.StatusStripCell.GetStatusColor (row.Cells[0].Status)) %> <%= row.IsHeader ? "row-header" : "" %>" style="width: 115px"><%= row.HeaderText %></li>
<% } else { %>
  <li class="title <%= string.Format ("gr_{0}", MvcWrench.Models.StatusStripCell.GetStatusColor (row.Cells[0].Status)) %>" style="width: 115px"><a href="<%= Html.ResolveUrl (row.HeaderUrl) %>"><%= row.HeaderText %></a></li>
<% } %>
<% for (int i = 0; i < row.Cells.Count; i++) { MvcWrench.Models.StatusStripCell cell = row.Cells[i]; %>
  <% if (i + 1 < row.Cells.Count) { %>
  <li class="<%= cell.GetCss (row.Cells[i + 1]) %>"><a href="<%= Html.ResolveUrl (cell.Url) %>"><%= cell.Text %></a></li>
  <% } else { %>
  <li class="<%= cell.GetCss (null) %>"><a href="<%= Html.ResolveUrl (cell.Url) %>"><%= cell.Text %></a></li>
<% } %>
<% } %>
</ul><% } %>
