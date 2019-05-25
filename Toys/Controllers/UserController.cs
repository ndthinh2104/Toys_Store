using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.Framework;
using Toys.Areas.Admin.Models;
using Toys.Common;

namespace Toys.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public JsonResult Login(LoginModel model)
        {

            int ret = -1;
            var dao = new UserDAO();
            var result = dao.Login(model.username, Encryptor.MD5Hash(model.password));
            if (result)
            {
                var user = dao.GetUserByID(model.username);
                var userSession = new UserLogin();
                userSession.UserName = user.fullname;
                userSession.UserID = user.id;
                Session.Add(CommonConstant.USER_SESSION, userSession);
                ret = 1;
            }

            return Json(new
            {
                ret //ok
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult logOut()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return Redirect("/Home/Index");
        }

        public ActionResult register()
        {
            return View();
        }
        public JsonResult signUp(string username,string password,string name,int gender,string address,string phone,string email)
        {
            ToysDBContext db = new ToysDBContext();
            int ret = -1;

            user user = new user();
            user.address = address;
            user.email = email;
            user.username = username;
            user.gender = gender;
            user.fullname = name;
            user.password = Encryptor.MD5Hash(password);
            user.permission = 0;
            user.phone = phone;

            db.users.Add(user);
            int stt = db.SaveChanges();

            if (stt > 0)
            {
                ret = 1;
            }
            return Json(new
            {
                ret //ok
            }, JsonRequestBehavior.AllowGet); ;
        }
    }
}