<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<div class="bugchart">
<div class="bugtitle"><a href="http://www.mono-project.com/Bugs">Open Mono Bugs - Last 7 Days</a></div>
<img style="margin-top:10px;" src="http://chart.apis.google.com/chart?
chs=300x175
&amp;chd=t:<%= (string)Model %>
&amp;cht=lc
&amp;chco=76A4FB,A5E368
&amp;chm=b,E9F2FF,0,1,0|B,E2EED7,1,2,0
&amp;chdl=Bugs|Bugs With Patches
&amp;chdlp=b"
alt="Open Mono Bugs - Last 7 Days" />
<table style="margin-left: 58px; margin-top: 10px;">
    <tr>
        <td><a href="http://mono-project.com/Bugs"><img src="Media/bug_link.png" alt="Bugzilla" /></a></td>
        <td style="font-size: .85em;"><a href="http://mono-project.com/Bugs">Bugzilla</a></td>
        <td style="font-size: .85em;"> | </td>
        <td><a href="http://tinyurl.com/ydqpoyn"><img src="Media/bug_link.png" alt="Bugs with Patches" /></a></td>
        <td style="font-size: .85em;"><a href="http://tinyurl.com/ydqpoyn"> Bugs with Patches</a></td>
    </tr>
</table>

</div>