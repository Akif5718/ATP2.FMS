﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMS_Entities;
using FMS_Model;
using FMS_Repository;
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
        public ActionResult CreateProject(PostProjectModel PostProjectModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateProject", PostProjectModel);
            }

            try
            {
                var postAProject=new PostAProject();
                postAProject.ProjectName = PostProjectModel.ProjectName;
                postAProject.Description = PostProjectModel.Description;
                postAProject.Price = PostProjectModel.Price;
                postAProject.StartTime = PostProjectModel.StartTime;
                postAProject.EndTime = PostProjectModel.EndTime;
                postAProject.Members = PostProjectModel.Members;
                var result = postProjectDao.Save(postAProject);

                foreach (var x in PostProjectModel.SectionName)
                {
                    var projectsection = new ProjectSection();
                    projectsection.SectionName = x;
                    var result1 = projectSectionDao.Save(projectsection);
                }

                foreach (var skillid in PostProjectModel.SkillId)
                {
                    var projectskill = new ProjectSkills();
                    projectskill.SkillID = skillid;
                    var result2 = projectSkillDao.Save(projectskill);
                }
              

              
                
                
                if (result.HasError)
                {
                    ViewBag.Message = result.Message;
                    return View("CreateProject", PostProjectModel);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("CreateProject");
        }

       

        public ActionResult ProjectDetails(int? id)
        {
            var result = postProjectDao.GetByID(1);
            PostProjectModel postProjectModel= new PostProjectModel();

            postProjectModel.ProjectName = result.Data.ProjectName;
            postProjectModel.Description = result.Data.Description;
            postProjectModel.Price = result.Data.Price;
            postProjectModel.StartTime = result.Data.StartTime;
            postProjectModel.EndTime = result.Data.EndTime;
            postProjectModel.WUserId = result.Data.WUserId;
            postProjectModel.PostId = result.Data.PostId;

            var result2 = projectSkillDao.GetAll(result.Data.PostId);
            foreach (var skillid in result2)
            {
                var result3 = skillsDao.GetByID(skillid.SkillID);

                postProjectModel.SkillName.Add(result3.Data.SkillName);
                  
            }

            var result4 = userDao.GetById(result.Data.WUserId);
            postProjectModel.UFirstName = result4.Data.FristName;
            postProjectModel.ULastName = result4.Data.LastName;


            return View(postProjectModel);
        }

        [HttpPost]
        public ActionResult ProjectDetails(PostProjectModel PostProjectModel)
        {
          

           

            try
            {

                ResponseToaJob responseto = new ResponseToaJob();
                responseto.PostId = PostProjectModel.PostId;
                responseto.WUserId = 1;
                var result = response.Save(responseto);

                if (result.HasError)
                {
                    ViewBag.Message = result.Message;
                    return View("ProjectDetails", PostProjectModel);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("ProjectDetails");
        }

        public ActionResult RequestedMember()
        {
            RequestedMemberModel requested=new RequestedMemberModel();
            var result = response.GetAll(1);

            var result2 = postProjectDao.GetByID(1);
            requested.ProjectName = result2.Data.ProjectName;
            requested.Description = result2.Data.Description;
            foreach (var user in result)
            {
                var result3 = userDao.GetById(user.WUserId);
                requested.UserInfo.Add(result3.Data);

            }
            return View(requested);
        }


    }
}