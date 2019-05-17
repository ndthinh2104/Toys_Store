﻿using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class BillDetailDAO
    {
        ToysDBContext db = null;
        public BillDetailDAO()
        {
            db = new ToysDBContext();
        }
        public List<bill_detail> ListAll()
        {
            return db.bill_detail.OrderBy(x => x.bill_id).ToList();
        }
        public bool Insert(bill_detail detail)
        {
            try
            {
                db.bill_detail.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}
