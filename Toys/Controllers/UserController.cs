using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.Framework;
namespace Toys.Controllers
{
    public class UserController : Controller
    {
        public JsonResult Login(string UserName, string Password)
        {

            int ret = -1;
            Password = Common.Encryptor.MD5Hash(Password);
            UserDAO user = new UserDAO();
            if (user.Login(UserName, Password))
            {
                user u = new user();
                u = user.GetUserByID(UserName);
                Session["username"] = u.fullname;
                Session["User"] = u;
                ret = 1;
            }

            return Json(new
            {
                ret //ok
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult logOut()
        {
            Session["username"] = null;
            Session["User"] = null;
            return Redirect("/home/index");
        }


    }
}