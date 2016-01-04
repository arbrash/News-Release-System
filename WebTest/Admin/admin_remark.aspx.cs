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

	public partial class admin_remark : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label PageList;
		

		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			if(!Page.IsPostBack)
			{
				string dr=(string)Session["classname"];
				string a= (string)Session["userclass"];
				string b=Request["classname"];
				if(dr.Trim()=="ϵͳ����Ա")
				{
					getRemark();
				}
				else
				{
					if((int)Session["remark"]==1 &&a.Trim()==b.Trim())
					{
						getRemark();
					}  
					else myLabel.Text="����Ȩ��������";
				}   			
			}

		}

		private void getRemark()	   
		{
			try
			{	 
				string con=ConfigurationSettings.AppSettings["np"];
				SqlConnection  conn = new SqlConnection(con);
				conn.Open();
	����   ���� 
				SqlDataAdapter myCommand = new SqlDataAdapter();����
                myCommand.SelectCommand = new SqlCommand("select * from Remark where articleid=@articleid", conn);
				SqlParameter artid=myCommand.SelectCommand.Parameters.Add("@articleid",SqlDbType.BigInt);
				artid.Value=Request["articleid"];
				

				
				DataSet ds=new DataSet(); 
				myCommand.Fill(ds,"Article");
		������
		
				MyDataGrid.DataSource=ds;
				MyDataGrid.DataBind();
				
				lblCurrentIndex.Text="��"+((Int32)MyDataGrid.CurrentPageIndex+1)+"ҳ";
				lblPageCount.Text="/��"+MyDataGrid.PageCount+"ҳ";

				
			

				conn.Close();
			}
			catch(SqlException e)
			{
				Response.Write("Exception in Main: " + e.Message);	
			}
		}

		private void delRemark(object a)
		{
			try
			{	string conn=ConfigurationSettings.AppSettings["np"];
				SqlConnection con = new SqlConnection(conn);
				con.Open();

                SqlCommand cmd = new SqlCommand("delete from Remark where id=@id", con);			
			
				SqlParameter rid=cmd.Parameters.Add("@id",SqlDbType.BigInt );	
				rid.Value =a;
				int i=cmd.ExecuteNonQuery();
				if(i>0)
				{
				 myLabel.Text="ɾ���ɹ�";
				}

				con.Close();
			}
			catch(SqlException e)
			{
				Response.Write("Exception in Main: " + e.Message);	
			}
		}


		private void searchBody()
		{
			try
			{	 
				string con=ConfigurationSettings.AppSettings["np"];
				SqlConnection  conn = new SqlConnection(con);
				conn.Open();
	����   ���� 
				SqlDataAdapter myCommand = new SqlDataAdapter();����
                myCommand.SelectCommand = new SqlCommand("select * from Remark where body like '%'+@body+'%'", conn);
				SqlParameter body=myCommand.SelectCommand.Parameters.Add("@body",SqlDbType.NVarChar ,500);
				body.Value=Request["keyword"] ;

				DataSet ds=new DataSet(); 
				myCommand.Fill(ds,"Articl");
		��������
				MyDataGrid.DataSource=ds;			
				MyDataGrid.DataBind();
				

				conn.Close();
			}
			catch(SqlException e)
			{
				Response.Write("Exception in Main: " + e.Message);	
			}
		
		}
		
		private void searchAuthor()
		{
			try
			{	 
				string con=ConfigurationSettings.AppSettings["np"];
				SqlConnection  conn = new SqlConnection(con);
				conn.Open();
	����   ���� 
				SqlDataAdapter myCommand = new SqlDataAdapter();����
                myCommand.SelectCommand = new SqlCommand("select * from Remark where username like '%'+@username+'%'", conn);
				SqlParameter username=myCommand.SelectCommand.Parameters.Add("@username",SqlDbType.NVarChar ,50);
				username.Value=Request["keyword"] ;

				DataSet ds=new DataSet();  
				myCommand.Fill(ds,"Article");
		��������
				MyDataGrid.DataSource=ds;			
				MyDataGrid.DataBind();
				

				conn.Close();
			}
			catch(SqlException e)
			{
				Response.Write("Exception in Main: " + e.Message);	
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
			getRemark();
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
			this.MyDataGrid.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.MyDataGrid_DeleteCommand);

		}
		#endregion

		public void MyDataGrid_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			  
			   object b=this.MyDataGrid.DataKeys[e.Item.ItemIndex];
			     delRemark(b);
			if(MyDataGrid.CurrentPageIndex>0)
			{
					MyDataGrid.CurrentPageIndex=MyDataGrid.CurrentPageIndex-1;
			}

				  getRemark();
		}

		protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(Page.IsValid)
			{
				if(search.SelectedIndex==0)
				{
					searchBody();
				}
				else searchAuthor();
			}
		}

		public void MyDataGrid_SelectedIndexChanged(object sender,System.EventArgs e)
		{
			        
			getRemark();
		}

	}
}
