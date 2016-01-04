<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebTest.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>分类新闻</title>
    <style type="text/css">
        .style1
        {
            height: 18px;
        }
        .style2
        {
            width: 213px;
        }
        .style3
        {
            height: 19px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 450px">
    
        <table align="center" border="0" style="height: 367px" width="800">
            <tr>
                <td width="800">
                    <div align="center">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="style3" width="800">
                    <strong><a href="../MainPage.aspx">新闻首页</a> 新闻类别：</strong><asp:DropDownList ID="DropDownClass" runat="server" AutoPostBack="True" 
                        Height="27px" onselectedindexchanged="DropDownClass_SelectedIndexChanged" 
                        Width="85px">
                        <asp:ListItem Value="新闻">新闻</asp:ListItem>
                        <asp:ListItem Value="体育">体育</asp:ListItem>
                        <asp:ListItem Value="科技">科技</asp:ListItem>
                    </asp:DropDownList>
&nbsp;<asp:Label ID="NameLabel" runat="server" class="padding:5px,0px"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    &nbsp;
                    </td>
            </tr>
            <tr>
                <td width="800">
                    <div align="left" style="height: 218px">
                        <asp:DataGrid ID="MyDataGrid" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" BackColor="White" BorderColor="Silver" 
                            BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" 
                            Width="789px" PageSize="5"
                            onpageindexchanged="MyDataGrid_PageIndexChanged">
                            <Columns>
                                <asp:TemplateColumn HeaderText="新闻标题">
                                    <EditItemTemplate>
                                        <font face="宋体"></font>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <a href='admin/show.aspx?articleid=<%#DataBinder.Eval(Container.DataItem, "articleid")%>'>
                                        <%# DataBinder.Eval(Container.DataItem, "title")%></a>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="dateandtime" HeaderText="时间"></asp:BoundColumn>
                                <asp:BoundColumn DataField="click" HeaderText="点击次数"></asp:BoundColumn>
                            </Columns>
                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                            <HeaderStyle BackColor="#99CCFF" Font-Bold="True" ForeColor="Black" 
                                Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                                Font-Underline="False" />
                            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Left" 
                                Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                Font-Strikeout="False" Font-Underline="False" Visible="False" />
                            <SelectedItemStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        </asp:DataGrid>
			<table align="center" style="width: 786px">
				<tr>
					<td class="style2">
						<div align="left"><asp:linkbutton id="btnFirst" onclick="PagerButtonClick" runat="server" Font-Bold="True" ForeColor="HotTrack" CommandArgument="first">首页||</asp:linkbutton><asp:linkbutton id="LinkButton2" onclick="PagerButtonClick" runat="server" Font-Bold="True" ForeColor="HotTrack" CommandArgument="prev">前页||</asp:linkbutton><asp:linkbutton id="LinkButton1" onclick="PagerButtonClick" runat="server" Font-Bold="True" ForeColor="HotTrack" CommandArgument="next" >下页||</asp:linkbutton><asp:linkbutton id="LinkButton3" onclick="PagerButtonClick" runat="server" Font-Bold="True" ForeColor="HotTrack" CommandArgument="last">尾页</asp:linkbutton></div>
					</td>
					<td class="style1">
						<div align="right">
                        <asp:Label ID="lblCurrentIndex" runat="server" Font-Bold="True" ForeColor="HotTrack"></asp:Label>
                        <asp:Label ID="lblPageCount" runat="server" Font-Bold="True" ForeColor="HotTrack"></asp:Label>
                        </div>
					</td>
				</tr>
			</table>
                        <br />
                        <br />
                    </div>
                </td>
            </tr>
            <tr>
                <td height="13" width="800">
                    <div align="center">
                        <table align="center" border="0" style="width: 101%">
                            <tr>
                                <td colspan="10" height="11">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="10" height="11">
                                </td>
                            </tr>
                            <tr>
                                <td height="11" width="42">
                                    &nbsp;</td>
                                <td height="11" width="54">
                                    &nbsp;</td>
                                <td height="11" width="53">
                                    &nbsp;</td>
                                <td height="11" width="53">
                                    &nbsp;</td>
                                <td height="11" width="53">
                                    &nbsp;</td>
                                <td height="11" width="53">
                                    &nbsp;</td>
                                <td height="11" width="54">
                                    &nbsp;</td>
                                <td height="11" width="73">
                                    &nbsp;</td>
                                <td height="11" width="72">
                                    &nbsp;</td>
                                <td height="11" width="112">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
