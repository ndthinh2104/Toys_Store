using Models.Framework;
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

        public List<product> ListAll(ref int totalRecord,int pageIndex =1,int pageSize=2)
        {
            totalRecord = db.products.OrderBy(x => x.id).Count();
            var list =db.products.OrderBy(x => x.id).Skip((pageIndex-1)*pageSize).Take(pageSize).ToList();
            return list;
        }
        public List<product> ListAll()
        {
            var list = db.products.OrderBy(x => x.id).ToList();
            return list;
        }

        public List<product> ListProByCate(int id, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.products.OrderBy(x => x.id).Count();
            var list = db.products.SqlQuery(" Select * from Product where category_id = @id ", new SqlParameter("id",id))
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();
            return list;
        }
        public product ViewDetail(int id)
        {
            return db.products.Find(id);
        }
        public List<product> ListProByManu(int id, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.products.SqlQuery(" Select * from Product where manufacturer_id = @id ", new SqlParameter("id", id)).Count();
            var list = db.products.SqlQuery(" Select * from Product where manufacturer_id = @id ", new SqlParameter("id", id))
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();
            return list;
        }
        public List<product> ListProBySaleOff(ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.products.SqlQuery(" Select * from Product where price <> 0 ").Count();
            var list = db.products.SqlQuery(" Select * from Product where price <> 0 ")
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();
            return list;
        }
    }
}
