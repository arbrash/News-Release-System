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
using System.Data.SqlClient;
using System.Configuration;
namespace WebNews.admin
{

	public partial class admin_user : System.Web.UI.Page
	{	
		string con=ConfigurationSettings.AppSettings["np"];	
		public DataSet ds=new DataSet();
		DataRow dr;
		public string	classname;
		public string oldusername;
        public string olduserclass;
		
		protected System.Web.UI.WebControls.DropDownList Classname;
		protected System.Web.UI.WebControls.TextBox Remark;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(! Page.IsPostBack)
			{
				string classname;
				classname=(string)Session["classname"];
				if(classname.Trim()=="系统管理员")
				{
					getAdmin();
				}
				else Page.Visible=false;
			}
		}
		private void getAdmin()	  
		{
			try
			{
                string con = ConfigurationSettings.AppSettings["np"];
				SqlConnection  conn = new SqlConnection(con);
				conn.Open();
	　　   　　 
				SqlDataAdapter myCommand = new SqlDataAdapter();　　
                myCommand.SelectCommand = new SqlCommand("select * from Admin where username!='admin'", conn);

				myCommand.Fill(ds,"Admin");
		　　　　
				MyDataGrid.DataSource=ds;			 
				MyDataGrid.DataBind();
			
				lblCurrentIndex.Text="第"+((Int32)MyDataGrid.CurrentPageIndex+1)+"页";
				lblPageCount.Text="/共"+MyDataGrid.PageCount+"页";
				conn.Close();
			}
			catch(SqlException e)
			{
				Response.Write("Exception in Main: " + e.Message);	
			}

		}

        public string show(object a, object b)
        {
            string d = a.ToString();
            string c = a + "(<a href=admin_popedom.aspx?username=" + b + ">修改权限</a></font>)";
            if (d.Trim() == "系统管理员")
            {
                return d;
            }
            else
            {
                return c;
            }
        }

		public	void PagerButtonClick(Object sender, EventArgs e)		
		{
			
			string arg = ((LinkButton)sender).CommandArgument;

			switch(arg)
			{
				case ("next"):
					if (MyDataGrid.CurrentPageIndex < (MyDataGrid.PageCount - 1))
						MyDataGrid.CurrentPageIndex ++;
					break;
				case ("prev"):
					if (MyDataGrid.CurrentPageIndex > 0)
						MyDataGrid.CurrentPageIndex --;
					break;
				case ("last"):
					MyDataGrid.CurrentPageIndex = (MyDataGrid.PageCount - 1);
					break;
				case("first"):
					MyDataGrid.CurrentPageIndex =0;
					break;
			}
			getAdmin();
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

	

		public void MyDataGrid_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{	 
			 this.MyDataGrid.EditItemIndex = e.Item.ItemIndex;
			 
			getAdmin();
			
			dr=ds.Tables["Admin"].Rows[MyDataGrid.EditItemIndex]  ; 
			classname=(string)dr["classname"];
			classname=classname.Trim();
            Session["oldclassname"] = classname;
			oldusername=(string)dr["username"];
			oldusername=oldusername.Trim();
			Session["oldusername"]=oldusername;
		}

		public void MyDataGrid_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			 this.MyDataGrid.EditItemIndex = -1;
			
			 getAdmin();
		}
	

