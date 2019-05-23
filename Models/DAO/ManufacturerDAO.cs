using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ManufacturerDAO
    {
        ToysDBContext db = null;
        public ManufacturerDAO()
        {
            db = new ToysDBContext();
        }

        public bool Delete(int id)
        {
            var manufacturer = db.manufacturers.Find(id);
            db.manufacturers.Remove(manufacturer);
            db.SaveChanges();
            return true;
        }
        public List<manufacturer> ListAll()
        {
            var list = db.manufacturers.OrderBy(x => x.id).ToList();
            return list;
        }
    }
}
