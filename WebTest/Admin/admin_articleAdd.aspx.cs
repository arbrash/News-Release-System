using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


namespace WebNews.admin
{
    public partial class admin_articleAdd : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Label labeltest;
        protected System.Web.UI.WebControls.CustomValidator CustomValidator1;
        protected System.Web.UI.HtmlControls.HtmlInputText Key;
        protected System.Web.UI.WebControls.Label Label1;

        public string path;
        Byte[] fileByteArray;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string us = (string)Session["classname"];
                Session["artpic"] = "";
                if (us.Trim() == "系统管理员" || (int)Session["addnews"] == 1)
                {
                    getClass();
                }
                else
                {
                    Page.Visible = false;
                }

            }
        }
        private void getClass()							
        {
            string da = (string)Session["classname"];
            string userclass = (string)Session["userclass"];
            if (da.Trim() == "系统管理员")
            {
                string con = ConfigurationSettings.AppSettings["np"];	

                SqlConnection myConnection = new SqlConnection(con);
                myConnection.Open();

                SqlCommand cla = myConnection.CreateCommand();
                cla.CommandText = "select classname from Class";
                SqlDataAdapter selClassAll = new SqlDataAdapter(cla);

                DataSet ds = new DataSet();
                selClassAll.Fill(ds,"classname");

                ClassName.DataSource = ds.Tables["classname"].DefaultView;
                ClassName.DataTextField = "classname";
                ClassName.DataValueField = "classname";
                ClassName.DataBind();
                myConnection.Close();

            }
            else
            {
                ListItem d = new ListItem(userclass, userclass);

                ClassName.Items.Add(d);
            }
        }
        private void addhints()				 
        {
            string username = (string)Session["username"];

            string conn = ConfigurationSettings.AppSettings["np"];	

            SqlConnection con = new SqlConnection(conn);
            con.Open();

            SqlCommand cmd = new SqlCommand("update Admin set addnum=addnum+1 where username=@username", con);			

            SqlParameter name = cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50);	
            name.Value = username.Trim();
            int r = cmd.ExecuteNonQuery();					

        }

        private void addClassNum()
        {
            string username = (string)Session["username"];

            string conn = ConfigurationSettings.AppSettings["np"];	

            SqlConnection con = new SqlConnection(conn);
            con.Open();

            SqlCommand cmd = new SqlCommand("update Class set articlenum=articlenum+1 where classname=@classname", con);			//建立命令

            SqlParameter name = cmd.Parameters.Add("@classname", SqlDbType.NVarChar, 50);	 
            name.Value = ClassName.SelectedItem.Text.Trim();
            int r = cmd.ExecuteNonQuery();

        }

        public void addArticle()							  
        {
            string classname = ClassName.SelectedItem.Text.Trim();		 
            string title = Title.Value.Trim();					 
            string content = Body.Value;
            content = Server.HtmlDecode(content);					
            string at = Author.Value.Trim();						 
            string sr = Source.Value.Trim();
            string pictitle = TextBox1.Text.Trim();
            try
            {
                string conn = ConfigurationSettings.AppSettings["np"];	

                SqlConnection con = new SqlConnection(conn);
                con.Open();

                SqlCommand cmd = new SqlCommand("insert into Article(content,title,writer,dateandtime,click,classname,username,checkup,source,artpic,pictitle) values(@content,@title,@writer,GETDATE(),0,@classname,@username,@checkup,@source,@artpic,@pictitle)", con);		

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
                
                SqlParameter username = cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50);
                username.Value = (string)Session["username"];
                SqlParameter checkup = cmd.Parameters.Add("@checkup", SqlDbType.Int);
                string ul = (string)Session["classname"];
                if (ul.Trim() == "系统管理员")
                {
                    checkup.Value = 1;
                }
                else checkup.Value = 0;

                //SqlParameter artpic = cmd.Parameters.Add("@artpic", SqlDbType.Image);
                //artpic.Value = fileByteArray;
                string artpicpath = (string)Session["artpic"];
                SqlParameter artpic = cmd.Parameters.Add("@artpic", SqlDbType.NVarChar, 500);
                artpic.Value = artpicpath;
                SqlParameter PicTitle = cmd.Parameters.Add("@pictitle", SqlDbType.NVarChar, 500);
                PicTitle.Value = pictitle;
                
                int d = cmd.ExecuteNonQuery();			 
                if (d > 0)
                {
                    myLabel.Text = "添加新闻成功";
                    con.Close();
                }
                else
                {
                    myLabel.Text = "添加新闻错误";
                    con.Close();
                }
            }
            catch (Exception e)
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

        //private void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        //{
        //    if (Summary.Value.Length > 200)
        //    {
        //        args.IsValid = false;
        //    }
        //    else
        //        args.IsValid = true;
        //}

        protected void Submit_Click(object sender, System.EventArgs e)
        {					 

            if (Page.IsValid)
            {
                addArticle();
                string userclass = (string)Session["classname"];
                if (userclass.Trim() == "系统管理员")
                {
                    addhints();
                    addClassNum();
                }
                else
                {
                    myLabel.Text = "新闻已提交，请等待审核！";
                }
            }

        }

        private void upload_Click(object sender, System.EventArgs e)
        {


        }

        private void Button1_Click(object sender, System.EventArgs e)
        {

        }
        protected string FormatString(string str)
        {
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace('\n'.ToString(), "<br>");
            return str;
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
                    Image2.ImageUrl = "../upfiles/" + s + filename;
                    Session["artpic"] = Image2.ImageUrl;
                    myLabel1.Text = "上传成功";

                    //fileByteArray = new Byte[this.pic.PostedFile.ContentLength]; 
                    //Stream streamObject = this.pic.PostedFile.InputStream;
                    //streamObject.Read(fileByteArray,0,this.pic.PostedFile.ContentLength);

                    pic.Visible = false;
                    Button1.Visible = false;

                }

                else myLabel1.Text = "只能上传图形文件请重新上传！";


            }
            else myLabel1.Text = "请选择上传文件";
            //bool fileOK = false;
            //string path = Server.MapPath("~/Temp/");
            //if (pic.HasFile)
            //{
            //    String fileExtension = System.IO.Path.GetExtension(pic.FileName).ToLower();
            //    String[] allowedExtensions = { ".gif", ".png", ".bmp", ".jpg" };
            //    for (int i = 0; i < allowedExtensions.Length; i++)
            //    {
            //        if (fileExtension == allowedExtensions[i])
            //        {
            //            fileOK = true;
            //        }
            //    }
            //}
            //if (fileOK)
            //{
            //    try
            //    {
            //        pic.SaveAs(path + pic.FileName);
            //        myLabel.Text = "文件上传成功.";
            //        myLabel1.Text = "<b>原文件路径：</b>" + pic.PostedFile.FileName + "<br />" +
            //                      "<b>文件大小：</b>" + pic.PostedFile.ContentLength + "字节<br />" +
            //                      "<b>文件类型：</b>" + pic.PostedFile.ContentType + "<br />";
            //    }
            //    catch (Exception ex)
            //    {
            //        myLabel.Text = "文件上传不成功.";
            //    }
            //}
            //else
            //{
            //    myLabel.Text = "只能够上传图片文件.";
            //}
        }
    }
}
