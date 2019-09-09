using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Areas.admin.Controllers
{
    public class chitietdonhangsController : Controller
    {
        private diadiemanuongEntities db = new diadiemanuongEntities();

        // GET: admin/chitietdonhangs
        public ActionResult Index(string error)
        {
            if (Session["taikhoanadmin"] == null)
            {

                return RedirectToAction("Login", "useradmin");
            }
            else
            {
                ViewBag.CateError = error;
                var chitietdonhang = db.chitietdonhang.Include(c => c.donhang).Include(c => c.thucan);
                return View(chitietdonhang.ToList());
            }
           
        }

        // GET: admin/chitietdonhangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chitietdonhang chitietdonhang = db.chitietdonhang.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            return View(chitietdonhang);
        }

        // GET: admin/chitietdonhangs/Create
        public ActionResult Create()
        {
            ViewBag.iddh = new SelectList(db.donhang, "iddh", "sdtkh");
            ViewBag.idta = new SelectList(db.thucan, "idta", "tenta");
            return View();
        }

        // POST: admin/chitietdonhangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iddh,idta,soluong,dongia")] chitietdonhang chitietdonhang)
        {
            if (ModelState.IsValid)
            {
                db.chitietdonhang.Add(chitietdonhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iddh = new SelectList(db.donhang, "iddh", "sdtkh", chitietdonhang.iddh);
            ViewBag.idta = new SelectList(db.thucan, "idta", "tenta", chitietdonhang.idta);
            return View(chitietdonhang);
        }

        // GET: admin/chitietdonhangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chitietdonhang chitietdonhang = db.chitietdonhang.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.iddh = new SelectList(db.donhang, "iddh", "sdtkh", chitietdonhang.iddh);
            ViewBag.idta = new SelectList(db.thucan, "idta", "tenta", chitietdonhang.idta);
            return View(chitietdonhang);
        }

        // POST: admin/chitietdonhangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iddh,idta,soluong,dongia")] chitietdonhang chitietdonhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietdonhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iddh = new SelectList(db.donhang, "iddh", "sdtkh", chitietdonhang.iddh);
            ViewBag.idta = new SelectList(db.thucan, "idta", "tenta", chitietdonhang.idta);
            return View(chitietdonhang);
        }

        // GET: admin/chitietdonhangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chitietdonhang chitietdonhang = db.chitietdonhang.Find(id);
            if (chitietdonhang == null)
            {
                return HttpNotFound();
            }
            return View(chitietdonhang);
        }

        // POST: admin/chitietdonhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chitietdonhang chitietdonhang = db.chitietdonhang.Find(id);
            db.chitietdonhang.Remove(chitietdonhang);
            db.SaveChanges();
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
