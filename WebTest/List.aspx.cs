using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebTest
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getClassNum();
                getArticle();
            }
            
        }
        public void ListClass(string de)		
        {
            try
            {
                string con = ConfigurationSettings.AppSettings["np"];
                SqlConnection conn = new SqlConnection(con);
                conn.Open();

                SqlCommand cmd = new SqlCommand("select * from class", conn);

                SqlDataReader rd;
                rd = cmd.ExecuteReader();


                while (rd.Read())
                {
                    Response.Write(de + "<a href=list.aspx?classname=" + rd.GetString(1) + ">" + rd.GetString(1) + "</a>");

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
                string con = ConfigurationSettings.AppSettings["np"];
                SqlConnection conn = new SqlConnection(con);
                conn.Open();

                SqlDataAdapter myCommand = new SqlDataAdapter();　　
                myCommand.SelectCommand = new SqlCommand("select * from Article where classname=@classname and checkup=1 order by dateandtime desc", conn);
                SqlParameter classname = myCommand.SelectCommand.Parameters.Add("@classname", SqlDbType.Char, 200);
                classname.Value = Request["classname"];
                DataSet ds = new DataSet();
                myCommand.Fill(ds);

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

        private void getClassNum()		  
        {
            try
            {
                string con = ConfigurationSettings.AppSettings["np"];
                SqlConnection conn = new SqlConnection(con);
                conn.Open();

                SqlCommand cmd = new SqlCommand("select * from Class where className=@className", conn);
                SqlParameter clsname = cmd.Parameters.Add("@classname", SqlDbType.Char, 200);
                clsname.Value = Request["classname"];

                SqlDataReader rd;
                rd = cmd.ExecuteReader();
                if (rd.Read() == true)
                {
                    NameLabel.Text = "<strong>新闻数量：</strong>" + rd.GetInt32(2) + " 篇";
                    rd.Close();
                }
                DropDownClass.SelectedValue = Request["classname"]; 
                conn.Close();
            }
            catch (SqlException e)
            {

                Response.Write("Exception in Main: " + e.Message);	

            }
        }

        protected void MyDataGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            //DataSet ds = new DataSet();
            //MyDataGrid.CurrentPageIndex = e.NewPageIndex;
            //try
            //{
            //    string con = ConfigurationSettings.AppSettings["np"];
            //    SqlConnection conn = new SqlConnection(con);//连接字符串
            //    conn.Open();

            //    SqlDataAdapter myCommand = new SqlDataAdapter();　　//创建SqlDataAdapter 类
            //    myCommand.SelectCommand = new SqlCommand("select * from Article where classname=" + "'" + DropDownClass.Text + "'" + " order by dateandtime desc", conn);
            //    //SqlParameter classname = myCommand.SelectCommand.Parameters.Add("@classname", SqlDbType.Char, 200);
            //    //classname.Value = Request["classname"];
            //    //建立并填充数据集
            //    myCommand.Fill(ds);

            //    MyDataGrid.DataSource = ds;
            //    MyDataGrid.DataBind();

            //    lblCurrentIndex.Text = "第" + ((Int32)MyDataGrid.CurrentPageIndex + 1) + "页";
            //    lblPageCount.Text = "/共" + MyDataGrid.PageCount + "页";
            //}
            //catch (SqlException ex1)
            //{
            //    Response.Write("Exception in Main: " + ex1.Message);	
            //}
        }

        protected void DropDownClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyDataGrid.CurrentPageIndex = 0;
            lblCurrentIndex.Text = "第1页";
            MyDataGrid.DataSource = null;
            DataSet ds = new DataSet();
            ds.Clear();
            if (DropDownClass.SelectedIndex==1)
            {
                try
                {
                    string con = ConfigurationSettings.AppSettings["np"];
                    SqlConnection conn = new SqlConnection(con);
                    conn.Open();

                    SqlDataAdapter myCommand = new SqlDataAdapter();　　
                    myCommand.SelectCommand = new SqlCommand("select * from Article where classname=" + "'体育'" + "and checkup=1 order by dateandtime desc", conn);
                    myCommand.Fill(ds);

                    MyDataGrid.DataSource = ds;
                    MyDataGrid.DataBind();

                    SqlCommand cmd = new SqlCommand("select * from Class where classname=" + "'体育'", conn);

                    SqlDataReader rd;
                    rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                        NameLabel.Text = "新闻数量：" + rd.GetInt32(2) + " 篇";
                        rd.Close();
                    }
                    SqlCommand cmd1 = new SqlCommand("select classid from Class where className=" + "'体育'", conn);
                    rd = cmd1.ExecuteReader();
                    int id;
                    if (rd.Read() == true)
                    {
                        id = Convert.ToInt32(rd["classid"]);
                        DropDownClass.SelectedIndex = id;
                    }
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    Response.Write("Exception in Main: " + ex.Message);
                }
            }
            if (DropDownClass.SelectedIndex==0)
            {
                try
                {
                    string con = ConfigurationSettings.AppSettings["np"];
                    SqlConnection conn = new SqlConnection(con);
                    conn.Open();

                    SqlDataAdapter myCommand = new SqlDataAdapter();　
                    myCommand.SelectCommand = new SqlCommand("select * from Article where classname=" + "'新闻'" + "and checkup=1 order by dateandtime desc", conn);
                    myCommand.Fill(ds);

                    MyDataGrid.DataSource = ds;
                    MyDataGrid.DataBind();

                    SqlCommand cmd = new SqlCommand("select * from Class where classname=" + "'新闻'", conn);

                    SqlDataReader rd;
                    rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                        NameLabel.Text = "新闻数量：" + rd.GetInt32(2) + " 篇";
                        rd.Close();
                    }
                    SqlCommand cmd1 = new SqlCommand("select classid from Class where className=" + "'新闻'", conn);
                    rd = cmd1.ExecuteReader();
                    int id;
                    if (rd.Read() == true)
                    {
                        id = Convert.ToInt32(rd["classid"]);
                        DropDownClass.SelectedIndex = id;
                    }
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    Response.Write("Exception in Main: " + ex.Message);
                }
            }
            if (DropDownClass.SelectedIndex==2)
            {
                try
                {
                    string con = ConfigurationSettings.AppSettings["np"];
                    SqlConnection conn = new SqlConnection(con);
                    conn.Open();

                    SqlDataAdapter myCommand = new SqlDataAdapter();　　
                    myCommand.SelectCommand = new SqlCommand("select * from Article where classname=" + "'科技'" + "and checkup=1 order by dateandtime desc", conn);
                    myCommand.Fill(ds);

                    MyDataGrid.DataSource = ds;
                    MyDataGrid.DataBind();

                    SqlCommand cmd = new SqlCommand("select * from Class where classname=" + "'科技'", conn);

                    SqlDataReader rd;
                    rd = cmd.ExecuteReader();
                    if (rd.Read() == true)
                    {
                        NameLabel.Text = "新闻数量：" + rd.GetInt32(2) + " 篇";
                        rd.Close();
                    }
                    SqlCommand cmd1 = new SqlCommand("select classid from Class where className=" + "'科技'", conn);
                    rd = cmd1.ExecuteReader();
                    int id;
                    if (rd.Read() == true)
                    {   
                        id = Convert.ToInt32(rd["classid"]);
                        DropDownClass.SelectedIndex = id;
                    }
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    Response.Write("Exception in Main: " + ex.Message);	
                }
            }
        }

        public void PagerButtonClick(Object sender, EventArgs e)		
        {
            string arg = ((LinkButton)sender).CommandArgument;

            switch (arg)
            {
                case ("next"):
                    {
                        MyDataGrid.DataSource = null;
                        DataSet ds = new DataSet();
                        ds.Clear();
                        try
                        {
                            string con = ConfigurationSettings.AppSettings["np"];
                            SqlConnection conn = new SqlConnection(con);
                            conn.Open();

                            SqlDataAdapter myCommand = new SqlDataAdapter();　
                            myCommand.SelectCommand = new SqlCommand("select * from Article where classname=" + "'" + DropDownClass.Text + "'" + " order by dateandtime desc", conn);
                            myCommand.Fill(ds);

                            MyDataGrid.DataSource = ds;
                            MyDataGrid.DataBind();
                            if (MyDataGrid.CurrentPageIndex < (MyDataGrid.PageCount - 1))
                                MyDataGrid.CurrentPageIndex++;
                        }
                        catch (SqlException ex1)
                        {
                            Response.Write("Exception in Main: " + ex1.Message);	
                        }
                        

                        break;
                    }
                case ("prev"):
                    {
                        MyDataGrid.DataSource = null;
                        DataSet ds = new DataSet();
                        ds.Clear();
                        try
                        {
                            string con = ConfigurationSettings.AppSettings["np"];
                            SqlConnection conn = new SqlConnection(con);
                            conn.Open();

                            SqlDataAdapter myCommand = new SqlDataAdapter();
                            myCommand.SelectCommand = new SqlCommand("select * from Article where classname=" + "'" + DropDownClass.Text + "'" + " order by dateandtime desc", conn);
                            myCommand.Fill(ds);

                            MyDataGrid.DataSource = ds;
                            MyDataGrid.DataBind();
                            if (MyDataGrid.CurrentPageIndex > 0)
                                MyDataGrid.CurrentPageIndex--;
                        }
                        catch (SqlException ex1)
                        {
                            Response.Write("Exception in Main: " + ex1.Message);
                        }
                        break;
                    }
                case ("last"):
                    {
                        MyDataGrid.DataSource = null;
                        DataSet ds = new DataSet();
                        ds.Clear();
                        try
                        {
                            string con = ConfigurationSettings.AppSettings["np"];
                            SqlConnection conn = new SqlConnection(con);
                            conn.Open();

                            SqlDataAdapter myCommand = new SqlDataAdapter();　　
                            myCommand.SelectCommand = new SqlCommand("select * from Article where classname=" + "'" + DropDownClass.Text + "'" + " order by dateandtime desc", conn);
                            myCommand.Fill(ds);

                            MyDataGrid.DataSource = ds;
                            MyDataGrid.DataBind();
                            MyDataGrid.CurrentPageIndex = (MyDataGrid.PageCount - 1);
                        }
                        catch (SqlException ex1)
                        {
                            Response.Write("Exception in Main: " + ex1.Message);	
                        }
                        
                        break;
                    }
                case ("first"):
                    {
                        MyDataGrid.DataSource = null;
                        DataSet ds = new DataSet();
                        ds.Clear();
                        try
                        {
                            string con = ConfigurationSettings.AppSettings["np"];
                            SqlConnection conn = new SqlConnection(con);
                            conn.Open();

                            SqlDataAdapter myCommand = new SqlDataAdapter();　
                            myCommand.SelectCommand = new SqlCommand("select * from Article where classname=" + "'" + DropDownClass.Text + "'" + " order by dateandtime desc", conn);
                            myCommand.Fill(ds);

                            MyDataGrid.DataSource = ds;
                            MyDataGrid.DataBind();
                            MyDataGrid.CurrentPageIndex = 0;
                        }
                        catch (SqlException ex1)
                        {
                            Response.Write("Exception in Main: " + ex1.Message);	
                        }
                        
                        break;
                    }
            }
            getchangeArticle();
        }
        private void getchangeArticle()
        {
            MyDataGrid.DataSource = null;
            DataSet ds = new DataSet();
            ds.Clear();
            try
            {
                string con = ConfigurationSettings.AppSettings["np"];
                SqlConnection conn = new SqlConnection(con);
                conn.Open();

                SqlDataAdapter myCommand = new SqlDataAdapter();
                myCommand.SelectCommand = new SqlCommand("select * from Article where classname=" + "'" + DropDownClass.Text + "'" + " order by dateandtime desc", conn);
                myCommand.Fill(ds);

                MyDataGrid.DataSource = ds;
                MyDataGrid.DataBind();
                lblCurrentIndex.Text = "第" + ((Int32)MyDataGrid.CurrentPageIndex + 1) + "页";
                lblPageCount.Text = "/共" + MyDataGrid.PageCount + "页";
            }
            catch (SqlException ex1)
            {
                Response.Write("Exception in Main: " + ex1.Message);
            }
                        
        }
    }
}