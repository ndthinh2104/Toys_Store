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
    public class billsController : BaseController
    {
        private ToysDBContext db = new ToysDBContext();

        // GET: Admin/bills
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            var bill_detail = db.bill_detail.Include(b => b.bill).Include(b => b.product);
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var a = from s in db.bill_detail
                     select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                a = a.Where(s => s.product.name.Contains(searchString) || s.bill.address.ToString().Contains(searchString) || s.bill_id.ToString().Contains(searchString));
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(a.OrderBy(s => s.bill_id).ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/bills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bill_detail bill_detail = db.bill_detail.Find(id);
            if (bill_detail == null)
            {
                return HttpNotFound();
            }
            return View(bill_detail);
        }

        // GET: Admin/bills/Create
        public ActionResult Create()
        {
            ViewBag.bill_id = new SelectList(db.bills, "id", "id");
            ViewBag.product_id = new SelectList(db.products, "id", "name");
            return View();
        }

        // POST: Admin/bills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "product_id,bill_id,amount,price")] bill_detail bill_detail)
        {
            if (ModelState.IsValid)
            {
                db.bill_detail.Add(bill_detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bill_id = new SelectList(db.bills, "id", "id", bill_detail.bill_id);
            ViewBag.product_id = new SelectList(db.products, "id", "name", bill_detail.product_id);
            return View(bill_detail);
        }

        // GET: Admin/bills/Edit/5
        public ActionResult Edit(int? bill_id)
        {
            if (bill_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bill_detail bill_detail = db.bill_detail.Find(bill_id);
            if (bill_detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.bill_id = new SelectList(db.bills, "id", "id", bill_detail.bill_id);
            ViewBag.product_id = new SelectList(db.products, "id", "name", bill_detail.product_id);
            return View(bill_detail);
        }

        // POST: Admin/bills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_id,bill_id,amount,price")] bill_detail bill_detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill_detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bill_id = new SelectList(db.bills, "id", "id", bill_detail.bill_id);
            ViewBag.product_id = new SelectList(db.products, "id", "name", bill_detail.product_id);
            return View(bill_detail);
        }

        // GET: Admin/bills/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id, int bill_id)
        {
            new BillDetailDAO().Delete(bill_id);
            new BillDAO().Delete(id);
            return RedirectToAction("Index");
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
