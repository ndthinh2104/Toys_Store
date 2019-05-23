using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.Framework;
using PagedList;

namespace Toys.Areas.Admin.Controllers
{
    public class productsController : BaseController
    {
        private ToysDBContext db = new ToysDBContext();

        // GET: Admin/products
        public ViewResult Index(string currentFilter, string searchString, int? page)
        {
            var products = db.products.Include(p => p.category).Include(p => p.manufacturer);
            
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var sp = from s in db.products
                    select s;
            
            if(!String.IsNullOrEmpty(searchString))
            {
                sp = sp.Where(s => s.name.Contains(searchString) || s.price.ToString().Contains(searchString) || s.id.ToString().Contains(searchString));
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(sp.OrderBy(s=>s.id).ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/products/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.categories, "id", "name");
            ViewBag.manufacturer_id = new SelectList(db.manufacturers, "id", "name");
            return View();
        }

        // POST: Admin/products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,available,description,price,price_old,category_id,manufacturer_id,big_photo")] product product)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.categories, "id", "name", product.category_id);
            ViewBag.manufacturer_id = new SelectList(db.manufacturers, "id", "name", product.manufacturer_id);
            return View(product);
        }

        // GET: Admin/products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.categories, "id", "name", product.category_id);
            ViewBag.manufacturer_id = new SelectList(db.manufacturers, "id", "name", product.manufacturer_id);
            return View(product);
        }

        // POST: Admin/products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,available,description,price,price_old,category_id,manufacturer_id,big_photo, rules")] product product)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.categories, "id", "name", product.category_id);
            ViewBag.manufacturer_id = new SelectList(db.manufacturers, "id", "name", product.manufacturer_id);
            return View(product);
        }

        // GET: Admin/products/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDAO().Delete(id);
            return RedirectToAction("Index");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            //xu ly upload
            file.SaveAs(Server.MapPath("~/Assets/Images/"+file.FileName));
            return "/Assets/Images/" + file.FileName;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
