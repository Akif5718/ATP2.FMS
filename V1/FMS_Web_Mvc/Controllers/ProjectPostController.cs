using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMS_Entities;
using FMS_Web_Framework.Base;

namespace FMS_Web_Mvc.Controllers
{
    public class ProjectPostController : BaseController
    {
        // GET: ProjectPost
        public ActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(PostAProject postAProject)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateProject", postAProject);
            }

            try
            {
                var result = postProjectDao.Save(postAProject);
                if (result.HasError)
                {
                    ViewBag.Message = result.Message;
                    return View("CreateProject", postAProject);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("CreateProject");
        }
    }
}