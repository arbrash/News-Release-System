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

	public partial class _1 : System.Web.UI.Page
	{   public string ClassName; 
		protected System.Web.UI.WebControls.CheckBox addNchk;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				string userclass;
				userclass=(string)Session["classname"];
				if(userclass.Trim()=="系统管理员")
				{
					validateCheckBox();
					bindRadioButtonList();
				}
				else Page.Visible=false;
			}  
		}
		private void validateCheckBox()
		{
			try
			{ 
				string con=ConfigurationSettings.AppSettings["np"];	
			
				SqlConnection myConnection = new SqlConnection(con);
				myConnection.Open();
	　　   　　 
				SqlDataAdapter myCommand = new SqlDataAdapter();　

                myCommand.SelectCommand = new SqlCommand("select * from Admin where username=@username", myConnection);		
				SqlParameter username=myCommand.SelectCommand.Parameters.Add("@username",SqlDbType.Char,40);	
				username.Value=Request["username"];
				myLabel.Text="用户"+Request["username"]+"的权限";					
				
				DataSet ds = new DataSet();			
				myCommand.Fill(ds,"Admin");
				

		　　　　DataRow dr;
				dr=ds.Tables["Admin"].Rows[0]  ;
				
				ClassName=(string)dr["classname"];
				
				if(dr["popedom"]!=null)
				{
					string popedom=(string)dr["popedom"];	
					int i=popedom.Length;
					string df=popedom.Replace("addnews","1");
					int j=df.Length ;
					if(i!=j)
					{
						addNew.Checked=true;
					}
					

					i=popedom.Length;			         //验证是否有修改新闻的权限
					df=popedom.Replace("chgnews","1");
					j=df.Length ;
					if(i!=j)
					{
						chgnews.Checked=true;
					}
					
					i=popedom.Length;			         //验证是否有审核新闻的权限
					df=popedom.Replace("chknews","1");
					j=df.Length ;
					if(i!=j)
					{
						chknews.Checked=true;
					}

                    i = popedom.Length;			         //验证是否有管理评论的权限
                    df = popedom.Replace("remark", "1");
                    j = df.Length;
                    if (i != j)
                    {
                        remark.Checked = true;
                    }
				}
					myConnection.Close();
			}
			catch(SqlException e)
			{
				Response.Write("Exception in Main: " + e.Message);	

			}
		}
		private void bindRadioButtonList()
		{
			try
			{
				string con=ConfigurationSettings.AppSettings["np"];
			
				SqlConnection myConnection = new SqlConnection(con);
				myConnection.Open();
	　　   　　 
				SqlDataAdapter selClassAll = new SqlDataAdapter();　

                selClassAll.SelectCommand = new SqlCommand("select * from Class", myConnection);		 
		   
				DataSet dt = new DataSet();
				selClassAll.Fill(dt);
			
				RadioButtonList1.DataSource=dt;									 
				RadioButtonList1.DataTextField="className";
				RadioButtonList1.DataValueField="className";
				RadioButtonList1.DataBind();
				myConnection.Close();
				int i = 0;

				foreach(ListItem li in RadioButtonList1.Items)					
				{
					if(li.Text ==ClassName)
					{
						li.Selected = true; 
					}
					i += 1;
				}
			}
			catch(SqlException e)
			{
				Response.Write("Exception in Main: " + e.Message);	
        	}

}
        private void updateAdminPower()
        {
            string popedom = "";
            if (addNew.Checked == true)
            {
                popedom = "addnews,";
            }
            if (chgnews.Checked == true)
            {
                popedom += "chgnews,";
            }
            if (chknews.Checked == true)
            {
                popedom += "chknews,";
            }
            if (remark.Checked == true)
            {
                popedom += "remark,";
            }

            try
            {
                string con = ConfigurationSettings.AppSettings["np"];	

                SqlConnection myConnection = new SqlConnection(con);
                myConnection.Open();                             

                SqlCommand updatePower = new SqlCommand("update Admin set popedom=@popedom,userclass=@userclass where username=@username", myConnection);	  

                SqlParameter Popedom = updatePower.Parameters.Add("@popedom", SqlDbType.NVarChar, 500);			
                SqlParameter userclass = updatePower.Parameters.Add("@userclass", SqlDbType.NVarChar, 500);
                SqlParameter username = updatePower.Parameters.Add("@username", SqlDbType.NVarChar, 50);

                username.Value = Request["username"];
                Popedom.Value = popedom;
                userclass.Value = RadioButtonList1.SelectedItem.Text;

                int r = updatePower.ExecuteNonQuery();	 

                if (r > 0)
                {
                    Response.Redirect("admin_user.aspx");		
                }

            }
            catch (SqlException e)
            {
                Response.Write("Exception in Main: " + e.Message);	
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
            if (Page.IsValid)
            {
                updateAdminPower();
            }
        }
	}
}
