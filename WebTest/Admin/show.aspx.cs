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
namespace WebNews
{

	public partial class show : System.Web.UI.Page
	{
		public string title;
        public string titlen;
        public string titlep;
		public string content;
        public string artpic;
        public string pictitle;
		public Int64 aid;
        public Int64 aidn;
        public Int64 aidp;
		public string classname;
		public string Nkey;
		public string writer;
		public DateTime de;
		public string source;
		protected System.Web.UI.WebControls.Repeater myrt;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label PageLabel;
		protected System.Web.UI.WebControls.Repeater Repeater1;
		protected System.Web.UI.WebControls.HyperLink PreviousLink;
		protected System.Web.UI.WebControls.RadioButtonList face;
		protected System.Web.UI.WebControls.Label Label1;
		
		public Int64 click;
		protected void Page_Load(object sender, System.EventArgs e)
		{

            if (Request["articleid"] == "" || Request["articleid"] == null)
            {
                Response.Redirect("../MainPage.aspx");
            }
			if(!Page.IsPostBack)
			{	
	
				
				addClick();
				getArticle();
				getRemark();
			}
		}
        public void ListClass(string de)			
        {
            try
            {
                string con = ConfigurationSettings.AppSettings["np"];
                SqlConnection conn = new SqlConnection(con);
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Class", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd;
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    Response.Write(de + "<a href=../list.aspx?classname=" + rd.GetString(1) + ">" + rd.GetString(1) + "</a>");

                }

                rd.Close();
                conn.Close();
            }
            catch (SqlException e)
            {
                Response.Write("Exception in Main: " + e.Message);

            }

        }



		private void getArticle()
		{	 
			try
			{
				string con=ConfigurationSettings.AppSettings["np"];
				SqlConnection  conn = new SqlConnection(con);
				conn.Open();
                SqlCommand cd = new SqlCommand("select * from Article where articleid=@articleid", conn);
                SqlCommand cdp = new SqlCommand("select top 1 * from Article where articleid<@articleid order by articleid desc", conn);
                SqlCommand cdn = new SqlCommand("select top 1 * from Article where articleid>@articleid order by articleid", conn);
                SqlParameter ids = cd.Parameters.Add("@articleid", SqlDbType.BigInt);
                ids.Value = Request["articleid"];
                SqlParameter idp = cdp.Parameters.Add("@articleid", SqlDbType.BigInt);
                idp.Value = Request["articleid"];
                SqlParameter idn = cdn.Parameters.Add("@articleid", SqlDbType.BigInt);
                idn.Value = Request["articleid"];
                
				SqlDataReader rd;
				rd=cd.ExecuteReader();
                if (rd.Read() == true)
                {
                    aid = rd.GetInt64(0);
                    title = rd.GetString(2);
                    content = rd.GetString(1);
                    classname = rd.GetString(6);
                    writer = rd.GetString(3);
                    click = rd.GetInt64(5);
                    de = rd.GetDateTime(4);
                    source = rd.GetString(9);
                    
                    if (Convert.IsDBNull(rd[10]) != true)
                    {
                        artpic = rd.GetString(10);
                        pictitle = rd.GetString(11);
                    }
                    rd.Close();
                }
                else Response.Write("fdfddf");
                SqlDataReader rdp;
                rdp = cdp.ExecuteReader();
                if (rdp.Read() == true)
                {
                    aidp = rdp.GetInt64(0);
                    titlep = rdp.GetString(2);
                    rdp.Close();
                }
                else rdp.Close();
                SqlDataReader rdn;
                rdn = cdn.ExecuteReader();
                if (rdn.Read() == true)
                {
                    aidn = rdn.GetInt64(0);
                    titlen = rdn.GetString(2);
                    rdn.Close();
                }
                else rdn.Close();
				conn.Close();
		
			}
			catch(SqlException e)
			{
				Response.Write("Exception in Main: " + e.Message);
			}
            Image1.ImageUrl = artpic;
            Label1.Text = pictitle;

		}
		
		private void addClick()
		{
			try
			{

				string con=ConfigurationSettings.AppSettings["np"];
				SqlConnection conn= new SqlConnection(con);
				conn.Open();
                SqlCommand cmd = new SqlCommand("update Article set click=click+1 where articleid=@articleid", conn);
				SqlParameter id1=cmd.Parameters.Add("@articleid",SqlDbType.BigInt);
				id1.Value=Request["articleid"];
				cmd.ExecuteNonQuery();
				
				conn.Close();
			}
			catch(SqlException e)
			{
				Response.Write("Exception in Main: " + e.Message);
			}

		}

        private void getRemark()	   //获得评论
        {
            try
            {
                string con = ConfigurationSettings.AppSettings["np"];
                SqlConnection conn = new SqlConnection(con);
                conn.Open();

                SqlDataAdapter myCommand = new SqlDataAdapter();　
                myCommand.SelectCommand = new SqlCommand("select * from Remark where articleid=@articleid", conn);
                SqlParameter artid = myCommand.SelectCommand.Parameters.Add("@articleid", SqlDbType.BigInt);
                artid.Value = Request["articleid"];
                DataSet ds = new DataSet(); 
                myCommand.Fill(ds, "Article");
                DataList1.DataSource = ds;
                DataList1.DataBind();
                conn.Close();
            }
            catch (SqlException e)
            {
                Response.Write("Exception in Main: " + e.Message);
            }
        }

        private void addRemark()
        {
            try
            {
                string a = username.Value;
                string c = body.Value;
                string d = (string)Request.UserHostAddress.ToString();
                string con = ConfigurationSettings.AppSettings["np"];
                SqlConnection conn = new SqlConnection(con);
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Remark values(@articleid,@username,getdate(),@body,@ip)", conn);
                SqlParameter articleid = cmd.Parameters.Add("@articleid", SqlDbType.BigInt);
                articleid.Value = Request["articleid"];
                SqlParameter ue = cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50);
                ue.Value = a.Trim();
                SqlParameter by = cmd.Parameters.Add("@body", SqlDbType.NVarChar, 500);
                by.Value = c.Trim();
                SqlParameter ip = cmd.Parameters.Add("@ip", SqlDbType.NVarChar, 50);
                ip.Value = d.Trim();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException e)
            {
                Response.Write("Exception in Main: " + e.Message);
            }

        }

	
		public string show1(object de)
		{
			string g;
			g=(string)de;
			return g.Trim() ;
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

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			if(Page.IsValid)
			{
				if(body.Value.Length>200)
				{
					Label1.Text="评论太长了！";
				}
				else 
				{
					addRemark();
					getRemark();
					getArticle();
				}
			} 
		}
	}
}