		public void MyDataGrid_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(Page.IsValid)
			{
                try
                {
                    SqlConnection myConnection = new SqlConnection(con);
                    myConnection.Open();

                    TextBox Username = (TextBox)e.Item.Cells[1].Controls[1];				
                    TextBox Password = (TextBox)e.Item.Cells[2].Controls[1];
                    DropDownList Classname = (DropDownList)e.Item.Cells[3].Controls[1];
                    string dr = Username.Text;
                    dr = dr.Trim();
                    string de = (string)Session["oldusername"];
                    de = de.Trim();
                    if (de == dr)
                    {
                        SqlCommand updateAdmin = new SqlCommand("update Admin set username=@username,password=@password,classname=@classname where id=@id", myConnection);  
                        SqlParameter id = updateAdmin.Parameters.Add("@id", SqlDbType.BigInt);			   
                        SqlParameter username = updateAdmin.Parameters.Add("@username", SqlDbType.NVarChar, 50);
                        SqlParameter password = updateAdmin.Parameters.Add("@password", SqlDbType.NVarChar, 500);
                        SqlParameter classname = updateAdmin.Parameters.Add("@classname", SqlDbType.NVarChar, 50);

                        id.Value = this.MyDataGrid.DataKeys[(int)e.Item.ItemIndex];		  
                        username.Value = Username.Text.Trim();
                        password.Value = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text.Trim(), "MD5"); 
                        classname.Value = Classname.SelectedItem.Text.Trim();

                        string d1 = (string)Session["oldclassname"];
                        if (d1 != Classname.Text.Trim())
                        {
                            if (Classname.Text == "系统管理员")
                            {
                                SqlCommand updateAdmin1 = new SqlCommand("update Admin set userclass=@userclass,popedom=@popedom where id=@id", myConnection);
                                SqlParameter userclass = updateAdmin1.Parameters.Add("@userclass", SqlDbType.NVarChar, 50);
                                SqlParameter popedom = updateAdmin1.Parameters.Add("@popedom", SqlDbType.NVarChar, 500);
                                SqlParameter userid = updateAdmin1.Parameters.Add("@id", SqlDbType.BigInt);
                                userclass.Value = "所有分类".Trim();
                                popedom.Value = "addnews,chgnews,chknews,remark".Trim();
                                userid.Value = this.MyDataGrid.DataKeys[(int)e.Item.ItemIndex];

                                int rt1 = updateAdmin1.ExecuteNonQuery();	
                            }
                            if (Classname.Text == "新闻管理员")
                            {
                                SqlCommand updateAdmin1 = new SqlCommand("update Admin set userclass=@userclass,popedom=@popedom where id=@id", myConnection);
                                SqlParameter userclass = updateAdmin1.Parameters.Add("@userclass", SqlDbType.NVarChar, 50);
                                SqlParameter popedom = updateAdmin1.Parameters.Add("@popedom", SqlDbType.NVarChar, 500);
                                SqlParameter userid = updateAdmin1.Parameters.Add("@id", SqlDbType.BigInt);
                                userclass.Value = " ";
                                popedom.Value = " ";
                                userid.Value = this.MyDataGrid.DataKeys[(int)e.Item.ItemIndex];

                                int rt1 = updateAdmin1.ExecuteNonQuery();	
                            }
                        }
                        else
                        {

                        }
                        int rt = updateAdmin.ExecuteNonQuery();	
                        if (rt > 0)
                        {
                            myLabel.Text = "更新成功！";

                            MyDataGrid.EditItemIndex = -1;		
                            myConnection.Close();
                            getAdmin();
                        }
                        else
                        {
                            myLabel.Text = "更新错误！";
                            myConnection.Close();
                        }
                    }
                    else
                    {
                        SqlCommand validateAdmin = new SqlCommand("select * from Admin where username=@username", myConnection);
                        SqlParameter vlaidateUsername = validateAdmin.Parameters.Add("@username", SqlDbType.Char, 40);
                        vlaidateUsername.Value = Username.Text;
                        SqlDataReader validateReader = validateAdmin.ExecuteReader();
                        if (validateReader.Read() == true)
                        {
                            myLabel.Text = "已有此用户名，请重新输入一个！！";
                            validateReader.Close();
                            myConnection.Close();
                        }

                        else
                        {
                            validateReader.Close();
                            SqlCommand updateAdmin = new SqlCommand("update Admin set username=@username,password=@password,classname=@classname where id=@id", myConnection);   
                            SqlParameter id = updateAdmin.Parameters.Add("@id", SqlDbType.BigInt);			  
                            SqlParameter username = updateAdmin.Parameters.Add("@username", SqlDbType.NVarChar, 50);
                            SqlParameter password = updateAdmin.Parameters.Add("@password", SqlDbType.NVarChar, 500);
                            SqlParameter classname = updateAdmin.Parameters.Add("@classname", SqlDbType.NVarChar, 50);

                            id.Value = this.MyDataGrid.DataKeys[(int)e.Item.ItemIndex];		  
                            username.Value = Username.Text;
                            password.Value = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text.Trim(), "MD5");
                            classname.Value = Classname.SelectedItem.Text;

                            int rt = updateAdmin.ExecuteNonQuery();	
                            if (rt > 0)
                            {
                                myLabel.Text = "更新成功！";

                                MyDataGrid.EditItemIndex = -1;		
                                myConnection.Close();
                                getAdmin();
                            }
                            else
                            {
                                myLabel.Text = "更新错误！";
                                myConnection.Close();
                            }
                        }
                    }
                }
                catch (SqlException er)		
                {
                    Response.Write("SqlException in Main: " + er.Message);
                }
		               
		}
		}

		
		public void MyDataGrid_SelectedIndexChanged(object sender,System.EventArgs e)
		{
			        
			getAdmin();
		}
        public void Dropdownlist2_SelectedIndexChanged(object sender, System.EventArgs e)
        {


        }

			public void MyDataGrid_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
				
					try
					{
						SqlConnection conn=new SqlConnection(con);			
						conn.Open();
                        SqlCommand delAdmin = new SqlCommand("delete  from Admin where id=@id", conn);		

						SqlParameter id=delAdmin.Parameters.Add("@id",SqlDbType.BigInt);
						id.Value=this.MyDataGrid.DataKeys[e.Item.ItemIndex] ;		  
                        
						int r=delAdmin.ExecuteNonQuery();	 
						if(r>0)
						{
							myLabel.Text="删除成功！";
							conn.Close();
							MyDataGrid.EditItemIndex = -1;	
							
							if(MyDataGrid.CurrentPageIndex>0)
							{

								MyDataGrid.CurrentPageIndex= MyDataGrid.CurrentPageIndex-1;
							}
							getAdmin();

						}
						else
						{
							myLabel.Text="删除错误！";
							conn.Close();
							MyDataGrid.EditItemIndex = -1;	
							
							getAdmin();

						}

					}
					catch(SqlException er)
					{ 
						Response.Write("SqlException in Main: " + er.Message);
					}

            }

    }
}

