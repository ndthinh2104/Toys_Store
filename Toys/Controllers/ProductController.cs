using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Models.Framework;

namespace Toys.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductDetail(int id)
        {
            var product = new ProductDAO().ViewDetail(id);
            return View(product);
        }

        public ActionResult Search(string SearchString, int? page = 1, int pageSize = 6)
        {
            int pageNumber = page ?? 1;
            var list = new ProductDAO().Search(SearchString);
            var listpro = list.ToPagedList(pageNumber, pageSize);
            IPagedList<product> pagePro = new StaticPagedList<product>(listpro
, pageNumber, pageSize, list.Count());
            Session["SearchString"] = SearchString;
            ViewBag.SearchString = SearchString;
            return View(pagePro);
        }

    }
}