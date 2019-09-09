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
    public class donhangsController : Controller
    {
        private diadiemanuongEntities db = new diadiemanuongEntities();

        // GET: admin/donhangs
        public ActionResult Index(string error)
        {
            if (Session["accname"] == null)
            {
                
                return RedirectToAction("Login", "useradmin");
            }
            else
            {
                ViewBag.CateError = error;
                var donhang = db.donhang.Include(d => d.khachhang);
                return View(donhang.ToList());
            }
        }

        // GET: admin/donhangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donhang donhang = db.donhang.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(donhang);
        }

        // GET: admin/donhangs/Create
        public ActionResult Create()
        {
            ViewBag.sdtkh = new SelectList(db.khachhang, "sdtkh", "matkhau");
            return View();
        }

        // POST: admin/donhangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iddh,sdtkh,ngaydat,ghichu,trangthai")] donhang donhang)
        {
            if (ModelState.IsValid)
            {
                db.donhang.Add(donhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sdtkh = new SelectList(db.khachhang, "sdtkh", "matkhau", donhang.sdtkh);
            return View(donhang);
        }

        // GET: admin/donhangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donhang donhang = db.donhang.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.sdtkh = new SelectList(db.khachhang, "sdtkh", "matkhau", donhang.sdtkh);
            return View(donhang);
        }

        // POST: admin/donhangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iddh,sdtkh,ngaydat,ghichu,trangthai")] donhang donhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sdtkh = new SelectList(db.khachhang, "sdtkh", "matkhau", donhang.sdtkh);
            return View(donhang);
        }

        // GET: admin/donhangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            donhang donhang = db.donhang.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(donhang);
        }

        // POST: admin/donhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            donhang donhang = db.donhang.Find(id);
            db.donhang.Remove(donhang);
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
