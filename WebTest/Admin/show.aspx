<%@ Page Language="c#" Inherits="WebNews.show" EnableSessionState="false" EnableViewState="false"
    CodeBehind="show.aspx.cs" AutoEventWireup="True" %>

<html>
<head>
    <title>
        <%=title%>
    </title>
    <style type="text/css">
        #body
        {
            height: 122px;
        }
        .style1
        {
            width: 420px;
        }
        .style2
        {
            width: 529px;
            height: 246px;
        }
        #username
        {
            width: 302px;
        }
        .style3
        {
            width: 544px;
        }
        .style4
        {
            height: 246px;
        }
        #printBody
        {
            height: 848px;
        }
        .border
        {
            width: 704px;
        }
    </style>
</head>
<body>
    <span id="printScript" name="printScript"></span>
    <script language="javascript" src="inc/print.js"></script>
    <br>
    <div id="printBody" name="printBody">
        <table class="border" cellspacing="0" align="center">
            <tr height="25">
                <td class="title2">
                    <asp:Label ID="BackLabel" runat="server"></asp:Label><a href="../MainPage.aspx">新闻首页</a>＞＞<a
                        href="../list.aspx?classname=<%=classname%>"><%=classname%></a>
                </td>
            </tr>
            <form id="Form1" name="remarkForm" method="post" runat="server">
            <tr>
                <td class="tdbg" valign="top" style="border-style: groove; border-width: thin">
                    <div style="background-color: #99CCFF; height: 23px;">
                    </div>
                    <center class="aTitle" style="font-size: x-large">
                        <strong>
                            <%=title%></strong></center>
                    <table width="100%">
                        <tr>
                            <td class="style3">
                            </td>
                            <td>
                                作者：<asp:Label ID="AuthorLabel" runat="server"></asp:Label><%=writer%>
                                <br />
                                来源：<asp:Label ID="SourceLabel" runat="server"></asp:Label><%=source%>
                                <br />
                                <br>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div align="center">
                        <asp:Image ID="Image1" runat="server" />
                        <br />
                        <asp:Label ID="Label1" runat="server" Font-Size="X-Small"></asp:Label>
                    </div>
                    <br />
                    <asp:Label class="content" ID="BodyLabel" Style="padding-right: 10px; display: block;
                        padding-left: 10px; padding-bottom: 0px; padding-top: 0px" runat="server"></asp:Label><%= Server.HtmlDecode(content)%><br>
                    <br>
                    <br>
                    <br>
                    <br>
                    <br>
                    <br>
                    <br>
                    <br>
                    <table style="table-layout: fixed; word-break: break-all" cellspacing="0" cellpadding="0"
                        width="100%">
                        <tr>
                            <td class="style1">
                            </td>
                            <td width="150">
                                阅读：<asp:Label ID="HitsLabel" runat="server"></asp:Label><%=click%>次<br>
                                日期：<asp:Label ID="TimeLabel" runat="server"></asp:Label><%=de%><br>
                                <br>
                            </td>
                            <tr>
                                <td align="justify" colspan="2">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    【 <a href="javascript:window.print()">打印本页</a> 】
                                </td>
                            </tr>
                    </table>
                    <table width="97%" align="center">
                        <tr>
                            <td>
                                上一篇：<asp:HyperLink ID="HyperLink1" runat="server"><A href="../admin/show.aspx?articleid=<%=aidp%>"><%=titlep%></A></asp:HyperLink>
                                <br>
                                下一篇：<asp:HyperLink ID="NextLink" runat="server"><A href="../admin/show.aspx?articleid=<%=aidn%>"><%=titlen%></A></asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr height="25">
                <td class="title1" align="middle" style="border-width: thin; border-style: groove;
                    background-color: #99CCFF;">
                    发表评论
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <table cellspacing="0" cellpadding="5" width="100%" border="0" style="height: 276px">
                        <tbody runat="server">
                            <tr>
                                <td class="style2" style="border-style: groove; border-width: thin">
                                    点评：
                                    <textarea id="body" name="body" cols="40" runat="server"></textarea>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="body"
                                        ErrorMessage="*请输入点评！"></asp:RequiredFieldValidator>
                                    <br>
                                    姓名：
                                    <input id="username" type="text" maxlength="15" name="username" runat="server" length="20">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*请输入姓名！"
                                        ControlToValidate="username"></asp:RequiredFieldValidator><br>
                                    <br>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button1" runat="server" Text="发　表" Width="74px" OnClick="Button1_Click">
                                    </asp:Button>
                                </td>
                                <td width="350" style="border-style: groove; border-width: thin" class="style4">
                                    <ul style="margin-left: 1em; line-height: 150%; margin:10;padding:10;list-style-type: square">
                                        <li>尊重网上道德，遵守中华人民共和国的各项有关法律法规</li>
                                            <li>承担一切因您的行为而直接或间接导致的民事或刑事法律责任</li>
                                                <li>本站管理人员有权保留或删除其管辖留言中的任意内容</li>
                                                    <li>本站有权在网站内转载或引用您的评论</li>
                                                        <li>参与本评论即表明您已经阅读并接受上述条款 </li>
                                    </ul>
                                </td>
                        </tbody>
                    </table>
                    <table width="753" style="border: thin groove #CCCCCC;">
                        <tr height="25">
                            <td width="50%" class="title1" style="background-color: #99CCFF">
                                &gt;&gt; 新闻点评
                            </td>
                        </tr>
                        <tr>
                            <td class="tdbg">
                                <div>
                                    <asp:DataList ID="DataList1" runat="server" Width="745px">
                                        <ItemTemplate>
                                            网友 <b>
                                                <%# DataBinder.Eval(Container.DataItem,"username")%>
                                            </b>于<font class="gray"><%# DataBinder.Eval(Container.DataItem,"dateAndTime")%></font>发表评论
                                            <span style="padding: 5px 10px 5px 30px; width=100%; word-break: break-all">
                                                <%# DataBinder.Eval(Container.DataItem,"body")%>
                                            </span>
                                            <br>
                                            <tr height="1">
                                                <td class="hr">
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                                <div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <div>
            </div>
        </table>
        </form> </table>
    </div>
</body>
</html>
