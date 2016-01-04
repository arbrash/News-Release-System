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
					<td class="title" style="background-color: #99CCFF"><b>添加新闻</b></td>
				</tr>
				<tr height="120">
					<td class="tdbg">
						<blockquote><br>
							新闻类型：
							<asp:dropdownlist id="ClassName" runat="server" AutoPostBack="True" 
                                Height="20px" Width="101px"></asp:dropdownlist>
                            <asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" 
                                Display="Dynamic" ErrorMessage="*请选择新闻类型" ControlToValidate="ClassName" 
                                NAME="Requiredfieldvalidator2" ForeColor="Red"></asp:requiredfieldvalidator>&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
							新闻标题： <input id="Title" type="text" maxLength="100" size="80" name="Title" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" 
                                Display="Dynamic" ErrorMessage="*请输入新闻标题" ControlToValidate="Title" 
                                NAME="Requiredfieldvalidator3" ForeColor="Red"></asp:requiredfieldvalidator>
							<br>
							&nbsp;<BR>
							&nbsp;新闻内容：<TEXTAREA id="Body" rows="17" runat="server">							</TEXTAREA><br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="Body" ErrorMessage="*请输入新闻内容" ForeColor="Red"></asp:RequiredFieldValidator>
							<br />
							&nbsp; 
                            <br />
&nbsp;新闻图片：<asp:Image ID="Image2" runat="server" />
&nbsp;
                            <asp:FileUpload ID="pic" runat="server" />
&nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click1" Text="上传" ValidationGroup="上传" />
                            &nbsp;<asp:label id="myLabel1" runat="server" 
                width="26%" ForeColor="Red" Height="16px"></asp:label>
                            <br />
&nbsp;图片标题：<asp:TextBox ID="TextBox1" runat="server" ValidationGroup="上传" Width="198px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="TextBox1" ErrorMessage="*请输入图片标题" ForeColor="Red" 
                                ValidationGroup="上传"></asp:RequiredFieldValidator>
                            <br />
							<br>
							<script language="javascript">
	function setAuthor(str)
	{
		var obj=document.myForm.Author;
		obj.value=str;
	}
							</script>
							&nbsp;&nbsp;&nbsp; 作者： <input id="Author" type="text" maxLength="100" size="60" runat="server"> 
							<br>
							&nbsp;&nbsp;&nbsp; 来源： <INPUT id="Source" type="text" maxLength="100" size="60" runat="server">
							<br>
							<br>
							<br>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="Submit" runat="server" text="添 加" onclick="Submit_Click"></asp:button>
							</blockquote>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
