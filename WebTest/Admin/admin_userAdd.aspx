<%@ Page Language="c#" Inherits="WebNews.admin.admin_userAdd" CodeBehind="admin_userAdd.aspx.cs" AutoEventWireup="True" %>
<HTML>
	<HEAD>
		<link rel="stylesheet" href="../style.css" type="text/css">
	</HEAD>
	<body>
		<form id="MyForm" runat="server">
			<table cellpadding="0" cellspacing="0" width="400" border="0" align="center" 
                class="border" height="252" 
                style="border: thin groove #C0C0C0; width: 500px;">
				<tr align="middle" height="25">
					<td class="title" style="background-color: #99CCFF"><b>��ӹ���Ա</b></td>
				</tr>
				<tr height="150">
					<td align="center" class="tdbg">
			<asp:Label width="100%" id="myLabel" runat="server" ForeColor="Red" />
		                <br />
						<asp:CompareValidator ControlToValidate="password" ControlToCompare="password1" 
                            Type="String" EnableClientScript="false" ErrorMessage="�û�������ȷ�����벻ͬ<br>" 
                            Display="Dynamic" runat="server" id="CompareValidator1" ForeColor="Red" />
                        <br />
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						�û�����&nbsp;
						<asp:TextBox Columns="10" MaxLength="15" id="Username" runat="server" />
						<asp:RequiredFieldValidator id="RequiredFieldValidator" 
                            ControlToValidate="Username" ErrorMessage="*�������û�����" 
                            runat="server" ForeColor="Red" />
						<br>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        �� �룺&nbsp; 
						<asp:TextBox Columns="10" MaxLength="15" id="Password" TextMode="Password" runat="server" />
						<asp:RequiredFieldValidator id="RequiredFieldValidator1" 
                            ControlToValidate="Password" ErrorMessage="*���������룡" 
                            runat="server" ForeColor="Red" />
						<br />
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        ����ȷ�ϣ�&nbsp;
						<asp:TextBox Columns="10" MaxLength="15" id="Password1" TextMode="Password" runat="server" />
						<asp:RequiredFieldValidator id="RequiredFieldValidator2" 
                            ControlToValidate="Password1" ErrorMessage="*������ȷ�����룡" 
                            runat="server" ForeColor="Red" />
                        <br />
                        <br />
						����ȼ��� &nbsp;
						<asp:DropDownList id="UserClass" runat="server" Height="30px" Width="96px">
							<asp:ListItem Value="2">���Ź���Ա</asp:ListItem>
							<asp:ListItem Value="1">ϵͳ����Ա</asp:ListItem>
						</asp:DropDownList>&nbsp;<br />
                        <br>
		<FONT color="#ff0000">ע������ӵ����Ź���Ա��Ȩ�ޣ�<br />
                        ����"����Ա�޸�"��������Ȩ�ޡ�<br />
                        </FONT>
						<br>
						<asp:Button id="Submit" text="�� ��" runat="server" onclick="Submit_Click" />
						<br />
						<br>
					</td>
				</tr>
			</table>
		</form>
		<FONT color="#ff0000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </FONT>
	</body>
</HTML>
