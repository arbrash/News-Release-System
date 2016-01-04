<%@ Page Language="c#" Inherits="WebNews.admin.admin_article" CodeBehind="admin_article.aspx.cs" AutoEventWireup="True" %>
<HTML>
	<HEAD>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	    <style type="text/css">
            .border
            {}
            .style1
            {
                height: 21px;
            }
        </style>
	</HEAD>
	<body>
		<div align="center"><asp:label id="myLabel" runat="server" width="100%" ForeColor="Red"></asp:label></div>
		<form id="myForm" runat="server">
			<div align="center"><strong>��������</strong>��&nbsp;
				<asp:TextBox id="keyword" runat="server"></asp:TextBox>
				<asp:dropdownlist id="search" runat="server">
					<asp:ListItem Value="����" Selected="True">����</asp:ListItem>
					<asp:ListItem Value="����">����</asp:ListItem>
				</asp:dropdownlist>&nbsp;
				<asp:LinkButton id="LinkButton1" runat="server" Font-Bold="True" Font-Size="Medium" Font-Underline="True" onclick="LinkButton1_Click">����</asp:LinkButton>
				&nbsp;
				<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="*�������������ݣ�" ControlToValidate="search" ForeColor="Red"></asp:RequiredFieldValidator></BUTTON></div>
			<br>
			<ASP:DATAGRID id="MyDataGrid" runat="server" ItemStyle-CssClass="tdbg" HeaderStyle-CssClass="title"
				CssClass="border" DataKeyField="articleid" AutoGenerateColumns="False" 
            CellPadding="3" Align="center"
				Width="804px" AllowPaging="True" OnDeleteCommand="MyDataGrid_DeleteCommand"
				OnSelectedIndexChanged=" MyDataGrid_SelectedIndexChanged">
				<EditItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></EditItemStyle>
				<ItemStyle HorizontalAlign="Left" CssClass="tdbg" VerticalAlign="Middle"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" CssClass="title" VerticalAlign="Middle"></HeaderStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="���ű���(����޸�)">
						<ItemTemplate>
							<%# show(DataBinder.Eval(Container.DataItem, "title"),DataBinder.Eval(Container.DataItem, "articleid"),DataBinder.Eval(Container.DataItem, "classname"))%>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="classname" HeaderText="��������">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="dateandtime" HeaderText="����ʱ��">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="username" HeaderText="��������Ա">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:BoundColumn>
					<asp:ButtonColumn Text="ɾ��" CommandName="Delete">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:ButtonColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<%#show(DataBinder.Eval(Container.DataItem,"articleid"),DataBinder.Eval(Container.DataItem,"classname"))%>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
                <HeaderStyle BackColor="#99CCFF" Font-Bold="True" ForeColor="Black" 
                                Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                                Font-Underline="False" />
				<PagerStyle Visible="False" NextPageText="��һҳ" PrevPageText="��һҳ" 
                    HorizontalAlign="Right" PageButtonCount="5"></PagerStyle>
			</ASP:DATAGRID>
			<table align="center" style="width: 800px">
				<tr>
					<td width="341">
						<div align="left"><asp:linkbutton id="btnFirst" onclick="PagerButtonClick" runat="server" Font-Bold="True" ForeColor="HotTrack" CommandArgument="first">��ҳ||</asp:linkbutton><asp:linkbutton id="LinkButton2" onclick="PagerButtonClick" runat="server" Font-Bold="True" ForeColor="HotTrack" CommandArgument="prev">ǰҳ||</asp:linkbutton><asp:LinkButton ID="LinkButton5" onclick="PagerButtonClick" Font-Bold="True" runat="server" ForeColor="HotTrack" CommandArgument="next">��ҳ||</asp:LinkButton><asp:LinkButton ID="LinkButton6" onclick="PagerButtonClick" Font-Bold="True" runat="server" ForeColor="HotTrack" CommandArgument="last">βҳ</asp:LinkButton>
                        </div>
					</td>
					<td width="239">
						<div align="right"><asp:label id="lblCurrentIndex" runat="server" Font-Bold="True" ForeColor="HotTrack"></asp:label><asp:label id="lblPageCount" runat="server" Font-Bold="True" ForeColor="HotTrack"></asp:label></div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
