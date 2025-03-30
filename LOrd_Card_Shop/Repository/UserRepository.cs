using LOrdCardShop.Factory;
using LOrdCardShop.Models;
using LOrdCardShop.Singleton;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LOrdCardShop.Repository
{
    public class UserRepository : dbSingleton
    {
        public static User getUserById(int user)
        {
            return UserDb.FirstOrDefault(x => x.UserID == user);
        }

        public static User getUserByName(string name)
        {
            return UserDb.FirstOrDefault(x => x.UserName == name);
        }

        public static bool loginValidation(string name, string password)
        {
            InitAsync();
            if(UserDb.FirstOrDefault(x => x.UserName == name && x.UserPassword == password) != null)
            {
                return true;
            }
            return false;
        }

        public static async Task createNewUser(string username, string password, string email, string gender, DateTime DOB)
        {
            User newUser = UserFactory.createNewUser(username, password, email, gender, DOB);
            await InitAsync();
            UserDb.Add(newUser);
            saveDbChange();
        }
    }
}