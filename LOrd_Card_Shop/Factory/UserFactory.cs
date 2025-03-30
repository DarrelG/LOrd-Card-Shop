using LOrdCardShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Factory
{
    public class UserFactory
    {
        public static User createNewUser(string username, string password, string email, string gender, DateTime DOB)
        {
            User user = new User();
            user.UserName = username;
            user.UserPassword = password;
            user.UserEmail = email;
            user.UserGender = gender;
            user.UserDOB = DOB;
            user.UserRole = "customer";
            return user;
        }
    }
}