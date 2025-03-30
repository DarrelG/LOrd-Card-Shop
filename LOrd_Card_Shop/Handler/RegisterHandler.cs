using LOrdCardShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace LOrdCardShop.Handler
{
    public class RegisterHandler
    {
        public static async Task registerNewUser(
            string username,
            string password,
            string confirmPass,
            string gender,
            string email,
            DateTime DOB,
            Label errLbl,
            HttpResponse Response,
            HttpSessionState Session)
        {
            try
            {
                username = Regex.IsMatch(username, @"^[A-Za-z]{5,30}$") ? username : throw new Exception("Username Invalid");
                email = email.Contains("@") ? email : throw new Exception("Email must contain '@'");
                password = Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$") ? password = Regex.IsMatch(password, confirmPass) ? password : throw new Exception("Confirm password must be same as password") : throw new Exception("Password must at least 8 length");
                gender = gender == null || (gender != "Male" && gender != "Female") ? throw new Exception("Please choose valid gender") : gender;
                DOB = DOB == null ? throw new Exception("Please fill your Birth of Date") : DOB;

                await UserRepository.createNewUser(username, password, email, gender, DOB);
            }
            catch (Exception ex) {
                errLbl.Visible = true;
                errLbl.Text = (ex.Message);
            }
        }
    }
}