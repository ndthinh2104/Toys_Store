using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            var list = db.products.OrderBy(x => x.id).ToList();
            return list;
        }

        public List<product> ListProByCate(int id)
        {
            var list = db.products.SqlQuery(" Select * from Product where category_id = @id ", new SqlParameter("id",id))
                                .ToList();
            return list;
        }
        public product ViewDetail(int id)
        {
            return db.products.Find(id);
        }

        public List<product> ListProByManu(int id)
        {
            var list = db.products.SqlQuery(" Select * from Product where manufacturer_id = @id ", new SqlParameter("id", id)).ToList();
            return list;
        }

        public List<product> ListProBySaleOff()
        {
            var list = db.products.SqlQuery(" Select * from Product where price <> 0 ").ToList();
            return list;
        }
    }
}
