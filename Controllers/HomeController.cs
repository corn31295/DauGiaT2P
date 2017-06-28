using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAMT2P.Models;
namespace TEAMT2P.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            TopHomeIndex obj = new TopHomeIndex();
            List<Product> list1 = new List<Product>();
            List<Product> list2 = new List<Product>();
            using (var ctx = new QLBHEntities())
            {
                list1 = ctx.Products
                    .OrderByDescending(p => p.Price)
                    .Take(5)
                    .ToList();
                obj.LstTop51 = list1;
                //lstwash

                list2 = ctx.Products
                        .OrderByDescending(p => p.Quantity)
                        .Take(5)
                        .ToList();
                obj.LstTop52 = list2;
            }


            return View(obj);
        }
    }
}