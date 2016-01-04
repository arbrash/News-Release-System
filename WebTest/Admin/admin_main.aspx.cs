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
			// CODEGEN���õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
	����   ���� 
				SqlDataAdapter myCommand = new SqlDataAdapter();��
                myCommand.SelectCommand = new SqlCommand("select * from Admin", myConnection);
				
				DataSet ds = new DataSet();			
				myCommand.Fill(ds);
		��������
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
			SysInfo.Text=" <font color=0000FF  size=3 face=&middot;&frac12;&Otilde;&yacute;&Ecirc;&aelig;&Igrave;&aring;><strong> "+"ϵͳ��Ϣ��"+"</strong></Font>";
            SysInfo.Text = SysInfo.Text + "������������:  <font bold=true>" + selCkArticleNum() + "</font>" + "<br>" + "&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp" + "  ����������:  <font bold=true>" + selNckArticleNum() + "</font><br><br>";
			string dr=(string)Session["classname"];
			string power="";		
				
			if((int)Session["addnews"]==1)
			{
				power="<font color=#FF0000 size=2>"+"������� "+"</font>";
			}
				
				
			if((int)Session["chgnews"]==1)
			{
				power=power+"<font color=#FF0000 size=2>"+"�޸����� "+"</font>";
			}

			if((int)Session["chknews"]==1)
			{
				power=power+"<font color=#FF0000 size=2>"+"������� "+"</font>";
			}

            if ((int)Session["remark"] == 1)
            {
                power = power + "<font color=#FF0000 size=2>" + "���۹��� " + "</font>";
            }

			SysInfo.Text+=" <font color=0000FF  size=3 face=&middot;&frac12;&Otilde;&yacute;&Ecirc;&aelig;&Igrave;&aring;><strong> "+"����Ȩ�ޣ�"+"</strong></Font>";

			dr=dr.Trim().ToString();
			if(dr=="ϵͳ����Ա")
			{
				SysInfo.Text+="����ϵͳ����Ա��ӵ������Ȩ��"+"<br><br>";
			}
			else
			{
				SysInfo.Text+="�������Ź���Ա��ӵ��Ȩ�ޣ�";
                SysInfo.Text += power + "<br><br>" + " <font color=0000FF  size=3 face=&middot;&frac12;&Otilde;&yacute;&Ecirc;&aelig;&Igrave;&aring;><strong> " + "�������ࣺ" + "</strong></Font>" + "<font color=#FF0000 size=2>" + (string)Session["userclass"] + "</font>" + "<br>";
			}
		}
	}
}
