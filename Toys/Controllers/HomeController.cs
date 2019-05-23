using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Framework;

namespace Toys.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var list = new ProductDAO().ListAll();
            ViewBag.Products = list;
            
            return View();
        }

        public ActionResult ListProByCate(int id)
        {
            List<product> listPro = new ProductDAO().ListProByCate(id);
            return View(listPro);
        }
        public ActionResult ListProByManu(int id)
        {
            List<product> listPro = new ProductDAO().ListProByManu(id);
            return View(listPro);
        }
        public ActionResult SaleOff()
        {
            var product = new ProductDAO().ListProBySaleOff();
            return View(product);
        }
    }
}