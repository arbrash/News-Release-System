<%@ Page Language="c#" Inherits="WebNews.admin.admin_main" CodeBehind="admin_main.aspx.cs" AutoEventWireup="True" %>
<HTML>
	<HEAD>
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	    <style type="text/css">
            .style1
            {
                height: 25px;
            }
        </style>
	</HEAD>
	<body>
		<table class="border" cellSpacing="0" cellPadding="5" width="750" align="center" border="0">
			<tr align="center">
				<td class="style1" align="center">欢迎进入 <STRONG><FONT color="#ff0000">Arbrash 新闻发布系统</FONT></STRONG> 
                    &nbsp;管理页面</td>
			</tr>
			<tr class="tdbg" vAlign="top">
				<td>
                    <br />
                    <asp:label id="SysInfo" runat="server"></asp:label></td>
			</tr>
		</table>
		<br>
		<asp:datalist id="myDL" runat="server" Width="750" Align="center" CellPadding="3" CellSpacing="0"
			GridLines="both" RepeatColumns="4" RepeatDirection="Horizontal" ShowHeader="true" ShowFooter="false">
			<HeaderTemplate>
				管理员工作情况
			</HeaderTemplate>
            <HeaderStyle BackColor="#99CCFF" Font-Bold="True" ForeColor="Black" 
                                Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                                Font-Underline="False" />
			<ItemStyle HorizontalAlign="Center" Height="25px" Width="25%" CssClass="bg1" VerticalAlign="Middle"></ItemStyle>
			<ItemTemplate>
				<%# show(DataBinder.Eval(Container.DataItem, "username"))%>
				(<%#DataBinder.Eval(Container.DataItem,"addnum")%>篇)
				<DIV></DIV>
			</ItemTemplate>
			<HeaderStyle HorizontalAlign="Center" Height="25px" CssClass="title1"></HeaderStyle>
		</asp:datalist><br>
	</body>
</HTML>
