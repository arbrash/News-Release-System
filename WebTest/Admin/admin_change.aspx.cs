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
    public partial class admin_change : System.Web.UI.Page
    {
        string Oldpswd;
        protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator;
        protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
        protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string username;
                username = (string)Session["username"];
                if (username.Trim() != "")
                {
                    Username.Text = (string)Session["username"];
                    oldUsername.Value = (string)Session["username"];
                }
                else Page.Visible = false;
            }
        }
        private bool validateUser()		
        {
            try
            {
                string con = ConfigurationSettings.AppSettings["np"];	
                SqlConnection conn = new SqlConnection(con);
                conn.Open();

                SqlCommand val = new SqlCommand("select * from Admin where username=@username", conn);  
                SqlParameter user = val.Parameters.Add("@username", SqlDbType.NVarChar, 50);			   
                user.Value = Username.Text.Trim();
                SqlDataReader rd;
                rd = val.ExecuteReader();

                if (rd.Read() == true)
                {
                    Label1.Text = "���д��û�";
                    return false;
                }
                else
                    return true;
            }
            catch (SqlException e)									 
            {
                Response.Write("SqlException in Main: " + e.Message);
                return false;
            }

        }
        private void updatepwd(string d)									
        {
            try
            {
                string con = ConfigurationSettings.AppSettings["np"];
                SqlConnection conn = new SqlConnection(con);
                conn.Open();
                SqlCommand val = new SqlCommand("update Admin set password=@password where id=@id", conn);   
                SqlParameter pwd = val.Parameters.Add("@password", SqlDbType.NVarChar, 500);
                pwd.Value = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(d, "MD5");
                SqlParameter id = val.Parameters.Add("@id", SqlDbType.BigInt);			 
                id.Value = (Int64)Session["id"];
                int i = val.ExecuteNonQuery();
                if (i > 0)
                {
                    Label1.Text = "�޸ĳɹ�!";
                }
            }
            catch (SqlException e)
            {
                Response.Write("SqlException in Main: " + e.Message);
            }

        }

        private void upPwdAndUser(string d, string f)						 
        {
            try
            {
                string con = ConfigurationSettings.AppSettings["np"];	
                SqlConnection conn = new SqlConnection(con);
                conn.Open();


                SqlCommand val = new SqlCommand("update Admin set username=@username,password=@password where id=@id", conn);   
                SqlParameter pwd = val.Parameters.Add("@password", SqlDbType.NVarChar, 500);
                pwd.Value = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(d, "MD5");
                SqlParameter ur = val.Parameters.Add("@username", SqlDbType.NVarChar, 50);			   
                ur.Value = f;
                SqlParameter id = val.Parameters.Add("@id", SqlDbType.BigInt);			   
                id.Value = (Int64)Session["id"];


                int i = val.ExecuteNonQuery();								

                if (i > 0)
                {
                    Label1.Text = "�޸ĳɹ�";

                }
                else Label1.Text = "�޸�ʧ��";

            }
            catch (SqlException e)
            {
                Response.Write("SqlException in Main: " + e.Message);
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
            string pwd = (string)Session["pwd"];
            string newpwd = Password.Text;
            string oldpwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(oldPassword.Text, "MD5");
            string user = Username.Text;
            string olduser = oldUsername.Value;

            pwd = pwd.Trim();
            oldpwd = oldpwd.Trim();
            newpwd = newpwd.Trim();
            user = user.Trim();
            olduser = olduser.Trim();

            try
            {
                string conn = ConfigurationSettings.AppSettings["np"];	
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select * from Admin where id=@id";
                SqlParameter id = cmd.Parameters.Add("@id", SqlDbType.BigInt);			   
                id.Value = (Int64)Session["id"];
                SqlDataReader Sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (Sdr.HasRows)
                {
                    while (Sdr.Read())
                    {
                        Oldpswd = Sdr.GetValue(2).ToString().Trim();
                    }
                }
                Sdr.Close();
            }
            catch (SqlException ex)
            {
                Response.Write("SqlException in Main: " + ex.Message);
            }
            if (Page.IsValid)
            {
                if (oldpwd == Oldpswd)
                {
                    if (user == olduser)
                    {

                        updatepwd(newpwd);
                    }
                    else
                    {
                        if (validateUser())
                        {

                            upPwdAndUser(newpwd, user);

                        }

                    }

                }
                else
                {
                    Label1.Text = "�������";

                }
            }
        }
    }
}
