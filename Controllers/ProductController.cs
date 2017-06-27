using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAMT2P.Models;

namespace TEAMT2P.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product/ByCat

        public ActionResult ByCat(int? id, int page = 1)
        {
            if (id.HasValue == false)
            {
                return RedirectToAction("Index", "Home");
            }
            using (var ctx = new QLBHEntities())
            {

                int n = ctx.Products
                    .Where(p => p.CatID == id)
                    .Count();

                int recordsPerPage = 4;
                int nPages = n / recordsPerPage;
                int m = n % recordsPerPage;
                if (m > 0)
                {
                    nPages++;
                }

                ViewBag.Pages = nPages;
                ViewBag.CurPage = page;

                //var list = ctx.Products
                //    .Where(p => p.CatID == id)
                //    .ToList();

                var list = ctx.Products
                    .Where(p => p.CatID == id)
                    .OrderBy(p => p.ProID)
                    .Skip((page - 1) * recordsPerPage)
                    .Take(recordsPerPage)
                    .ToList();

                return View(list);
            }

        }

        //
        // GET: /Product/Detail
        public ActionResult Detail(int? id)
        {
            if (id.HasValue == false)
            {
                return RedirectToAction("Index", "Home");
            }

            using (var ctx = new QLBHEntities())
            {
                var model = ctx.Products
                   .Where(p => p.ProID == id)
                   .FirstOrDefault();


                return View(model);
            }
        }

        public ActionResult Add()
        {
            return View();
        }

        //
        // POST: /Category/Add
        [HttpPost]
        public ActionResult Add(Product model)
        {
            using (var ctx = new QLBHEntities())
            {
                ctx.Products.Add(model);
                ctx.SaveChanges();
            }
            return View();
        }

        public ActionResult List()
        {
            using (var ctx = new QLBHEntities())
            {
                var list = ctx.Products.ToList();
                return PartialView("ListPartial", list);
            }
        }

        public ActionResult Index()
        {
            var ctx = new QLBHEntities();
            var list = ctx.Products.ToList();
            //ViewBag.List = list;
            return View(list);
        }

    }
}