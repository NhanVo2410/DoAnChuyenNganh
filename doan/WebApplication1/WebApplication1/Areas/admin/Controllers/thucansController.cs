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
    public class thucansController : Controller
    {
        private diadiemanuongEntities db = new diadiemanuongEntities();

        // GET: admin/thucans
        public ActionResult Index(string error)
        {
            if (Session["taikhoanadmin"] == null)
            {

                return RedirectToAction("Login", "useradmin");
            }
            else
            {
                ViewBag.CateError = error;
                var thucan = db.thucan.Include(t => t.quan);
                return View(thucan.ToList());
            }
            
        }

        // GET: admin/thucans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thucan thucan = db.thucan.Find(id);
            if (thucan == null)
            {
                return HttpNotFound();
            }
            return View(thucan);
        }

        // GET: admin/thucans/Create
        public ActionResult Create()
        {
            ViewBag.idquan = new SelectList(db.quan, "idquan", "tenquan");
            return View();
        }

        // POST: admin/thucans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idta,tenta,anhta,thongtinveta,takhuyenmai,tahot,trangthai,giabandau,giahientai,Quantity,ngaydang,giamgia,luotxem,idquan")] thucan thucan)
        {
            if (ModelState.IsValid)
            {
                db.thucan.Add(thucan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idquan = new SelectList(db.quan, "idquan", "tenquan", thucan.idquan);
            return View(thucan);
        }

        // GET: admin/thucans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thucan thucan = db.thucan.Find(id);
            if (thucan == null)
            {
                return HttpNotFound();
            }
            ViewBag.idquan = new SelectList(db.quan, "idquan", "tenquan", thucan.idquan);
            return View(thucan);
        }

        // POST: admin/thucans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idta,tenta,anhta,thongtinveta,takhuyenmai,tahot,trangthai,giabandau,giahientai,Quantity,ngaydang,giamgia,luotxem,idquan")] thucan thucan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thucan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idquan = new SelectList(db.quan, "idquan", "tenquan", thucan.idquan);
            return View(thucan);
        }

        // GET: admin/thucans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thucan thucan = db.thucan.Find(id);
            if (thucan == null)
            {
                return HttpNotFound();
            }
            return View(thucan);
        }

        // POST: admin/thucans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            thucan thucan = db.thucan.Find(id);
            db.thucan.Remove(thucan);
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
