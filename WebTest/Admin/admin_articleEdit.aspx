<%@ Page language="c#" Codebehind="admin_articleEdit.aspx.cs" AutoEventWireup="True" Inherits="WebNews.admin.admin_articleEdit" %>
<HTML>
	<HEAD>
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	    <style type="text/css">
            #Body
            {
                width: 575px;
            }
        </style>
	</HEAD>
	<body runat="server" ID="Body1" NAME="Body1">
		<div align="center"><asp:label id="myLabel" runat="server" 
                width="100%" ForeColor="Red"></asp:label></div>
		<form id="myForm" name="myForm" runat="server" enctype="multipart/form-data">
			&nbsp;
			<table class="border" cellSpacing="0" cellPadding="0" width="800" 
                align="center" border="0" style="border: thin groove #C0C0C0;">
				<tr align="middle" height="25">
					<td class="title" style="background-color: #99CCFF"><b>�޸�����</b></td>
				</tr>
				<tr height="120">
					<td class="tdbg">
						<blockquote><br>
							&nbsp;&nbsp;&nbsp;
							�������ͣ�<asp:dropdownlist id="ClassName" runat="server" AutoPostBack="true" 
                                Width="101px"></asp:dropdownlist>
                            <asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" 
                                Display="Dynamic" ErrorMessage="*��ѡ����������" ControlToValidate="ClassName" 
                                NAME="Requiredfieldvalidator2" ForeColor="Red"></asp:requiredfieldvalidator><br>
							&nbsp;&nbsp;&nbsp; ���ű��⣺<asp:TextBox id="Title" runat="server" Width="574px"></asp:TextBox>
							<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" 
                                Display="Dynamic" ErrorMessage="*���������ű���" ControlToValidate="Title" 
                                NAME="Requiredfieldvalidator3" ForeColor="Red"></asp:requiredfieldvalidator><BR>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
&nbsp;&nbsp;&nbsp; �������ݣ�<TEXTAREA rows="20" 
                                id="Body" runat="server">
							</TEXTAREA><br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="*�������������ݣ�" ControlToValidate="Body" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            <br />
&nbsp;&nbsp;&nbsp; ����ͼƬ��<asp:Image ID="Image1" runat="server" />
&nbsp;<asp:FileUpload ID="pic" runat="server" />
&nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click1" Text="�ϴ�" ValidationGroup="�ϴ�" />
&nbsp;<asp:label id="myLabel1" runat="server" 
                width="26%" ForeColor="Red" Height="16px"></asp:label>
                            <br />
&nbsp;&nbsp;&nbsp; ͼƬ���⣺<asp:TextBox ID="TextBox1" runat="server" ValidationGroup="�ϴ�" Width="198px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="TextBox1" ErrorMessage="*������ͼƬ����" ForeColor="Red" 
                                ValidationGroup="�ϴ�"></asp:RequiredFieldValidator>
                            <br />
							<br>
							<br>
							<script language="javascript">
	function setAuthor(str)
	{
		var obj=document.myForm.Body;
		obj.value=str;
	}
							</script>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ���ߣ�
							<asp:TextBox id="Author" runat="server" Width="198px"></asp:TextBox>
							<br>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ��Դ��
							<asp:TextBox id="Source" runat="server" Width="198px"></asp:TextBox>
							<br>
							<br>
							<br>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="Submit" runat="server" text="�� ��" onclick="Submit_Click"></asp:button>
                        </blockquote>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
