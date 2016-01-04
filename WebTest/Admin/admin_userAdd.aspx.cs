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
using System.Configuration;
namespace WebNews.admin
{
	public partial class admin_userAdd : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.TextBox Remarks;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{

			if(! Page.IsPostBack)
			{
				string userclass;
				userclass=(string)Session["classname"];
				if(userclass.Trim()!="系统管理员")
				{
					   Page.Visible=false;
				}
				
			}
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

		protected void Submit_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid )
			{
				addAdminUser();
			}
		}
		private void addAdminUser()
		{
			string con=ConfigurationSettings.AppSettings["np"];	
			
			SqlConnection myConnection = new SqlConnection(con);
			myConnection.Open();									

            SqlCommand selAdmin = new SqlCommand("select * from Admin where username=@username", myConnection);	 
			
			SqlParameter sel=selAdmin.Parameters.Add("@username",SqlDbType.Char,40);
			sel.Value=Username.Text.Trim() ;
			
			SqlDataReader  readAdmin=selAdmin.ExecuteReader();
			
			if(readAdmin.Read()==true)
			{
				myLabel.Text="已有此管理员，请重新输入姓名！！" ;
				readAdmin.Close();
				myConnection.Close();//关闭连接
			
				
			}
			else 
			{
				try
				{
					readAdmin.Close();
                    SqlCommand cd = new SqlCommand("insert into Admin values(@username,@password,@classname,' ',0,' ')", myConnection);	

					SqlParameter username= cd.Parameters.Add("@username", SqlDbType.NVarChar,50);		 
					SqlParameter password=cd.Parameters.Add("@password",SqlDbType.NVarChar,500);
					SqlParameter userclass=cd.Parameters.Add("@classname",SqlDbType.NVarChar,50);

					username.Value=Username.Text.Trim();
					//password.Value=Password.Text.Trim();
                    

                    string pass = Password.Text.Trim();
                    string pwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "MD5");
                    password.Value = pwd;

					userclass.Value=UserClass.SelectedItem.Text.Trim(); 
					int se=cd.ExecuteNonQuery() ;
				 

					myLabel.Text="添加管理员成功！";
					myConnection.Close();
				}
				catch(SqlException e)
				{
					Response.Write("Exception in Main: " + e.Message);	
				}
			}

		}

	

	}
}
