using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CategoryModel
    {
        private ToysDBContext context = null;
        public CategoryModel()
        {
            context = new ToysDBContext();
        }
        public List<category> ListAll()
        {
            var list = context.Database.SqlQuery<category>("sp_category_listall").ToList();
            return list;
        }
        public int Create(string name)
        {
            object[] param =
            {
                new SqlParameter("@name",name)
            };
            int res = context.Database.ExecuteSqlCommand("sp_category_insert @name", param);
                return res;
        }
    }
}
