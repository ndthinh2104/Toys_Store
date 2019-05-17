using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;

namespace Models.DAO
{
    public class BillDAO
    {
        ToysDBContext db = null;
        public BillDAO()
        {
            db = new ToysDBContext();
        }
        public bool Delete(int id)
        {
            var bill = db.bills.Find(id);
            db.bills.Remove(bill);
            db.SaveChanges();
            return true;
        }
    }
}
