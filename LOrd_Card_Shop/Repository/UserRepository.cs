using LOrd_Card_Shop.Factory;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Singleton;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace LOrd_Card_Shop.Repository
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

        public static async Task<bool> loginValidation(string name, string password)
        {
            await InitAsync();
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

        public static async Task updateUser(string username, string password, string email, string gender, DateTime DOB)
        {
            User updatedData = UserFactory.createNewUser(username, password, email, gender, DOB);
            await InitAsync();
            UserDb.AddOrUpdate(updatedData);
            saveDbChange();
        }
    }
}