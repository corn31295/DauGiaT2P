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
        // GET: Members
        public ActionResult Edit()
        {
            return View();
        }

        // POST: Members
        [HttpPost]
        public ActionResult Edit(Register model)
        {
            return View();
        }
    }
}