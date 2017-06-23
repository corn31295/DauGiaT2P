using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TEAMT2P.Models;

namespace TEAMT2P.Helpers
{
    public class CurrentContext
    {
        public static bool IsLogged()
        {
            var flag = HttpContext.Current.Session["isLogin"];
            if (flag == null || (int)flag == 0)
            {
                return false;
            }
            return true;
        }
        public static User GetCurUser()
        {
            return (User)HttpContext.Current.Session["user"];
        }

        public static WatchList GetWL()
        {
            var ret = (WatchList)HttpContext.Current.Session["wl"];
            if (ret == null)
            {
                ret = new WatchList();
                HttpContext.Current.Session["wl"] = ret;
            }
            return ret;
        }

        public static void Destroy()
        {
            HttpContext.Current.Session["isLogin"] = 0;
            HttpContext.Current.Session["user"] = null;
        }
    }
}