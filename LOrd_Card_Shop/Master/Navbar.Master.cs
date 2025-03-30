using LOrdCardShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrdCardShop.Master
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        private static HttpCookie Cookie = HttpContext.Current.Request.Cookies["user_cookie"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bool isLoggedIn = Session["User"] != null;
                string currentPage = Path.GetFileName(Request.Url.AbsolutePath);

                if (isLoggedIn)
                {
                    GuestNavbar.Visible = false;
                    DefaultNavbar.Visible = true;
                    UsernameLabel.Text = "Hello, " + Session["User"];
                }
                else
                {
                    GuestNavbar.Visible = true;
                    DefaultNavbar.Visible = false;

                    string loginUrl = ResolveUrl("~/Views/Login.aspx");
                    string registerUrl = ResolveUrl("~/Views/Register.aspx");

                    if (currentPage != "Login.aspx")
                    {
                        GuestLoginButton.Text = "Login";
                        GuestLoginButton.PostBackUrl = loginUrl;
                    }
                    else
                    {
                        GuestLoginButton.Text = "Register";
                        GuestLoginButton.PostBackUrl = registerUrl;
                    }
                }
            }
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            if (Request.Cookies["user_cookies"] != null)
            {
                HttpCookie userCookie = new HttpCookie("user_cookie", "");
                userCookie.Expires = DateTime.Now.AddDays(-1);
                userCookie.Value = null;
                Response.Cookies.Set(userCookie);
                if (userCookie != null)
                {

                };
            }
            Response.Redirect("~/Views/Login.aspx");
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Login.aspx");
        }
    }
}