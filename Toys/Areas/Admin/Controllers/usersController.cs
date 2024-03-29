﻿using System;
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
using Toys.Common;

namespace Toys.Areas.Admin.Controllers
{
    public class usersController : BaseController
    {
        private ToysDBContext db = new ToysDBContext();

        // GET: Admin/users
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            var dao = new UserDAO();
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var u = from s in db.users
                     select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                u = u.Where(s => s.fullname.Contains(searchString) || s.username.ToString().Contains(searchString) || s.email.ToString().Contains(searchString));
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(u.OrderBy(s => s.id).ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,password,fullname,permission, status, email, address, phone, gender")] user user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var encryptedMd5Pas = Encryptor.MD5Hash(user.password);
                user.password = encryptedMd5Pas;
                db.users.Add(user);
                db.SaveChanges();
                SetAlert("Thêm người dùng thành công", "success");
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Admin/users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,password,fullname,permission, status, email, address, phone, gender")] user user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var encryptedMd5Pas = Encryptor.MD5Hash(user.password);
                user.password = encryptedMd5Pas;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Admin/users/Delete/5
        [HttpDelete]
        public ActionResult Delete (int id)
        {
            new UserDAO().Delete(id);
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
