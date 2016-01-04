<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="web1.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网上新闻发布系统</title>
    <style type="text/css">
        #form1
        {
            height: 761px;
            margin-bottom: 19px;
        }
        .style1
        {
            width: 295px;
        }
        .style2
        {
            width: 109px;
        }
        .style3
        {
            height: 22px;
        }
        .style6
        {
            height: 100px;
        }
        .style7
        {
            height: 411px;
        }
        .style8
        {
            width: 684px;
        }
        .style9
        {
            height: 273px;
        }
    </style>
</head>
<body style="height: 816px">
    <form id="form1" runat="server">
    <div style="height: 717px">
    
        <table style="width:802px; height: 65px;" align="center">
            <tr>
                <td class="style8">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image 
                        ID="Image1" runat="server" ImageAlign="Left" ImageUrl="~/pic/main-title2.jpg" 
                        Width="784px" />
                </td>
            </tr>
        </table>
    
        <table style="width: 800px; height: 440px;" align="center" border="0" 
            cellpadding="0" cellspacing="0">
            <tr>
                <td class="style2">
                    <table style="border: thin groove #CCCCCC; width: 228px; height: 447px;" 
                        border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="style3" align="center" style="background-color: #99CCFF">
                                ···<strong>热门新闻</strong>···</td>
                        </tr>
                        <tr>
                            <td align="center" class="style7" dir="ltr">
                                <table style="width:100%; height: 416px;" align="center" border="0" 
                                    cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="center" class="style9">
                                <asp:DataList ID="DataList4" runat="server" Height="134px" Width="204px">
                                    <ItemTemplate>
                                        <img src="pic/bullet.gif" />
                                        <a href='admin/show.aspx?articleid=<%#DataBinder.Eval(Container.DataItem, "articleid")%>'>
                                        <%# DataBinder.Eval(Container.DataItem, "title")%></a>
                                    </ItemTemplate>
                                </asp:DataList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="style3" style="background-color: #99CCFF">
                                            ···<strong>门户网站</strong>···</td>
                                    </tr>
                                    <tr>
                                    <td align="center">
                                <asp:AdRotator ID="AdRotator1" runat="server" AdvertisementFile="~/163.xml" BorderWidth="0"
                                    BorderColor="Black" />
                                        <br />
                                <asp:AdRotator ID="AdRotator2" runat="server" AdvertisementFile="~/sina.xml" />
                                    <br />
                                    </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                    <td class="style1">
                        <table style="border: thin groove #CCCCCC; width: 555px; height: 447px;" 
                            border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="style3" style="background-color: #99CCFF" >
                                    [<a href='list.aspx?classname=新闻' target="_parent"><strong>新闻</strong></a>]······</td>
                                
                            </tr>
                            <tr>
                                <td class="style6" align="left" style="background-color: #FFFFFF">
                                    <asp:DataList ID="DataList1" runat="server" style="margin-top: 0px">
                                        <ItemTemplate>
            <img src="pic/bullet.gif" />
                                            <a href='admin/show.aspx?articleid=<%#DataBinder.Eval(Container.DataItem, "articleid")%>'>
            <%# DataBinder.Eval(Container.DataItem, "title")%></a>(<font color="red"><%#((DateTime)DataBinder.Eval(Container.DataItem, "dateandtime")).ToShortDateString()%></font>,
                                            <font color="blue"><%#DataBinder.Eval(Container.DataItem, "click")%></font>)
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                                
                            </tr>
                            <tr>
                                <td class="style3" style="background-color: #99CCFF">
                                    [<a href='list.aspx?classname=体育' target="_parent"><strong>体育</strong></a>]······</td>
                                
                            </tr>
                            <tr>
                                <td class="style6" align="left">
                                    <asp:DataList ID="DataList2" runat="server">
                                        <ItemTemplate>
            <img src="pic/bullet.gif" />
                                            <a href='admin/show.aspx?articleid=<%#DataBinder.Eval(Container.DataItem, "articleid")%>'>
            <%# DataBinder.Eval(Container.DataItem, "title")%></a>(<font color="red"><%#((DateTime)DataBinder.Eval(Container.DataItem, "dateandtime")).ToShortDateString()%></font>,
                                            <font color="blue"><%#DataBinder.Eval(Container.DataItem, "click")%></font>)
                                        </ItemTemplate>
                                    </asp:DataList>
                                    </td>
                                
                            </tr>
                            <tr>
                                <td class="style3" style="background-color: #99CCFF">
                                    [<a href='list.aspx?classname=科技' target="_parent"><strong>科技</strong></a>]······</td>
                                
                            </tr>
                            <tr>
                                <td class="style6" align="left">
                                    <asp:DataList ID="DataList3" runat="server" Height="120px">
                                        <ItemTemplate>
            <img src="pic/bullet.gif" />
                                            <a href='admin/show.aspx?articleid=<%#DataBinder.Eval(Container.DataItem, "articleid")%>'>
            <%# DataBinder.Eval(Container.DataItem, "title")%></a>(<font color="red"><%#((DateTime)DataBinder.Eval(Container.DataItem, "dateandtime")).ToShortDateString()%></font>,
                                            <font color="blue"><%#DataBinder.Eval(Container.DataItem, "click")%></font>)
                                        </ItemTemplate>
                                    </asp:DataList>
                                    </td>
                                
                            </tr>
                        </table>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
