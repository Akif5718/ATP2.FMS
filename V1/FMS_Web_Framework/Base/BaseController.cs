using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FMS_RepositoryOracle;

namespace FMS_Web_Framework.Base
{
    public class BaseController:Controller 
    {
        private static UserDAO _userDao;
        public static UserDAO userDao
        {
            get
            {
                if (_userDao == null)
                    _userDao = new UserDAO();
                return _userDao;
            }
        }
    }
}
