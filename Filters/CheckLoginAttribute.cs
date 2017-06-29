using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAMT2P.Helpers;

namespace TEAMT2P.Filters
{
    public class CheckLoginAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(CurrentContext.IsLogged() == false)
{
                filterContext.Result = new RedirectResult("~/Account/login");
                return;
}

            base.OnActionExecuting(filterContext);
        }
    }
}