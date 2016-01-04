using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient ;
using System.Configuration ;
namespace WebNews.admin
{
	public partial class admin_main : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label CopyRight;
	
		public object num;
		public object num1;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				string username;
				username=(string)Session["username"];
				if(username.Trim()!="")
				{
					conn();	 
					getLabelText();
				}
				else Page.Visible=false;
			}
		}


		private	object selCkArticleNum()				 
		{	 
			try
			{
				
				string conn=ConfigurationSettings.AppSettings["np"];	
			
				SqlConnection con = new SqlConnection(conn);
				con.Open();

                SqlCommand cmd = new SqlCommand("select count(*) as co from Article where checkup=1", con);			
			
				SqlDataReader rd;
				rd=cmd.ExecuteReader();
				
				if(rd.Read())
				{
					num=rd["co"];
				}
			
				rd.Close();
				con.Close();
				return num;
			}
			catch(SqlException e)
			{
				Response.Write("Exception in Main: " + e.Message);	
				return num;
			}	
		}
	
		private	object selNckArticleNum()				  
		{	
			try
			{
				
				string conn=ConfigurationSettings.AppSettings["np"];	
			
				SqlConnection con = new SqlConnection(conn);
				con.Open();

                SqlCommand cmd = new SqlCommand("select count(*) as co from Article where checkup=0", con);			
			
				
				SqlDataReader rd;
				rd=cmd.ExecuteReader();
				
				if(rd.Read())
				{
					num1=rd["co"];
				}
			
				rd.Close();
				con.Close();
				return num1;
			}
			catch(SqlException e)
			{
				Response.Write("Exception in Main: " + e.Message);	
				return num1;
			}	
		}

		public string show(object a)
		{
			string username=(string)Session["username"];
			string b=(string)a;
			string c;
			if(username.Trim().ToString()==b.Trim().ToString() )
			{
				c="<font color=red bold=true>"+b+"</font>";
				 
			}
			else c=b  ;
			return c;
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN：该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		private void conn()	   
		{
			try
			{
				string con=ConfigurationSettings.AppSettings["np"];
			
				SqlConnection myConnection = new SqlConnection(con);
				myConnection.Open();
	　　   　　 
				SqlDataAdapter myCommand = new SqlDataAdapter();　
                myCommand.SelectCommand = new SqlCommand("select * from Admin", myConnection);
				
				DataSet ds = new DataSet();			
				myCommand.Fill(ds);
		　　　　
				myDL.DataSource=ds;			
				myDL.DataBind();
				myConnection.Close();
			}
			catch(SqlException e)
			{
				Response.Write("Exception in Main: " + e.Message);	
			}
		}
			
		private void getLabelText()								
		{
			SysInfo.Text=" <font color=0000FF  size=3 face=&middot;&frac12;&Otilde;&yacute;&Ecirc;&aelig;&Igrave;&aring;><strong> "+"系统信息："+"</strong></Font>";
            SysInfo.Text = SysInfo.Text + "发布新闻总数:  <font bold=true>" + selCkArticleNum() + "</font>" + "<br>" + "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" + "  待审新闻数:  <font bold=true>" + selNckArticleNum() + "</font><br><br>";
			string dr=(string)Session["classname"];
			string power="";		
				
			if((int)Session["addnews"]==1)
			{
				power="<font color=#FF0000 size=2>"+"添加新闻 "+"</font>";
			}
				
				
			if((int)Session["chgnews"]==1)
			{
				power=power+"<font color=#FF0000 size=2>"+"修改新闻 "+"</font>";
			}

			if((int)Session["chknews"]==1)
			{
				power=power+"<font color=#FF0000 size=2>"+"审核新闻 "+"</font>";
			}

            if ((int)Session["remark"] == 1)
            {
                power = power + "<font color=#FF0000 size=2>" + "评论管理 " + "</font>";
            }

			SysInfo.Text+=" <font color=0000FF  size=3 face=&middot;&frac12;&Otilde;&yacute;&Ecirc;&aelig;&Igrave;&aring;><strong> "+"您的权限："+"</strong></Font>";

			dr=dr.Trim().ToString();
			if(dr=="系统管理员")
			{
				SysInfo.Text+="您是系统管理员，拥有所有权限"+"<br><br>";
			}
			else
			{
				SysInfo.Text+="您是新闻管理员，拥有权限：";
                SysInfo.Text += power + "<br><br>" + " <font color=0000FF  size=3 face=&middot;&frac12;&Otilde;&yacute;&Ecirc;&aelig;&Igrave;&aring;><strong> " + "所属分类：" + "</strong></Font>" + "<font color=#FF0000 size=2>" + (string)Session["userclass"] + "</font>" + "<br>";
			}
		}
	}
}
