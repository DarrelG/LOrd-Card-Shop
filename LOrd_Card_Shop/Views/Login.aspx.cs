using LOrdCardShop.Handler;
using LOrdCardShop.Models;
using LOrdCardShop.Repository;
using LOrdCardShop.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrdCardShop.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null || Request.Cookies["user_cookies"] != null)
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string username = uNameTb.Text;
            string password = pwTb.Text;

            LoginHandler.LoginHandlers(username,
            password,
            errLbl,
            rememberMe,
            Response,
            Session);
        }
    }
}