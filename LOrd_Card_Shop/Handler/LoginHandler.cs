using System;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Repository;

namespace LOrd_Card_Shop.Handler
{
    public class LoginHandler 
    {
        public static async void LoginHandlers(
            string username,
            string password,
            Label errLbl,
            CheckBox rememberMe,
            HttpResponse Response,
            HttpSessionState Session)
        {
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                errLbl.Text = "Username and Password must be filled!";
                errLbl.Visible = true;
            }
            else
            {
                if (await UserRepository.loginValidation(username, password) == true)
                {
                    User dbUserName = UserRepository.getUserByName(username);
                    Session["User"] = dbUserName.UserName;

                    if (rememberMe.Checked)
                    {
                        HttpCookie userCookie = new HttpCookie("user_cookie", dbUserName.UserName);

                        userCookie.Expires = DateTime.Now.AddDays(7);
                        Response.Cookies.Add(userCookie);
                    }
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    errLbl.Text = "Username or Password invalid!";
                    errLbl.Visible = true;
                }
            }
        }
    }
}