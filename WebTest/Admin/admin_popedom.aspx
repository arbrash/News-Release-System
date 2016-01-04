<%@ Page language="c#" Codebehind="admin_popedom.aspx.cs" AutoEventWireup="True" Inherits="WebNews.admin._1" %>
<HTML>
	<HEAD>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<div align="center"></div>
		<form id="MyForm" runat="server">
			<div align="center">
				<asp:Label id="Label1" runat="server"></asp:Label>
			</div>
			<table class="border" cellSpacing="0" cellPadding="0" width="500" 
                align="center" border="0" style="border: thin groove #C0C0C0">
				<tr align="middle" height="25">
					<td class="title" style="background-color: #99CCFF"><b><asp:label id="myLabel" runat="server" width="100%"></asp:label></b></td>
				</tr>
				<tr height="120">
					<td class="tdbg" align="middle">
						<br>
						<asp:CheckBox id="addNew" runat="server" Text="添加新闻"></asp:CheckBox>
						<asp:CheckBox id="chgnews" runat="server" Text="修改新闻"></asp:CheckBox>
						<asp:CheckBox id="chknews" runat="server" Text="审核新闻"></asp:CheckBox>
						<asp:CheckBox ID="remark" runat="server" Text="管理评论" />
						<br>
						(请从下边选择这些权限的适用范围)
						<br>
						分类名：
						<asp:RadioButtonList id="RadioButtonList1" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
						<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="*请选择管理分类!" ControlToValidate="RadioButtonList1"></asp:RequiredFieldValidator>
						<br>
						<asp:button ID="Submit" Text=" 修  改" runat="server" onclick="Submit_Click" /></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
