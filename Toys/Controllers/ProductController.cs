using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Toys.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ProductList()
        {
            var model = new ProductDAO().ListAll();
            return PartialView(model);
        }
        public ActionResult ProductDetail(int id)
        {
            var product = new ProductDAO().ViewDetail(id);
            return View(product);
        }
    }
}