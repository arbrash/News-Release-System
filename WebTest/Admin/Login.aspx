<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebTest.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理登陆</title>
    <style type="text/css">
        .style1
        {
            height: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style="height: 376px">
    
        <table style="border: thin groove #C0C0C0; width: 400px; height: 230px;" 
            cellpadding="0" cellspacing="0">
            <tr>
                <td align="center" class="style1" style="background-color: #99CCFF">
                    管理登陆</td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;账 号： 
                    <asp:TextBox ID="Username" runat="server" Class="inputbg" Columns="10" 
                        MaxLength="15" Width="100px" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" 
                        ControlToValidate="UserName" ErrorMessage="*请输入账号！" 
                        ForeColor="Red" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;密 码： 
                    <asp:TextBox ID="Password" runat="server" Class="inputbg" Columns="10" 
                        MaxLength="15" textmode="Password" Width="100px" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="Password" ErrorMessage="*请输入密码！" 
                        ForeColor="Red" />
                    &nbsp;&nbsp;<br />
                    <br />
                    <asp:Button ID="Submit" runat="server" text="登 录" onclick="Submit_Click" />
                    <br />
                    </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
