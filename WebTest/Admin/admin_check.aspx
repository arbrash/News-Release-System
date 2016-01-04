<%@ Page language="c#" Codebehind="admin_check.aspx.cs" AutoEventWireup="True" Inherits="WebNews.admin.admin_check" %>
<HTML>
	<HEAD>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<div align="center"><asp:label id="myLabel" runat="server" width="100%" 
                ForeColor="Red"></asp:label></div>
		<form id="myForm" runat="server" >
			<div align="center">新闻搜索：&nbsp;
				<asp:TextBox id="keyword" runat="server"></asp:TextBox>
				<asp:dropdownlist id="search" runat="server">
					<asp:ListItem Value="标题" Selected="True">标题</asp:ListItem>
					<asp:ListItem Value="内容">内容</asp:ListItem>
				</asp:dropdownlist>&nbsp;
				<asp:LinkButton id="LinkButton1" runat="server" Font-Bold="True" Font-Size="Medium" Font-Underline="True" onclick="LinkButton1_Click">搜索</asp:LinkButton>
				&nbsp;
				<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="*请输入搜索内容！" ControlToValidate="search" ForeColor="Red"></asp:RequiredFieldValidator></BUTTON></div>
			<br>
			<ASP:DATAGRID id="MyDataGrid" runat="server" ItemStyle-CssClass="tdbg" HeaderStyle-CssClass="title" CssClass="border" DataKeyField="articleid" AutoGenerateColumns="False" CellPadding="3" Align="center" Width="750px" AllowPaging="True" OnSelectedIndexChanged=" MyDataGrid_SelectedIndexChanged" OnDeleteCommand="MyDataGrid_DeleteCommand" OnItemCommand="MyDataGrid_ItemCommand">
				<EditItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></EditItemStyle>
				<ItemStyle HorizontalAlign="Left" CssClass="tdbg" VerticalAlign="Middle"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" CssClass="title" VerticalAlign="Middle"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="新闻标题(点击修改)">
						<ItemTemplate>
							<%# show(DataBinder.Eval(Container.DataItem, "title"),DataBinder.Eval(Container.DataItem, "articleid"),DataBinder.Eval(Container.DataItem, "classname"))%>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="classname" HeaderText="所属分类">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="dateandtime" HeaderText="发布时间">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="username" HeaderText="发布管理员">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:ButtonColumn Text="删除" CommandName="Delete">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:ButtonColumn>
					<asp:ButtonColumn Text="通过" HeaderText="审核" CommandName="pass">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:ButtonColumn>
				</Columns>
                <HeaderStyle BackColor="#99CCFF" Font-Bold="True" ForeColor="Black" 
                                Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                                Font-Underline="False" />
				<PagerStyle Visible="False" NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
			</ASP:DATAGRID>
			<table align="center" style="width: 749px">
				<tr>
					<td width="341">
						<div align="left"><asp:linkbutton id="btnFirst" onclick="PagerButtonClick" runat="server" Font-Bold="True" ForeColor="HotTrack" CommandArgument="first">首页||</asp:linkbutton><asp:linkbutton id="LinkButton2" onclick="PagerButtonClick" runat="server" Font-Bold="True" ForeColor="HotTrack" CommandArgument="prev">前页||</asp:linkbutton><asp:linkbutton id="Linkbutton3" onclick="PagerButtonClick" runat="server" Font-Bold="True" ForeColor="HotTrack" CommandArgument="next" >下页||</asp:linkbutton><asp:linkbutton id="Linkbutton4" onclick="PagerButtonClick" runat="server" Font-Bold="True" ForeColor="HotTrack" CommandArgument="last">尾页</asp:linkbutton></div>
					</td>
					<td width="239">
						<div align="right" style="width: 399px"><asp:label id="lblCurrentIndex" runat="server" Font-Bold="True" ForeColor="HotTrack"></asp:label><asp:label id="lblPageCount" runat="server" Font-Bold="True" ForeColor="HotTrack"></asp:label></div>
					</td>
				</tr>
			</table>
			<TABLE id="Table2" width="750" align="center">
				<TBODY>
					<TR>
						<TD align="right">&nbsp;</TD>
					</TR>
				</TBODY></TABLE>
		</form>
	</body>
</HTML>
