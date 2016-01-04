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
					<td class="title" style="background-color: #99CCFF"><b>修改新闻</b></td>
				</tr>
				<tr height="120">
					<td class="tdbg">
						<blockquote><br>
							&nbsp;&nbsp;&nbsp;
							新闻类型：<asp:dropdownlist id="ClassName" runat="server" AutoPostBack="true" 
                                Width="101px"></asp:dropdownlist>
                            <asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" 
                                Display="Dynamic" ErrorMessage="*请选择新闻类型" ControlToValidate="ClassName" 
                                NAME="Requiredfieldvalidator2" ForeColor="Red"></asp:requiredfieldvalidator><br>
							&nbsp;&nbsp;&nbsp; 新闻标题：<asp:TextBox id="Title" runat="server" Width="574px"></asp:TextBox>
							<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" 
                                Display="Dynamic" ErrorMessage="*请输入新闻标题" ControlToValidate="Title" 
                                NAME="Requiredfieldvalidator3" ForeColor="Red"></asp:requiredfieldvalidator><BR>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
&nbsp;&nbsp;&nbsp; 新闻内容：<TEXTAREA rows="20" 
                                id="Body" runat="server">
							</TEXTAREA><br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="*请输入新闻内容！" ControlToValidate="Body" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            <br />
&nbsp;&nbsp;&nbsp; 新闻图片：<asp:Image ID="Image1" runat="server" />
&nbsp;<asp:FileUpload ID="pic" runat="server" />
&nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click1" Text="上传" ValidationGroup="上传" />
&nbsp;<asp:label id="myLabel1" runat="server" 
                width="26%" ForeColor="Red" Height="16px"></asp:label>
                            <br />
&nbsp;&nbsp;&nbsp; 图片标题：<asp:TextBox ID="TextBox1" runat="server" ValidationGroup="上传" Width="198px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="TextBox1" ErrorMessage="*请输入图片标题" ForeColor="Red" 
                                ValidationGroup="上传"></asp:RequiredFieldValidator>
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
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 作者：
							<asp:TextBox id="Author" runat="server" Width="198px"></asp:TextBox>
							<br>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 来源：
							<asp:TextBox id="Source" runat="server" Width="198px"></asp:TextBox>
							<br>
							<br>
							<br>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="Submit" runat="server" text="修 改" onclick="Submit_Click"></asp:button>
                        </blockquote>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
