<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%-- 
This is what we are building...

<table id="difftable0" class="sidebyside">
	<colgroup>
		<col class="line" /><col class="left" /><col class="line" /><col class="right" />
	</colgroup>
	<thead>
		<tr><th colspan="4">mono/mini/ChangeLog</th></tr>
		<tr><th class="rev" colspan="2">revision 136366</th><th colspan="2" class="rev">revision 136367</th></tr>
	</thead>
	<tbody class="collapsable">
		<tr class="insert">
			<th></th><td><pre></pre></td><th>1</th><td><pre>2009-06-17  Geoff Norton  &lt;gnorton@novell.com&gt;</pre></td>
		</tr>
		<tr class="insert">
			<th></th><td><pre></pre></td><th>2</th><td><pre></pre></td>
		</tr>
		<tr class="insert">
			<th></th><td><pre></pre></td><th>3</th><td><pre>	* aot-compiler.c: Ensure we dont try to close a null dwarf writer.</pre></td>
		</tr>
		<tr class="insert">
			<th></th><td><pre></pre></td><th>4</th><td><pre></pre></td>
		</tr>
		<tr>
			<th>1</th><td><pre> 2009-06-17  Zoltan Varga  &lt;vargaz@gmail.com&gt;</pre></td><th>5</th><td><pre> 2009-06-17  Zoltan Varga  &lt;vargaz@gmail.com&gt;</pre></td>
		</tr>
		<tr>
			<th>2</th><td><pre> </pre></td><th>6</th><td><pre> </pre></td>
		</tr>
		<tr>
			<th>3</th><td><pre> 	* dwarfwriter.c (mono_dwarf_writer_create): Add an 'appending' parameter</pre></td><th>7</th><td><pre> 	* dwarfwriter.c (mono_dwarf_writer_create): Add an 'appending' parameter</pre></td>
		</tr>
	</tbody>
</table>
--%>

<% MvcWrench.Models.DiffViewer diff = (MvcWrench.Models.DiffViewer)Model; %>

<% foreach (MvcWrench.Models.DiffFile file in diff.Files) { %>
<table id="difftable0" class="sidebyside">
  <colgroup>
    <col class="line" /><col class="left" /><col class="line" /><col class="right" />
  </colgroup>
  
  <thead>
    <tr><th colspan="4"><%= Html.Encode (file.File) %></th></tr>
    <tr>
      <th class="rev" colspan="2"><%= Html.Encode (file.LeftHeader) %></th>
      <th class="rev" colspan="2"><%= Html.Encode (file.RightHeader) %></th>
    </tr>
  </thead>
  
  <tbody class="collapsable">
<% foreach (MvcWrench.Models.DiffLine line in file.Lines) { %>
		<tr class="<%= line.CssClass %>">
			<th><%= line.LeftLineNumber > 0 ? Html.Encode (line.LeftLineNumber) : string.Empty %></th><td><pre><%= Html.Encode (line.LeftLineText) %></pre></td><th><%= line.RightLineNumber > 0 ? Html.Encode (line.RightLineNumber) : string.Empty %></th><td><pre><%= Html.Encode (line.RightLineText) %></pre></td>
		</tr>
<% } %>
  </tbody>
</table>
<br />
<% } %>
