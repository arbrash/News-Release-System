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
    public partial class admin_articleEdit : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.CheckBox Headline;
        protected System.Web.UI.WebControls.CheckBox HighLight;
        protected System.Web.UI.WebControls.CustomValidator CustomValidator1;
        protected System.Web.UI.HtmlControls.HtmlTextArea Summary;
        protected System.Web.UI.WebControls.TextBox Key;
        protected System.Web.UI.WebControls.Button Button1;
        protected System.Web.UI.WebControls.Button upload;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.HtmlControls.HtmlInputFile FileUp;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                Session["artpic"] = "";
                getArticle();
                
                if ((string)Session["classname"] != "系统管理员" && (int)Session["chgnews"] != 1)
                {
                    Page.Visible = false;
                }

            }

        }

        private void Page_UnLoad(object sender, System.EventArgs e)
        {
        }

        private void getArticle()
        {
            string con = ConfigurationSettings.AppSettings["np"];	

            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            try
            {
                SqlDataAdapter myCommand = new SqlDataAdapter();　

                myCommand.SelectCommand = new SqlCommand("select * from Article where articleid=@articleid", conn);		
                SqlParameter id = myCommand.SelectCommand.Parameters.Add("@articleid", SqlDbType.BigInt);	
                id.Value = Request["articleid"];
					

                DataSet ds = new DataSet();			
                myCommand.Fill(ds, "Article");

                DataRow dr;
                dr = ds.Tables["Article"].Rows[0];   

                string content = (string)dr["content"];
                //Body.Value = Server.HtmlDecode(content);
                Body.Value = unFormatString( content);

                string title = (string)dr["title"];					   
                Title.Text = title;

                string classname = (string)dr["classname"];				  


                string writer = (string)dr["writer"];					 
                Author.Text = writer;

                string source = (string)dr["source"];					
                Source.Text = source;

                if (Convert.IsDBNull(dr[10]) != true)
                {
                    string arpic = (string)dr["artpic"];
                    Session["artpic"] = arpic;
                    Image1.ImageUrl = arpic;

                    string pictitle = (string)dr["pictitle"];
                    TextBox1.Text = pictitle;
                }
                

                string da = (string)Session["classname"];			  
                if (da.Trim() == "系统管理员")
                {
                    SqlDataAdapter selClassAll = new SqlDataAdapter();　　

                    selClassAll.SelectCommand = new SqlCommand("select * from Class", conn);		 

                    DataSet dt = new DataSet();
                    selClassAll.Fill(dt, "ClassName");

                    ClassName.DataSource = dt;
                    ClassName.DataTextField = "classname";
                    ClassName.DataValueField = "classname";
                    ClassName.DataBind();
                    int i = 0;
                    foreach (ListItem li in ClassName.Items)					 
                    {
                        if (li.Text.Trim() == classname.Trim())
                        {
                            li.Selected = true;

                        }
                        i += 1;
                    }
                }
                else
                {
                    ListItem d = new ListItem(classname, classname);

                    ClassName.Items.Add(d);
                }
                conn.Close();
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
                updateArticle();
            }

        }

        private void updateArticle()
        {
            string classname = ClassName.SelectedItem.Text;		
            string title = Title.Text;					
            string content = Body.Value;
            content = Server.HtmlDecode(content);
            string at = Author.Text;					
            string sr = Source.Text;
            string pt = TextBox1.Text;
            try
            {
                string conn = ConfigurationSettings.AppSettings["np"];

                SqlConnection con = new SqlConnection(conn);
                con.Open();

                SqlCommand cmd = new SqlCommand("update Article set content=@content,title=@title,classname=@classname,writer=@writer,source=@source,artpic=@artpic,pictitle=@pictitle where  articleid=@articleid", con);		
                SqlParameter id1 = cmd.Parameters.Add("@articleid", SqlDbType.BigInt);
                id1.Value = Request["articleid"];

                SqlParameter cl = cmd.Parameters.Add("@classname", SqlDbType.NVarChar, 50);	 
                cl.Value = classname;
                SqlParameter tl = cmd.Parameters.Add("@title", SqlDbType.NVarChar, 500);
                tl.Value = title;
                SqlParameter cn = cmd.Parameters.Add("@content", SqlDbType.NText);
                content = FormatString(content);             
                cn.Value = content;


                SqlParameter author = cmd.Parameters.Add("@writer", SqlDbType.NVarChar, 50);
                author.Value = at;
                SqlParameter source = cmd.Parameters.Add("@source", SqlDbType.NVarChar, 50);
                source.Value = sr;

                SqlParameter pictitle = cmd.Parameters.Add("@pictitle", SqlDbType.NVarChar, 500);
                pictitle.Value = pt;

                SqlParameter artpicpath = cmd.Parameters.Add("@artpic", SqlDbType.NVarChar, 500);
                artpicpath.Value = (string)Session["artpic"];


                int d = cmd.ExecuteNonQuery();			   
                if (d > 0)
                {
                    myLabel.Text = "修改新闻成功";
                    con.Close();
                }
                else
                {
                    myLabel.Text = "修改新闻错误";
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Response.Write("Exception in Main: " + e.Message);	

            }
        }
        protected string FormatString(string str)
        {
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace('\n'.ToString(), "<br>");
            return str;
        }

        protected string unFormatString(string str)
        {
            str = str.Replace("&nbsp;"," ");
            str = str.Replace("&nbsp", " ");
            str = str.Replace("&lt;","<");
            str = str.Replace("&gt;",">");
            str = str.Replace("<br>",'\n'.ToString());
            return str;
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {


        }

        private void upload_Click(object sender, System.EventArgs e)
        {



        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (pic.PostedFile.ContentLength != 0)
            {

                if (pic.PostedFile.ContentType == "image/jpeg" || pic.PostedFile.ContentType == "image/pjpeg" || pic.PostedFile.ContentType == "image/gif" || pic.PostedFile.ContentType == "image/bmp" || pic.PostedFile.ContentType == "image/png")	   //设置上传文件类型
                {
                    string filename = pic.PostedFile.FileName;
                    int i = filename.Length;
                    filename = filename.Remove(0, i - 4);
                    string s = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                    string d = Server.MapPath("../upfiles/") + s + filename;



                    pic.PostedFile.SaveAs(d);
                    Image1.ImageUrl = "../upfiles/" + s + filename;
                    Session["artpic"] = Image1.ImageUrl;
                    myLabel1.Text = "上传成功";

                    //fileByteArray = new Byte[this.pic.PostedFile.ContentLength]; 
                    //Stream streamObject = this.pic.PostedFile.InputStream;
                    //streamObject.Read(fileByteArray,0,this.pic.PostedFile.ContentLength);

                    pic.Visible = false;
                    Button1.Visible = false;

                }

                else myLabel1.Text = "只能上传图形文件请重新上传！";
            }
        }
    }
}

