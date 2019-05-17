using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;
namespace Models.DAO
{
    public class CategoryDAO
    {
        ToysDBContext db = null;
        public CategoryDAO()
        {
            db = new ToysDBContext();
        }

        public bool Delete(int id)
        {
            var category = db.categories.Find(id);
            db.categories.Remove(category);
            db.SaveChanges();
            return true;
        }
    }
}
