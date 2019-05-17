using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ProductDAO
    {
        ToysDBContext db = null;
        public ProductDAO()
        {
            db = new ToysDBContext();
        }

        public bool Delete(int id)
        {
            var product = db.products.Find(id);
            db.products.Remove(product);
            db.SaveChanges();
            return true;
        }

        public List<product> ListAll()
        {
            var list =db.products.OrderBy(x => x.id).ToList();
            List<product> pdlist = new List<product>();
            foreach(product pd in list)
            {
                pd.big_photo = "/Assets/" + pd.big_photo.Trim();
                pdlist.Add(pd);
            }
            return pdlist;
        }
        public product ViewDetail(int id)
        {
            return db.products.Find(id);
        }
    }
}
