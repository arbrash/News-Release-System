<%@ Page Language="c#" Inherits="WebNews.admin.admin_left" CodeBehind="admin_left.aspx.cs" AutoEventWireup="True" %>
<HTML>
	<HEAD>
		<style type="text/css"> body { background:#99CCFF; margin:0px; font:normal 12px 宋体; }
	table { border:0px; }
	td { font:normal 12px 宋体; }
	img { vertical-align:bottom; border:0px; }
	a { font:normal 12px 宋体; color:#215DC6; text-decoration:none; }
	a:hover { color:#428EFF }
	.sec_menu { border-left:1px solid white; border-right:1px solid white; border-bottom:1px solid white; background:#D6DFF7; padding:5px 2px;}
	.menu_title { }
	.menu_title span { position:relative; top:2px; left:8px; color:#215DC6; font-weight:bold; }
	.menu_title2 { }
	.menu_title2 span { position:relative; top:2px; left:8px; color:#428EFF; font-weight:bold; }
	</style>
		<script language="javascript">
function menuChange(obj,menu)
{
	if(menu.style.display=="")
	{
		obj.background="../pic/admin_title_bg_hide.gif";
		menu.style.display="none";
	}else{
		obj.background="../pic/admin_title_bg_show.gif";
		menu.style.display="";
	}
}

function proLoadimg()
{
	var i=new Image;
	i.src='pic/admin_title_bg_hide.gif';
}
proLoadimg();
		</script>
	</HEAD>
	<body>
		<table cellpadding="0" cellspacing="0" width="158" align="center">
			<tr>
				<td height="42" valign="bottom">
					<a href="admin_main.htm" target="_top"></a>&nbsp;
				</td>
			</tr>
			<tr height="25">
				<td background="../pic/admin_title_bg_quit.gif">
					&nbsp; &nbsp;<a href="Login.aspx" target="_top"><b>重登录</b></a>&nbsp; <a href="../MainPage.aspx" target="_top">
						<b>退出管理</b></a>
				</td>
			</tr>
		</table>
		&nbsp;
		<table cellpadding="0" cellspacing="0" width="158" align="center">
			<tr style="CURSOR:pointer">
				<td height="25" class="menu_title" background="../pic/admin_title_bg_show.gif" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" onclick="menuChange(this,menu1);">
					<span>新闻管理</span>
				</td>
			</tr>
			<tr>
				<td>
					<div class="sec_menu" style="WIDTH:152px" id="menu1">
						<table cellpadding="0" cellspacing="0" align="center" width="135">
							<tr height="20">
								<td>
									<% if(userAddPower((int)Session["addnews"],(string)	Session["classname"])){%>
									&nbsp;<a href="admin_articleAdd.aspx" target="right">添加新闻</a> &nbsp;| <a href="admin_article.aspx" target="right">新闻管理</a>
									<%}%>
									<%else{%>
									<a href="admin_article.aspx" target="right">&nbsp;新闻管理</a><%}%>
								</td>
							</tr>
							<tr height="20">
								<td>
                                <% if(checkPower((int)Session["addnews"],(string)	Session["classname"])){%>
									&nbsp;<a href="admin_check.aspx" target="right">新闻审核</a>
                                    <%}%>
									<% if (validateUserClass((string)Session["classname"])){ %>
								</td>
							</tr>
							<%}%>
						</table>
					</div>
				</td>
			</tr>
		</table>
		&nbsp;
		<% if (validateUserClass((string)Session["classname"])){ %>
		&nbsp;
		<DIV></DIV>
		</TD></TR></TABLE>&nbsp;
		<%}%>
		<table cellpadding="0" cellspacing="0" width="158" align="center">
			<tr style="CURSOR:pointer">
				<td height="25" class="menu_title" background="../pic/admin_title_bg_show.gif" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" onclick="menuChange(this,menu4);">
					<span>用户管理</span>
				</td>
			</tr>
			<tr>
				<td>
					<div class="sec_menu" style="WIDTH:152px" id="menu4">
						<table cellpadding="0" cellspacing="0" align="center" width="135">
							<% if (validateUserClass((string)Session["classname"])){ %>
							<tr height="20">
								<td>&nbsp;<a href="admin_userAdd.aspx" target="right">添加管理员</a> | <a href="admin_user.aspx" target="right">
										管理</a></td>
							</tr>
							<%}%>
							<tr height="20">
								<td>&nbsp;<a href="admin_change.aspx" target="right">账号修改</a></td>
							</tr>
						</table>
					</div>
				</td>
			</tr>
		</table>
		&nbsp;
		<% if (validateUserClass((string)Session["classname"])){ %>
		&nbsp;
		<%}%>
		<br>
		<br>
	</body>
</HTML>
