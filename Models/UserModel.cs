using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;

namespace Models
{
    public class UserModel
    {
        private ToysDBContext context = null;
        public UserModel()
        {
            context = new ToysDBContext();
        }
        public bool Login(string username, string password)
        {
            object[] sqlParams = {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };
            var res = context.Database.SqlQuery<bool>("sp_user_login @username, @password", sqlParams).SingleOrDefault();
            return res; 
        }
    }
}
