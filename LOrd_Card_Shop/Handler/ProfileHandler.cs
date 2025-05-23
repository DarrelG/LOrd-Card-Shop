using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Repository;
using LOrd_Card_Shop.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Handler
{
    public class ProfileHandler : UserRepository
    {
        public static async Task<User> getProfile(string username)
        {
            await InitAsync();
            return UserDb.Where(x => x.UserName == username).FirstOrDefault();
        }

        public static async Task updateUser(
            string username,
            string password,
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
                password = Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$") ? password : throw new Exception("Password must at least 8 length");
                gender = gender == null || (gender != "Male" && gender != "Female") ? throw new Exception("Please choose valid gender") : gender;
                DOB = DOB == null ? throw new Exception("Please fill your Birth of Date") : DOB;
                bool usernames = string.IsNullOrEmpty(UserRepository.getUserByName(username).ToString()) ? false : throw new Exception("User Existed");

                await UserRepository.updateUser(username, password, email, gender, DOB);
            }
            catch (Exception ex)
            {
                errLbl.Visible = true;
                errLbl.Text = (ex.Message);
            }

            Response.Redirect("Login.aspx", false);
        }
    }
}