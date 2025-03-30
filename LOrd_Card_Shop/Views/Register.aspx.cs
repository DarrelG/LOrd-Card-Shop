using LOrd_Card_Shop.Factory;
using LOrd_Card_Shop.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Password"] = pwTb.Text;
            if (Session["Password"] != null)
            {
                pwTb.Attributes["value"] = Session["Password"].ToString();
            }
        }

        protected async void registerBtn_Click(object sender, EventArgs e)
        {
            string username = uNameTb.Text;
            string password = pwTb.Text;
            string confirmpass = pwConfirmTb.Text;
            string gender = genderRBList.SelectedValue;
            string email = emailTb.Text;
            DateTime DOB = Calendar1.SelectedDate;

            await RegisterHandler.registerNewUser(username, password, confirmpass, gender, email, DOB, errLbl, Response, Session);
        }
    }
}