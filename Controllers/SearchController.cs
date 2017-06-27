using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAMT2P.Models;
using PagedList.Mvc;
using PagedList;

namespace TEAMT2P.Controllers
{
    public class SearchController : Controller
    {
        QLBHEntities db = new QLBHEntities();
        [HttpPost]
        // GET: Search
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<Product> lstKQTK = db.Products.Where(n => n.ProName.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm";
                return View(db.Products.OrderBy(n => n.ProName).ToPagedList(pageNumber,pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy" + lstKQTK.Count + "Kết quả!";
            return View(lstKQTK.OrderBy(n => n.ProName).ToPagedList(pageNumber,pageSize));
        }

        //public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        //{
        //    string sTuKhoa = f["txtTimKiem"].ToString();
        //    List<Product> lstKQTK = db.Products.Where(n => n.ProName.Contains(sTuKhoa)).ToList();
        //    //Phân trang
        //    int pageNumber = (page ?? 1);
        //    int pageSize = 9;
        //    if (lstKQTK.Count == 0)
        //    {
        //        ViewBag.ThongBao = "Không tìm thấy sản phẩm";
        //        return View(db.Products.OrderBy(n => n.ProName).ToPagedList(pageNumber, pageSize));
        //    }
        //    ViewBag.ThongBao = "Đã tìm thấy" + lstKQTK.Count + "Kết quả!";
        //    return View(lstKQTK.OrderBy(n => n.ProName).ToPagedList(pageNumber, pageSize));
        //}
    }
}