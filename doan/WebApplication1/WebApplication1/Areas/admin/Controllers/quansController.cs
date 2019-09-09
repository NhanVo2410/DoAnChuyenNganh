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
    public class quansController : Controller
    {
        private diadiemanuongEntities db = new diadiemanuongEntities();

        // GET: admin/quans
        public ActionResult Index(string error)
        {
            if (Session["taikhoanadmin"] == null)
            {

                return RedirectToAction("Login", "useradmin");
            }
            else
            {
                ViewBag.CateError = error;
                var quan = db.quan.Include(q => q.danhmuc).Include(q => q.loaiquanan);
                return View(quan.ToList());
            }
            
        }

        // GET: admin/quans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quan quan = db.quan.Find(id);
            if (quan == null)
            {
                return HttpNotFound();
            }
            return View(quan);
        }

        // GET: admin/quans/Create
        public ActionResult Create()
        {
            ViewBag.iddm = new SelectList(db.danhmuc, "iddm", "tendm");
            ViewBag.idloaiquan = new SelectList(db.loaiquanan, "idloaiquan", "tenloaiquan");
            return View();
        }

        // POST: admin/quans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idquan,tenquan,idloaiquan,mota,hinhanhquan,hinhanhquan1,hinhanhquan2,sonha,tenduong,tenphuongxa,tenquanhuyen,tentp,giomocua,giodongcua,trangthai,binhluan,luotxem,urlggmap,iddm")] quan quan)
        {
            if (ModelState.IsValid)
            {
                db.quan.Add(quan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iddm = new SelectList(db.danhmuc, "iddm", "tendm", quan.iddm);
            ViewBag.idloaiquan = new SelectList(db.loaiquanan, "idloaiquan", "tenloaiquan", quan.idloaiquan);
            return View(quan);
        }

        // GET: admin/quans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quan quan = db.quan.Find(id);
            if (quan == null)
            {
                return HttpNotFound();
            }
            ViewBag.iddm = new SelectList(db.danhmuc, "iddm", "tendm", quan.iddm);
            ViewBag.idloaiquan = new SelectList(db.loaiquanan, "idloaiquan", "tenloaiquan", quan.idloaiquan);
            return View(quan);
        }

        // POST: admin/quans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idquan,tenquan,idloaiquan,mota,hinhanhquan,hinhanhquan1,hinhanhquan2,sonha,tenduong,tenphuongxa,tenquanhuyen,tentp,giomocua,giodongcua,trangthai,binhluan,luotxem,urlggmap,iddm")] quan quan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iddm = new SelectList(db.danhmuc, "iddm", "tendm", quan.iddm);
            ViewBag.idloaiquan = new SelectList(db.loaiquanan, "idloaiquan", "tenloaiquan", quan.idloaiquan);
            return View(quan);
        }

        // GET: admin/quans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quan quan = db.quan.Find(id);
            if (quan == null)
            {
                return HttpNotFound();
            }
            return View(quan);
        }

        // POST: admin/quans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            quan quan = db.quan.Find(id);
            db.quan.Remove(quan);
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
