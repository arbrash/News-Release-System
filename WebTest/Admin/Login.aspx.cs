using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebTest.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["userclass"] = "";
                Session["pwd"] = "";
                Session["classname"] = "";
                Session["username"] = "";
            }
        }
        private void conn(string t1, string t2)	
        {
            try
            {
                string con = ConfigurationSettings.AppSettings["np"];	

                SqlConnection myConnection = new SqlConnection(con);
                myConnection.Open();									 

                SqlCommand cd = new SqlCommand("select * from Admin where username=@username and password=@password", myConnection);

                SqlParameter username = cd.Parameters.Add("@username", SqlDbType.NVarChar, 50);		
                SqlParameter password = cd.Parameters.Add("@password", SqlDbType.NVarChar, 50);
                username.Value = t1;
                password.Value = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(t2, "MD5");

                SqlDataReader selreader;	
                selreader = cd.ExecuteReader();				  

                if (selreader.Read() == true)					
                {
                    string popedom = selreader.GetString(6); 
                    Session["userclass"] = selreader.GetString(4);
                    Session["classname"] = selreader.GetString(3);
                    Session["popedom"] = selreader.GetString(6);
                    Session["pwd"] = selreader.GetString(2);
                    //Session["pwd"]=t2.ToString().Trim();
                    Session["id"] = selreader.GetInt64(0);
                    Session["power"] = selreader.GetString(6);
                    int i = popedom.Length;
                    string df = popedom.Replace("addnews", "1");
                    Session["popedom"] = df;
                    int j = df.Length;
                    if (i != j)
                    {
                        Session["addnews"] = 1;

                    }
                    else Session["addnews"] = 0;


                    i = popedom.Length;			         
                    df = popedom.Replace("chgnews", "1");
                    j = df.Length;
                    if (i != j)
                    {
                        Session["chgnews"] = 1;
                    }
                    else Session["chgnews"] = 0;

                    i = popedom.Length;			        
                    df = popedom.Replace("chknews", "1");
                    j = df.Length;
                    if (i != j)
                    {
                        Session["chknews"] = 1;
                    }
                    else Session["chknews"] = 0;

                    i = popedom.Length;			       
                    df = popedom.Replace("remark", "1");
                    j = df.Length;
                    if (i != j)
                    {
                        Session["remark"] = 1;
                    }
                    else Session["remark"] = 0;

                    selreader.Close();		
                    myConnection.Close();
                    Response.Redirect("admin_main.htm");	
                }
                else
                {
                    selreader.Close();		
                    myConnection.Close();
                    Label1.Text = "账号或密码错误！";

                }
            }
            catch (SqlException e)
            {
                Response.Write("Exception in Main: " + e.Message);	
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string username = Request["Username"]; 
                string password = Request["Password"];
                Session["username"] = username;
                conn(username, password);		 
            }
        }
    }
}