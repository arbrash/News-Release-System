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
				if(userclass.Trim()!="ϵͳ����Ա")
				{
					   Page.Visible=false;
				}
				
			}
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
				myLabel.Text="���д˹���Ա��������������������" ;
				readAdmin.Close();
				myConnection.Close();//�ر�����
			
				
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
				 

					myLabel.Text="��ӹ���Ա�ɹ���";
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
