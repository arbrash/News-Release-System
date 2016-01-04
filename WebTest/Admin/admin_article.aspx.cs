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
    /// <summary>
    /// admin_article 的摘要说明。
    /// </summary>
    public partial class admin_article : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Button Button1;
        protected System.Web.UI.WebControls.Label PageList;
        protected System.Web.UI.WebControls.LinkButton Linkbutton3;
        protected System.Web.UI.WebControls.LinkButton Linkbutton4;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getArticle();

            }
        }
        private void getArticle()
        {
            try
            {
                string con = ConfigurationSettings.AppSettings["np"];
                SqlConnection conn = new SqlConnection(con);
                conn.Open();

                SqlDataAdapter myCommand = new SqlDataAdapter();　　
                myCommand.SelectCommand = new SqlCommand("select * from Article  where checkup=1 order by articleid desc", conn);
                DataSet ds = new DataSet();  
                myCommand.Fill(ds, "Article");

                MyDataGrid.DataSource = ds;		
                MyDataGrid.DataBind();

                lblCurrentIndex.Text = "第" + ((Int32)MyDataGrid.CurrentPageIndex + 1) + "页";
                lblPageCount.Text = "/共" + MyDataGrid.PageCount + "页";

                conn.Close();
            }
            catch (SqlException e)
            {
                Response.Write("Exception in Main: " + e.Message);	
            }

        }

        private void searchTitle()					
        {
            try
            {
                string con = ConfigurationSettings.AppSettings["np"];
                SqlConnection conn = new SqlConnection(con);
                conn.Open();

                SqlDataAdapter myCommand = new SqlDataAdapter();　　
                myCommand.SelectCommand = new SqlCommand("select * from Article where title like '%'+@title+'%' and checkup=1 order by dateandtime desc", conn);
                SqlParameter title = myCommand.SelectCommand.Parameters.Add("@title", SqlDbType.NVarChar, 500);
                title.Value = Request["keyword"];

                DataSet ds = new DataSet(); 
                myCommand.Fill(ds, "Articl");

                MyDataGrid.DataSource = ds;			
                MyDataGrid.DataBind();


                conn.Close();
            }
            catch (SqlException e)
            {
                Response.Write("Exception in Main: " + e.Message);
            }

        }

        private void searchContent()						
        {
            try
            {
                string con = ConfigurationSettings.AppSettings["np"];
                SqlConnection conn = new SqlConnection(con);
                conn.Open();

                SqlDataAdapter myCommand = new SqlDataAdapter();　　
                myCommand.SelectCommand = new SqlCommand("select * from Article where content like '%'+convert(nvarchar(255),@content)+'%' and checkup=1 order by dateandtime desc", conn);
                SqlParameter content = myCommand.SelectCommand.Parameters.Add("@content", SqlDbType.NText);
                content.Value = Request["keyword"].Trim();

                DataSet ds = new DataSet(); 
                myCommand.Fill(ds, "Article");

                MyDataGrid.DataSource = ds;			 
                MyDataGrid.DataBind();


                conn.Close();
            }
            catch (SqlException e)
            {
                Response.Write("Exception in Main: " + e.Message);	
            }

        }
        public string show(object a, object b, object c)					  //设置权限
        {
            string dr = "<a href=admin_articleEdit.aspx?articleid=" + b + ">" + a + "</a>";
            string de = a.ToString();
            string g = (string)Session["classname"];
            string d = (string)Session["userclass"];
            string f = (string)c;
            if (g.Trim() == "系统管理员")
            {
                return dr;
            }
            else
            {
                if ((int)Session["chgnews"] == 1 && d.Trim() == f.Trim())
                    return dr;
                else return de;
            }

        }

        public string show(object a, object d)
        {

            string b = "<a href=admin_remark.aspx?articleid=" + a + "&classname=" + d + "   target=_self>评论</a>";
            string c = "评论";
            string g = (string)Session["classname"];
            string e = (string)Session["userclass"];
            string f = (string)d;
            if (g.Trim() == "系统管理员")
            {
                return b;
            }
            else
            {
                if ((int)Session["remark"] == 1 && e.Trim() == f.Trim())
                    return b;
                else return c;
            }


        }

        private void delarticle(object a)
        {
            try
            {
                string con = ConfigurationSettings.AppSettings["np"];
                SqlConnection conn = new SqlConnection(con);			
                conn.Open();
                SqlCommand delAdmin = new SqlCommand("delete from Article where articleid=@articleid", conn);			

                SqlParameter id = delAdmin.Parameters.Add("@articleid", SqlDbType.BigInt);
                id.Value = a;		   

                int r = delAdmin.ExecuteNonQuery();	 
                if (r > 0)
                {
                    myLabel.Text = "删除成功！";
                    conn.Close();
                    MyDataGrid.EditItemIndex = -1;
                    int d = MyDataGrid.PageCount % MyDataGrid.PageSize;
                    if (MyDataGrid.CurrentPageIndex > 0)
                    {

                        MyDataGrid.CurrentPageIndex = MyDataGrid.CurrentPageIndex - 1;
                    }
                    getArticle();
                }
                else
                {
                    myLabel.Text = "删除错误！";
                    conn.Close();
                    MyDataGrid.EditItemIndex = -1;
                    int d = MyDataGrid.PageCount % MyDataGrid.PageSize;
                    if (MyDataGrid.CurrentPageIndex > 0)
                    {

                        MyDataGrid.CurrentPageIndex = MyDataGrid.CurrentPageIndex - 1;
                    }
                    getArticle();

                }
            }
            catch (SqlException e)
            {
                Response.Write("Exception in Main: " + e.Message);	
            }
        }

        private void delnum(string dr)				 
        {
            try
            {
                string username = (string)Session["username"];

                string conn = ConfigurationSettings.AppSettings["np"];	

                SqlConnection con = new SqlConnection(conn);
                con.Open();

                SqlCommand cmd = new SqlCommand("update Admin set addnum=addnum-1 where username=@username", con);			

                SqlParameter name = cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50);	 
                name.Value = dr.Trim();
                int r = cmd.ExecuteNonQuery();	  
                con.Close();
            }
            catch (SqlException e)
            {
                Response.Write("Exception in Main: " + e.Message);
            }
        }



        private void delClassNum(string d)		 
        {
            try
            {
                string conn = ConfigurationSettings.AppSettings["np"];	

                SqlConnection con = new SqlConnection(conn);
                con.Open();

                SqlCommand cmd = new SqlCommand("update Class set articlenum=articlenum-1 where classname=@classname", con);			//建立命令

                SqlParameter cls = cmd.Parameters.Add("@classname", SqlDbType.NVarChar, 50);	
                cls.Value = d.Trim();
                int r = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException e)
            {
                Response.Write("Exception in Main: " + e.Message);	
            }
        }


        public void PagerButtonClick(Object sender, EventArgs e)//导航按钮
        {
            string arg = ((LinkButton)sender).CommandArgument;

            switch (arg)
            {
                case ("next"):
                    if (MyDataGrid.CurrentPageIndex < (MyDataGrid.PageCount - 1))
                        MyDataGrid.CurrentPageIndex++;
                    break;
                case ("prev"):
                    if (MyDataGrid.CurrentPageIndex > 0)
                        MyDataGrid.CurrentPageIndex--;
                    break;
                case ("last"):
                    MyDataGrid.CurrentPageIndex = (MyDataGrid.PageCount - 1);
                    break;
                case ("first"):
                    MyDataGrid.CurrentPageIndex = 0;
                    break;
            }
            getArticle();
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

        public void MyDataGrid_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            object b = this.MyDataGrid.DataKeys[e.Item.ItemIndex];
            string c = (string)Session["classname"];
            string del = (string)e.Item.Cells[3].Text;
            string g = (string)e.Item.Cells[1].Text;


            string f = (string)Session["userclass"];
            if (c.Trim() == "系统管理员")
            {
                delClassNum(g);
                delarticle(b);
                delnum(del);

            }
            else
            {
                if ((int)Session["chgnews"] == 1 && g.Trim() == f.Trim())
                {

                    delClassNum(g);

                    delarticle(b);
                    delnum(del);


                }
                else myLabel.Text = "你无权删除此新闻";
            }


        }

        protected void LinkButton1_Click(object sender, System.EventArgs e)
        {
            if (Page.IsValid)
            {
                if (search.SelectedIndex == 0)
                {
                    searchTitle();
                }
                else searchContent();
            }

        }
        public void MyDataGrid_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            getArticle();
        }
    }
}
