﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMS_Entities;
using FMS_Model;
using FMS_RepositoryOracle;
using FMS_Web_Framework.Base;

namespace FMS_Web_Mvc.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult RegisterForm()
        {

            return View();
        }
        [HttpPost]
        public ActionResult RegisterForm(UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return View("RegisterForm", userInfo);
            }

            try
            {
                var result = userDao.Save(userInfo);
                if (result.HasError)
                {
                    ViewBag.Message = result.Message;
                    return View("RegisterForm", userInfo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("RegisterForm");
        }
    }
}