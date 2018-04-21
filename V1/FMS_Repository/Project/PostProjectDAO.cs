using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS_Data;
using FMS_Entities;
using FMS_Framework.Helper;
using FMS_Framework.Object;
using PostAProject = FMS_Entities.PostAProject;

namespace FMS_Repository
{
   public class PostProjectDAO
    {
       public Result<PostAProject> Save(PostAProject PostAProject)
        {
            var result = new Result<PostAProject>();
            try
            {
                string query = "select * from PostAProject where PostID=" + PostAProject.PostId;
                var dt = DataAccess.GetDataTable(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                     PostAProject.PostId = GetID();
                    query = "insert into PostAProject values(" + PostAProject.PostId + "," + PostAProject.WUserId + ",'" + PostAProject.ProjectName + "','" + PostAProject.StartTime + "','" + PostAProject.EndTime + "','" + PostAProject.Description + "','" + PostAProject.ProjectSection + "'," + PostAProject.Price + "," + PostAProject.Members + ")";
                }
                else
                {
                    query = "update PostAProject set ProjectName='" + PostAProject.ProjectName + "',StartTime='" + PostAProject.StartTime + "',EndTime='" + PostAProject.EndTime + "',Description='" + PostAProject.Description + "',ProjectSection='" + PostAProject.ProjectSection + "',Price=" + PostAProject.Price + ",Members=" + PostAProject.Members + " where PostID=" + PostAProject.PostId;
                }

                if (!IsValid(PostAProject, result))
                {
                    return result;
                }

                result.HasError = DataAccess.ExecuteQuery(query) <= 0;

                if (result.HasError)
                    result.Message = "Something Went Wrong";
                else
                {
                    result.Data = PostAProject;
                }
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

       private int GetID()
       {
           string query = "select * from PostAProject order by PostID desc";
           var dt = DataAccess.GetDataTable(query);
           int id = 1;

           if (dt != null && dt.Rows.Count != 0)
               id = Int32.Parse(dt.Rows[0]["ID"].ToString()) + 1;

           return id;
       }
       public List<PostAProject> GetAll()
        {
            var result = new List<PostAProject>();
            try
            {
                string query = "select * from PostAProject";
                var dt = DataAccess.GetDataTable(query);

                if (dt != null && dt.Rows.Count != 0)
                {
                    for (int i = 0; i <= dt.Rows.Count; i++)
                    {
                        PostAProject u = ConvertToEntity(dt.Rows[i]);
                        result.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }

       public Result<PostAProject> GetByID(int id)
        {
            var result = new Result<PostAProject>();
            try
            {
                string query = "select * from PostAProject where PostID=" + id;
                var dt = DataAccess.GetDataTable(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    result.HasError = true;
                    result.Message = "Invalid ID";
                    return result;
                }

                result.Data = ConvertToEntity(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public bool Delete(int id)
        {
            var result = new Result<PostAProject>();
            try
            {
                string query = "delete from PostAProject where PostID=" + id;
                return DataAccess.ExecuteQuery(query) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool IsValid(PostAProject obj, Result<PostAProject> result)
        {
            if (!ValidationHelper.IsStringValid(obj.ProjectName))
            {
                result.HasError = true;
                result.Message = "Invalid School Name";
                return false;
            }
           
          

            return true;
        }

        private PostAProject ConvertToEntity(DataRow row)
        {
            try
            {
                PostAProject u = new PostAProject();
                u.PostId = Int32.Parse(row["PostID"].ToString());
                u.WUserId = Int32.Parse(row["WUserID"].ToString());
                u.Price = Int32.Parse(row["Price"].ToString());
                u.Members = Int32.Parse(row["Members"].ToString());
                u.ProjectSection = Int32.Parse(row["ProjectSection"].ToString());
                u.ProjectName = row["ProjectName"].ToString();
               
                u.Description = row["Description"].ToString();
                u.StartTime = Convert.ToDateTime(row["StartTime"]);
                u.EndTime = Convert.ToDateTime(row["EndTime"]);


                return u;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
