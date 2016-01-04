<%@ Page Language="c#" Inherits="WebNews.admin.admin_user" CodeBehind="admin_user.aspx.cs" AutoEventWireup="True" %>
<HTML>
	<HEAD>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<link rel="stylesheet" href="../style.css" type="text/css">
	    <style type="text/css">
            .style1
            {
                width: 332px;
            }
            .style2
            {
                width: 213px;
            }
        </style>
	</HEAD>
	<body>
		<div align="center">
			<ASP:Label id="myLabel" width="100%" runat="server" Font-Size="Medium" 
                ForeColor="Red"></ASP:Label>
		</div>
		<form id="myForm" runat="server">
			<div align="center">
				<br />
				<ASP:DataGrid AutoGenerateColumns="False" DataKeyField="id" CellPadding="3" 
                    CssClass="border" HeaderStyle-CssClass="title" id="MyDataGrid" 
                    AllowPaging="True" PageSize="5" ItemStyle-CssClass="tdbg" 
                    OnEditCommand="MyDataGrid_EditCommand" 
                    OnCancelCommand="MyDataGrid_CancelCommand" 
                    OnUpdateCommand="MyDataGrid_UpdateCommand" 
                    OnDeleteCommand="MyDataGrid_DeleteCommand" 
                    OnSelectedIndexChanged=" MyDataGrid_SelectedIndexChanged" runat="server" 
                    Width="900px" Align="center" BorderStyle="Groove" BorderWidth="2px" 
                    BorderColor="#CCCCCC">
					<ItemStyle CssClass="tdbg" HorizontalAlign="center"></ItemStyle>
					<HeaderStyle CssClass="title" HorizontalAlign="center"></HeaderStyle>
					<Columns>
						<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="更新" CancelText="取消" EditText="编辑"></asp:EditCommandColumn>
						<asp:TemplateColumn HeaderText="用户名" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center">
							<ItemTemplate>
								<%#DataBinder.Eval(Container.DataItem,"username")%>
							</ItemTemplate>
							<EditItemTemplate>
								<FONT face="宋体">
									<asp:TextBox id="UserName" text='<%#DataBinder.Eval(Container.DataItem,"username")%>' runat="server">
									</asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="请输入用户名！" ControlToValidate="username"></asp:RequiredFieldValidator>
								</FONT>
							</EditItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="密码">
							<ItemTemplate>
								<FONT face="宋体">******</FONT>
							</ItemTemplate>
							<EditItemTemplate>
								<FONT face="宋体">
									<asp:TextBox id="PassWord" text="" runat="server" TextMode="Password" MaxLength="18"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="请输入密码！" ControlToValidate="password"></asp:RequiredFieldValidator>
								</FONT>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="等级">
							<ItemTemplate>
								<%# show(DataBinder.Eval(Container.DataItem,"classname"),DataBinder.Eval(Container.DataItem,"username"))%>
							</ItemTemplate>
							<EditItemTemplate>
								<%if(classname=="系统管理员")%>
								<%{%>
								<asp:DropDownList id="UserClass" runat="server">
									<asp:ListItem value="系统管理员" Selected="True">系统管理员</asp:ListItem>
									<asp:ListItem value="新闻管理员">新闻管理员</asp:ListItem>
								</asp:DropDownList>
								<%}%>
								<%else%>
								<%{%>
								<asp:DropDownList id="Dropdownlist2" runat="server" onselectedindexchanged="Dropdownlist2_SelectedIndexChanged">
									<asp:ListItem value="系统管理员">系统管理员</asp:ListItem>
									<asp:ListItem value="新闻管理员" Selected="True">新闻管理员</asp:ListItem>
								</asp:DropDownList>
								<%}%>
							</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="addnum" ReadOnly="True" HeaderText="添加新闻数"></asp:BoundColumn>
						<asp:ButtonColumn Text="删除" CommandName="Delete"></asp:ButtonColumn>
					</Columns>
                    <HeaderStyle BackColor="#99CCFF" Font-Bold="True" ForeColor="Black" 
                                Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                                Font-Underline="False" />
					<PagerStyle Visible="False"></PagerStyle>
				</ASP:DataGrid></div>
			<table align="center" style="width: 898px">
				<tr>
					<td class="style2">
						<div align="left"><asp:linkbutton id="btnFirst" onclick="PagerButtonClick" runat="server" Font-Bold="True" ForeColor="HotTrack" CommandArgument="first">首页||</asp:linkbutton><asp:linkbutton id="LinkButton2" onclick="PagerButtonClick" runat="server" Font-Bold="True" ForeColor="HotTrack" CommandArgument="prev">前页||</asp:linkbutton><asp:linkbutton id="LinkButton1" onclick="PagerButtonClick" runat="server" Font-Bold="True" ForeColor="HotTrack" CommandArgument="next" >下页||</asp:linkbutton><asp:linkbutton id="LinkButton3" onclick="PagerButtonClick" runat="server" Font-Bold="True" ForeColor="HotTrack" CommandArgument="last">尾页</asp:linkbutton></div>
					</td>
					<td class="style1">
						<div align="right"><asp:label id="lblCurrentIndex" runat="server" Font-Bold="True" ForeColor="HotTrack"></asp:label><asp:label id="lblPageCount" runat="server" Font-Bold="True" ForeColor="HotTrack"></asp:label></div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
