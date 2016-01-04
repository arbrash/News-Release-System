using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace web1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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

                SqlDataAdapter myCommand1 = new SqlDataAdapter("select top 5 * from Article where checkup=1 and classname='新闻' order by dateandtime desc", conn);　　
                DataSet ds1 = new DataSet();  
                myCommand1.Fill(ds1, "Article");
                //for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                //{
                //    ds1.Tables[0].Rows[i][4] = ((DateTime)ds1.Tables[0].Rows[0][4]).ToString("MM-dd");
                //}
                DataList1.DataSource = ds1;


           
                DataList1.DataBind();


                SqlDataAdapter myCommand2 = new SqlDataAdapter("select top 5 * from Article where checkup=1 and classname='体育' order by dateandtime desc", conn);　　
                DataSet ds2 = new DataSet();  
                myCommand2.Fill(ds2, "Article");
                DataList2.DataSource = ds2;			
                DataList2.DataBind();

                SqlDataAdapter myCommand3 = new SqlDataAdapter("select top 5 * from Article where checkup=1 and classname='科技' order by dateandtime desc", conn);　　
                DataSet ds3 = new DataSet();  
                myCommand3.Fill(ds3, "Article");
                DataList3.DataSource = ds3;			
                DataList3.DataBind();

                SqlDataAdapter myCommand4 = new SqlDataAdapter("select top 5 * from Article where checkup=1 order by click desc", conn);　　
                DataSet ds4 = new DataSet();  
                myCommand4.Fill(ds4, "Article");
                DataList4.DataSource = ds4;			
                DataList4.DataBind();


                conn.Close();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}