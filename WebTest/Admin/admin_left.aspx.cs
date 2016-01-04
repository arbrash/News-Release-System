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

namespace WebNews.admin
{
    public partial class admin_left : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string username;
                username = (string)Session["username"];
                if (username.Trim() == "")
                {
                    Page.Visible = false;
                }
            }

        }
        public bool userAddPower(int i, string a)
        {
            a = a.Trim().ToString();
            if (i == 1 || a == "系统管理员")
            {
                return true;
            }
            else return false;
        }
        public bool checkPower(int i, string a)
        {
            a = a.Trim().ToString();
            if (i == 1 || a == "系统管理员")
            {
                return true;
            }
            else return false;
        }
        public bool userManagePower(int i, string a)
        {
            a = a.Trim().ToString();
            if (i == 1 || a == "系统管理员")
            {
                return true;
            }
            else return false;
        }

        public bool validateUserClass(string a)
        {
            a = a.Trim().ToString();
            if (a == "系统管理员")
            {
                return true;
            }
            else return false;
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
    }
}
