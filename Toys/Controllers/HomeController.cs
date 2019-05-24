using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Framework;
using PagedList;

namespace Toys.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? page = 1, int pageSize = 6)
        {
            int pageNumber = page ?? 1;
            List<product> list = new ProductDAO().ListAll();
            var listpro = list.ToPagedList(pageNumber, pageSize);
            IPagedList<product> pagePro = new StaticPagedList<product>(listpro
    ,pageNumber, pageSize, list.Count());
            return View(pagePro);
        }

        public ActionResult ListProByCate(int id, int? page = 1, int pageSize = 6)
        {
            int pageNumber = page ?? 1;
            List<product> list = new ProductDAO().ListProByCate(id);
            var listpro = list.ToPagedList(pageNumber, pageSize);
            IPagedList<product> pagePro = new StaticPagedList<product>(listpro
    , pageNumber, pageSize, list.Count());

            return View(pagePro);
        }
        public ActionResult ListProByManu(int id, int? page = 1, int pageSize = 6)
        {
            int pageNumber = page ?? 1;
            List<product> list = new ProductDAO().ListProByManu(id);
            var listpro = list.ToPagedList(pageNumber, pageSize);
            IPagedList<product> pagePro = new StaticPagedList<product>(listpro
, pageNumber, pageSize, list.Count());
            return View(pagePro);
        }
        public ActionResult SaleOff(int? page = 1, int pageSize = 6)   
        {
            int pageNumber = page ?? 1;
            List<product> list = new ProductDAO().ListProBySaleOff();
            var listpro = list.ToPagedList(pageNumber, pageSize);
            IPagedList<product> pagePro = new StaticPagedList<product>(listpro
, pageNumber, pageSize, list.Count());
            return View(pagePro);
        }
    }
}