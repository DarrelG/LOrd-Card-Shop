using LOrdCardShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Singleton
{
    public class dbSingleton
    {
        private static Database1Entities instance;
        private static HttpCookie Cookie = HttpContext.Current.Request.Cookies["user_cookie"];

        public static Database1Entities getInstance()
        {
            if (instance == null)
            {
                instance = new Database1Entities();
            }
            return instance;
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