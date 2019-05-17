using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Toys.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var products = new ProductDAO();
            ViewBag.products = new ProductDAO().ListAll();
            var users = new UserDAO();
            ViewBag.users = new UserDAO().ListAll();
            var bills = new BillDetailDAO();
            ViewBag.bills = new BillDetailDAO().ListAll();
            return View();
        }
    }
}