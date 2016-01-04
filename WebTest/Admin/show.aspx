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
                    <asp:Label ID="BackLabel" runat="server"></asp:Label><a href="../MainPage.aspx">������ҳ</a>����<a
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
                                ���ߣ�<asp:Label ID="AuthorLabel" runat="server"></asp:Label><%=writer%>
                                <br />
                                ��Դ��<asp:Label ID="SourceLabel" runat="server"></asp:Label><%=source%>
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
                                �Ķ���<asp:Label ID="HitsLabel" runat="server"></asp:Label><%=click%>��<br>
                                ���ڣ�<asp:Label ID="TimeLabel" runat="server"></asp:Label><%=de%><br>
                                <br>
                            </td>
                            <tr>
                                <td align="justify" colspan="2">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    �� <a href="javascript:window.print()">��ӡ��ҳ</a> ��
                                </td>
                            </tr>
                    </table>
                    <table width="97%" align="center">
                        <tr>
                            <td>
                                ��һƪ��<asp:HyperLink ID="HyperLink1" runat="server"><A href="../admin/show.aspx?articleid=<%=aidp%>"><%=titlep%></A></asp:HyperLink>
                                <br>
                                ��һƪ��<asp:HyperLink ID="NextLink" runat="server"><A href="../admin/show.aspx?articleid=<%=aidn%>"><%=titlen%></A></asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr height="25">
                <td class="title1" align="middle" style="border-width: thin; border-style: groove;
                    background-color: #99CCFF;">
                    ��������
                </td>
            </tr>
            <tr>
                <td class="tdbg">
                    <table cellspacing="0" cellpadding="5" width="100%" border="0" style="height: 276px">
                        <tbody runat="server">
                            <tr>
                                <td class="style2" style="border-style: groove; border-width: thin">
                                    ������
                                    <textarea id="body" name="body" cols="40" runat="server"></textarea>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="body"
                                        ErrorMessage="*�����������"></asp:RequiredFieldValidator>
                                    <br>
                                    ������
                                    <input id="username" type="text" maxlength="15" name="username" runat="server" length="20">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*������������"
                                        ControlToValidate="username"></asp:RequiredFieldValidator><br>
                                    <br>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button1" runat="server" Text="������" Width="74px" OnClick="Button1_Click">
                                    </asp:Button>
                                </td>
                                <td width="350" style="border-style: groove; border-width: thin" class="style4">
                                    <ul style="margin-left: 1em; line-height: 150%; margin:10;padding:10;list-style-type: square">
                                        <li>�������ϵ��£������л����񹲺͹��ĸ����йط��ɷ���</li>
                                            <li>�е�һ����������Ϊ��ֱ�ӻ��ӵ��µ����»����·�������</li>
                                                <li>��վ������Ա��Ȩ������ɾ�����Ͻ�����е���������</li>
                                                    <li>��վ��Ȩ����վ��ת�ػ�������������</li>
                                                        <li>���뱾���ۼ��������Ѿ��Ķ��������������� </li>
                                    </ul>
                                </td>
                        </tbody>
                    </table>
                    <table width="753" style="border: thin groove #CCCCCC;">
                        <tr height="25">
                            <td width="50%" class="title1" style="background-color: #99CCFF">
                                &gt;&gt; ���ŵ���
                            </td>
                        </tr>
                        <tr>
                            <td class="tdbg">
                                <div>
                                    <asp:DataList ID="DataList1" runat="server" Width="745px">
                                        <ItemTemplate>
                                            ���� <b>
                                                <%# DataBinder.Eval(Container.DataItem,"username")%>
                                            </b>��<font class="gray"><%# DataBinder.Eval(Container.DataItem,"dateAndTime")%></font>��������
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
