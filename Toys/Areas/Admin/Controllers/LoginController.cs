using Models;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toys.Areas.Admin.Code;
using Toys.Areas.Admin.Models;
using Toys.Common;

namespace Toys.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.username, Encryptor.MD5Hash(model.password));
                if (result)
                {
                    var user = dao.GetUserByID(model.username);
                    var userSession = new UserLogin();
                    userSession.UserName = user.username;
                    userSession.UserID = user.id;
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return Redirect("/Admin/Login");
        }
    }
}