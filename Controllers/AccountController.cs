using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAMT2P.Helpers;
using TEAMT2P.Models;
using BotDetect;
using BotDetect.Web.Mvc;
namespace TEAMT2P.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            string encPwd = StringUtils.Md5(model.RawPWD);
            using (var ctx = new QLBHEntities())
            {

                var user = ctx.Users
                    .Where(u => u.f_Username == model.Username && u.f_Password == encPwd)
                    .FirstOrDefault();
                if (user != null)
                {
                    Session["isLogin"] = 1;
                    Session["user"] = user;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMsg = "Đăng nhập thất bại!!!";
                    return View();
                }
            }
        }

        //
        // POST: /Account/Logout
        [HttpPost]
        public ActionResult Logout()
        {
            CurrentContext.Destroy();
            return RedirectToAction("Index", "Home");
        }
        //
        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }
        //
        // POST: /Account/Register
        [HttpPost]
        [CaptchaValidation("CaptchaCode", "ExampleCaptcha", "Incorrect CAPTCHA code!")]
        public ActionResult Register(Register model)
        {

            if (!ModelState.IsValid)
            {
                // TODO: Captcha validation failed, show error message
                ViewBag.ErrorMsg = "Nhập sai mã CAPTCHA code!";

            }
            else
            {
                // TODO: Captcha validation passed, proceed with protected action

                User u = new User
                {
                    f_Username = model.Username,
                    f_Email = model.Email,
                    f_Name = model.Name,
                    f_Address = model.Address,
                    f_Password = StringUtils.Md5(model.RawPWD),
                    f_Permission = 0,
                    f_DOB = DateTime.ParseExact(model.DOB, "d/m/yyyy", null)
                };
                using (QLBHEntities ctx = new QLBHEntities())
                {
                    ctx.Users.Add(u);
                    ctx.SaveChanges();
                    ViewBag.Msg = "Đăng ký thành công !";
                }
            }
            return View();
        }

        

    }
}