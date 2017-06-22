using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAMT2P.Models;

namespace TEAMT2P.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category/List
        public ActionResult List()
        {
            using (var ctx = new QLBHEntities())
            {
                var list = ctx.Categories.ToList();
                return PartialView("ListPartial", list);
            }
        }
    }
}