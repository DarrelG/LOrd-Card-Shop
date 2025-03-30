using LOrd_Card_Shop.Handler;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Repository;
using LOrd_Card_Shop.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Views
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