using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAMT2P.Helpers;
using TEAMT2P.Models;

namespace TEAMT2P.Controllers
{
    public class WLController : Controller
    {
        //
        // GET: WL
        public ActionResult Index()
        {
            return View();
        }
        //
        // POST: WL/Add

            [HttpPost]
        public ActionResult Add(int proId)
        {
            using (var ctx = new QLBHEntities())
            {
                var pro = ctx.Products
                .Where(p => p.ProID == proId)
                .FirstOrDefault();

                var item = new WLItem
                {
                    Product = pro
                };

                CurrentContext.GetWL().AddItem(item);

                return RedirectToAction("Detail", "Product", new { id = proId });
            }

        }
    }
}