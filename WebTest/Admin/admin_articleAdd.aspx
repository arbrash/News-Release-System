<%@ Page Language="c#" Inherits="WebNews.admin.admin_articleAdd" CodeBehind="admin_articleAdd.aspx.cs" AutoEventWireup="True" %>
<HTML>
	<HEAD>
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	    <style type="text/css">
            #Body
            {
                width: 574px;
            }
            #Author
            {
                width: 198px;
            }
            #Source
            {
                width: 197px;
            }
            #Title
            {
                width: 574px;
            }
        </style>
	</HEAD>
	<body runat="server">
		<form id="myForm" name="myForm" runat="server" enctype="multipart/form-data">
		<div align="center">
           <asp:label id="myLabel" runat="server" 
                width="100%" ForeColor="Red"></asp:label>
            <br />
           </div>
			&nbsp;
			<table class="border" cellSpacing="0" cellPadding="0" width="800" 
                align="center" border="0" style="border: thin groove #C0C0C0">
				<tr align="middle" height="25">
					<td class="title" style="background-color: #99CCFF"><b>�������</b></td>
				</tr>
				<tr height="120">
					<td class="tdbg">
						<blockquote><br>
							�������ͣ�
							<asp:dropdownlist id="ClassName" runat="server" AutoPostBack="True" 
                                Height="20px" Width="101px"></asp:dropdownlist>
                            <asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" 
                                Display="Dynamic" ErrorMessage="*��ѡ����������" ControlToValidate="ClassName" 
                                NAME="Requiredfieldvalidator2" ForeColor="Red"></asp:requiredfieldvalidator>&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
							���ű��⣺ <input id="Title" type="text" maxLength="100" size="80" name="Title" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" 
                                Display="Dynamic" ErrorMessage="*���������ű���" ControlToValidate="Title" 
                                NAME="Requiredfieldvalidator3" ForeColor="Red"></asp:requiredfieldvalidator>
							<br>
							&nbsp;<BR>
							&nbsp;�������ݣ�<TEXTAREA id="Body" rows="17" runat="server">							</TEXTAREA><br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="Body" ErrorMessage="*��������������" ForeColor="Red"></asp:RequiredFieldValidator>
							<br />
							&nbsp; 
                            <br />
&nbsp;����ͼƬ��<asp:Image ID="Image2" runat="server" />
&nbsp;
                            <asp:FileUpload ID="pic" runat="server" />
&nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click1" Text="�ϴ�" ValidationGroup="�ϴ�" />
                            &nbsp;<asp:label id="myLabel1" runat="server" 
                width="26%" ForeColor="Red" Height="16px"></asp:label>
                            <br />
&nbsp;ͼƬ���⣺<asp:TextBox ID="TextBox1" runat="server" ValidationGroup="�ϴ�" Width="198px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="TextBox1" ErrorMessage="*������ͼƬ����" ForeColor="Red" 
                                ValidationGroup="�ϴ�"></asp:RequiredFieldValidator>
                            <br />
							<br>
							<script language="javascript">
	function setAuthor(str)
	{
		var obj=document.myForm.Author;
		obj.value=str;
	}
							</script>
							&nbsp;&nbsp;&nbsp; ���ߣ� <input id="Author" type="text" maxLength="100" size="60" runat="server"> 
							<br>
							&nbsp;&nbsp;&nbsp; ��Դ�� <INPUT id="Source" type="text" maxLength="100" size="60" runat="server">
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
