using LOrd_Card_Shop.Handler;
using LOrd_Card_Shop.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Views
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                Task<User> data = ProfileHandler.getProfile(Session["User"].ToString());
                uNameTb.Text = data.Result.UserName;
                emailTb.Text = data.Result.UserEmail;
                genderRBList.SelectedValue = data.Result.UserGender;
                Calendar1.SelectedDate = data.Result.UserDOB;
            }
        }

        protected async void updateBtn_Click(object sender, EventArgs e)
        {
            string username = uNameTb.Text;
            string password = pwTb.Text;
            string gender = genderRBList.SelectedValue;
            string email = emailTb.Text;
            DateTime DOB = Calendar1.SelectedDate;

            await ProfileHandler.updateUser(username, password, email, gender, DOB);
        }
    }
}