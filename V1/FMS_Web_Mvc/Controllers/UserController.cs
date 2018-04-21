using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FMS_Web_Mvc.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult RegisterForm()
        {

            return View();
        }
        [HttpPost]
        public ActionResult RegisterForm(object obj)
        {
            return View();
        }
    }
}