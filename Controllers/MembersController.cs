using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAMT2P.Helpers;
using TEAMT2P.Models;

namespace TEAMT2P.Controllers
{
    public class MembersController : Controller
    {
        // GET: Members//Edit 
        public ActionResult Edit()
        {
            User model = new Models.User();
            model = CurrentContext.GetCurUser();
            return View(model);
        }

        // POST: Members
        [HttpPost]
        public ActionResult Edit(User model)
        {
            using (var ctx = new QLBHEntities())
            {
                string username = CurrentContext.GetCurUser().f_Username;
                var user = ctx.Users
                .Where(s => s.f_Username == username).FirstOrDefault();
                if (user != null)
                {
                    user.f_Email = model.f_Email;
                    user.f_Name = model.f_Name;
                    user.f_Address = model.f_Address;
                    user.f_DOB = model.f_DOB;
                    ctx.SaveChanges();               
                }
            }
            ViewBag.Msg = "Sửa thành công !";
            return View(model);
        }

        // GET: Members//PasswordChange 
        public ActionResult PasswordChange()
        {
            return View();
        }

        // POST: Members//PasswordChange 
        [HttpPost]
        public ActionResult PasswordChange(Password model)
        {
            string encPWD = StringUtils.Md5(model.RawPWD);
            using (var ctx = new QLBHEntities())
            {
                var user = ctx.Users
                    .Where(u => u.f_Password == encPWD).FirstOrDefault();
                if (user != null)
                {
                    user.f_Password = StringUtils.Md5(model.NRawPWD);
                    ctx.SaveChanges();
                    ViewBag.Msg = "Đổi mật khẩu thành công !";
                }
                else
                {
                    ViewBag.ErrorMsg = "Mật khẩu cũ không đúng!!";
                    return View();
                }
            }
            return View();
        }       
    }
}