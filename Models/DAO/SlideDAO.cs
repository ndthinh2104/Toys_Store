using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class SlideDAO
    {
        ToysDBContext db = null;
        public SlideDAO()
        {
            db = new ToysDBContext();
        }

        public bool Delete(int id)
        {
            var slide = db.slides.Find(id);
            db.slides.Remove(slide);
            db.SaveChanges();
            return true;
        }

        public List<slide> ListAll()
        {

            var list = db.slides.OrderBy(x => x.id).ToList();
            return list;
        }
    }
}
