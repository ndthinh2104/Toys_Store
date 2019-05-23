using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;
namespace Models.DAO
{
    public class UserDAO
    {
        ToysDBContext db = null;
        public UserDAO()
        {
            db = new ToysDBContext();
        }

        public int Insert(user user)
        {
            db.users.Add(user);
            db.SaveChanges();
            return user.id;
        }

        public bool Update(user entity)
        {
            user user = db.users.Find(entity.id);
            user.username = entity.username;
            user.fullname = entity.fullname;
            user.password = entity.password;
            user.address = entity.address;
            user.email = entity.email;
            user.gender = entity.gender;
            user.phone = entity.phone;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return true;
        }
        public user ViewDetail(int id)
        {
            return db.users.Find(id);
        }
        public List<user> ListAll()
        {
            var list = db.users.OrderBy(x => x.id).ToList();
            return list;
            
        }
        public user GetUserByID(string username)
        {
            return db.users.FirstOrDefault(x => x.username == username);
        }
        public bool Login(string username, string password)
        {
            var result = db.users.Count(x => x.username == username && x.password == password);
            if(result>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
