using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMS_Web_Framework.Base;

namespace ATP2.FMS.Mvc.Controllers
{
    public class WorkerController : BaseController
    {
        // GET: Worker
        public ActionResult WorkerProfile()
        {
            return View();
        }
        public ActionResult JobHome()
        {
            return View();
        }
    }
}