using LOrdCardShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LOrdCardShop.Singleton
{
    public class dbSingleton
    {
        private static HttpCookie Cookie = HttpContext.Current.Request.Cookies["user_cookie"];
        private static Database1Entities instance;
        private static readonly object lockObject = new object();

        protected static DbSet<User> UserDb;
        protected static DbSet<Cart> CartDb;
        protected static DbSet<Card> CardDb;
        protected static DbSet<TransactionHeader> ThDb;
        protected static DbSet<TransactionDetail> TdDb;

        public static void saveDbChange()
        {
            instance.SaveChanges();
        }

        public static async Task<Database1Entities> GetInstanceAsync()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new Database1Entities();
                    }
                }
            }
            return instance;
        }

        public static async Task InitAsync()
        {
            var db = await GetInstanceAsync();
            UserDb = db.Users;
            CartDb = db.Carts;
            CardDb = db.Cards;
            ThDb = db.TransactionHeaders;
            TdDb = db.TransactionDetails;
        }

        public static void addUserCookie(string Users)
        {
            Cookie = new HttpCookie("user_cookie", Users)
            {
                Expires = DateTime.Now.AddDays(7)
            };
            HttpContext.Current.Response.Cookies.Add(Cookie);
        }

        public static void initCookie()
        {
            if (Cookie == null)
            {
                Cookie = HttpContext.Current.Request.Cookies["user_cookie"];
            }
        }

        public static HttpCookie getUserCookie()
        {
            initCookie();
            return Cookie;
        }
    }
}