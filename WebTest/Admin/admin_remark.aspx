<%@ Page language="c#" Codebehind="admin_remark.aspx.cs" AutoEventWireup="True" Inherits="WebNews.admin_remark" %>
<HTML>
	<HEAD>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<div align="center"><asp:label id="myLabel" runat="server" width="100%" 
                ForeColor="Red"></asp:label></div>
		<form id="myForm"  runat="server">
			<div align="center">����������&nbsp;
				<asp:textbox id="keyword" runat="server"></asp:textbox><asp:dropdownlist id="search" runat="server">
					<asp:ListItem Value="����" Selected="True">����</asp:ListItem>
					<asp:ListItem Value="����">����</asp:ListItem>
				</asp:dropdownlist>&nbsp;
				<asp:imagebutton id="ImageButton1" runat="server" ImageUrl="~/pic/1-1.jpg" 
                    BorderColor="#CCCCCC" BorderStyle="Groove" Height="16px" onclick="ImageButton1_Click"></asp:imagebutton>
                &nbsp;
				<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="search" ErrorMessage="*�������������ݣ�" ForeColor="Red"></asp:requiredfieldvalidator></BUTTON></div>
			<br>
			<ASP:DATAGRID id="MyDataGrid" runat="server" AllowPaging="True" Width="750px" 
                Align="center" CellPadding="3" AutoGenerateColumns="False" DataKeyField="id" 
                CssClass="border" HeaderStyle-CssClass="title" ItemStyle-CssClass="tdbg" 
                OnDeleteCommand="MyDataGrid_DeleteCommand" 
                OnSelectedIndexChanged="MyDataGrid_SelectedIndexChanged">
				<EditItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></EditItemStyle>
				<ItemStyle HorizontalAlign="Left" CssClass="tdbg" VerticalAlign="Middle"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" CssClass="title" VerticalAlign="Middle"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="body" HeaderText="��������" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
					<asp:BoundColumn DataField="username" HeaderText="����" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
					<asp:BoundColumn DataField="ip" HeaderText="IP" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
					<asp:BoundColumn DataField="dateandtime" HeaderText="����ʱ��" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
					<asp:ButtonColumn Text="ɾ��" CommandName="Delete" ItemStyle-HorizontalAlign="Center"></asp:ButtonColumn>
				</Columns>
                <HeaderStyle BackColor="#99CCFF" Font-Bold="True" ForeColor="Black" 
                                Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                                Font-Underline="False" />
				<PagerStyle Mode="NumericPages" Visible="False" NextPageText="fdf" PrevPageText="fdf" HorizontalAlign="Right" PageButtonCount="5"></PagerStyle>
			</ASP:DATAGRID>
			<table align="center" style="width: 749px">
				<tr>
					<td width="341">
						<div align="left"><asp:linkbutton id="btnFirst" onclick="PagerButtonClick" runat="server" Font-Bold="True" ForeColor="HotTrack" CommandArgument="first">��ҳ||</asp:linkbutton><asp:linkbutton id="LinkButton2" onclick="PagerButtonClick" runat="server" Font-Bold="True" ForeColor="HotTrack" CommandArgument="prev">ǰҳ||</asp:linkbutton><asp:linkbutton id="Linkbutton3" onclick="PagerButtonClick" runat="server" Font-Bold="True" ForeColor="HotTrack" CommandArgument="next" >��ҳ||</asp:linkbutton><asp:linkbutton id="Linkbutton4" onclick="PagerButtonClick" runat="server" Font-Bold="True" ForeColor="HotTrack" CommandArgument="last">βҳ</asp:linkbutton></div>
					</td>
					<td width="239">
						<div align="right" style="width: 394px"><asp:label id="lblCurrentIndex" runat="server" Font-Bold="True" ForeColor="HotTrack"></asp:label><asp:label id="lblPageCount" runat="server" Font-Bold="True" ForeColor="HotTrack"></asp:label></div>
					</td>
				</tr>
			</table>
			<table id="Table2" width="750" align="center">
				<tr>
					<td align="right">&nbsp;</td>
				</tr>
				<tr>
					<td vAlign="bottom" height="30"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
