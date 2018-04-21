using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS_Framework.Helper;
using FMS_Framework.Object;
using EducationalBackground = FMS_Entities.EducationalBackground;

namespace FMS_Repository_EF
{
    class EducationalBackgroundRepo:BaseRepo
    {
        public Result<EducationalBackground> Save(EducationalBackground userinfo)
        {
            var result = new Result<EducationalBackground>();
            try
            {
                var objtosave = DbContext.EducationalBackgrounds.FirstOrDefault(u => u.UserId == userinfo.UserId);
                if (objtosave == null)
                {
                    objtosave = new EducationalBackground();
                    DbContext.EducationalBackgrounds.Add(objtosave);
                }
                objtosave.School = userinfo.School;
                objtosave.Collage = userinfo.Collage;
                objtosave.UniversityPost = userinfo.UniversityPost;
                objtosave.UniversityUnder = userinfo.UniversityUnder;
                objtosave.Others = userinfo.Others;
            

                if (!IsValid(objtosave, result))
                {
                    return result;
                }
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

       
        private bool IsValid(EducationalBackground obj, Result<EducationalBackground> result)
        {
            if (!ValidationHelper.IsStringValid(obj.School))
            {
                result.HasError = true;
                result.Message = "Invalid Name";
                return false;
            }
            if (!ValidationHelper.IsStringValid(obj.Collage))
            {
                result.HasError = true;
                result.Message = "Invalid UserName";
                return false;
            }
          
         
          
            return true;
        }
    }
}
