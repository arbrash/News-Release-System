<%@ Page Language="c#" Inherits="WebNews.admin.admin_change" CodeBehind="admin_change.aspx.cs" AutoEventWireup="True" %>
<HTML>
	<HEAD>
		<link rel="stylesheet" href="../style.css" type="text/css">
	</HEAD>
	<body>
		<form id="form1" runat="server">
			<table cellpadding="0" cellspacing="0" width="326" border="0" align="center" 
                class="border" height="196" 
                style="border: thin groove #C0C0C0; width: 500px;">
				<tr align="middle" height="25">
					<td class="title" style="background-color: #99CCFF"><b>�˺��޸�</b></td>
				</tr>
				<tr height="120">
					<td align="middle" height="160" class="tdbg">
						<asp:Label width="100%" id="Label1" runat="server" ForeColor="Red" />
						<br />
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						�û�����<asp:TextBox Columns="10" MaxLength="15" id="Username" runat="server" />
						&nbsp;<asp:RequiredFieldValidator id="RequiredFieldValidator" 
                            ControlToValidate="Username" ErrorMessage="*�������û�����" 
                            runat="server" ForeColor="Red" />
						<br>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						�����룺<asp:TextBox id="oldPassword" Columns="10" textmode="Password" MaxLength="15" runat="server" />
						&nbsp;<asp:RequiredFieldValidator id="RequiredFieldValidator2" 
                            ControlToValidate="oldPassword" ErrorMessage="*����������룡" 
                            runat="server" ForeColor="Red" />
						<br>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						�����룺<asp:TextBox id="Password" Columns="10" textmode="Password" MaxLength="15" runat="server" />
						&nbsp;<input type="hidden" id="oldUsername" runat="server"><asp:RequiredFieldValidator id="RequiredFieldValidator1" 
                            ControlToValidate="Password" ErrorMessage="*�����������룡" 
                            runat="server" ForeColor="Red" />
						<br>
						<br>
						<asp:Button id="Submit" text="�� ��" runat="server" onclick="Submit_Click" />
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
