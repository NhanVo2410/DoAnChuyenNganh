using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class ThanhToanController : Controller
    {
        diadiemanuongEntities db = new diadiemanuongEntities();
        // GET: ThanhToan
        public ActionResult Index()
        {
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            return View(giohang);
        }

        [HttpPost]
        public ActionResult StepEnd()
        {
            //Nhận reqest từ trang index
            string phone = Request.Form["phone"];
            string fullname = Request.Form["fullname"];
            string email = Request.Form["email"];
            string address = Request.Form["address"];
            string note = Request.Form["note"];
            //kiểm tra xem có customer chưa và cập nhật lại
            khachhang newCus = new khachhang();
            var cus = db.khachhang.FirstOrDefault(p => p.sdtkh.Equals(phone));
            if (cus != null)
            {
                //nếu có số điện thoại trong db rồi
                //cập nhật thông tin và lưu
                cus.hovaten = fullname;
                cus.email = email;
                cus.diachi= address;
                db.Entry(cus).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                //nếu chưa có sđt trong db
                //thêm thông tin và lưu
                return RedirectToAction("Register", "User");
            }
            //Thêm thông tin vào order và orderdetail
            List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            //thêm order mới
            donhang newOrder = new donhang();
            int newIDOrder = db.donhang.OrderByDescending(p => p.ngaydat).FirstOrDefault().iddh;
            newOrder.iddh = newIDOrder;
            newOrder.sdtkh = phone;
            newOrder.ghichu = note;
            newOrder.ngaydat = DateTime.Now.ToString();
            newOrder.trangthai = "0";
            db.donhang.Add(newOrder);
            db.SaveChanges();
            //thêm details
            for (int i = 0; i < giohang.Count; i++)
            {
                chitietdonhang newOrdts = new chitietdonhang();
                newOrdts.iddh = newOrder.iddh;
                newOrdts.idta = giohang.ElementAtOrDefault(i).thucanID;
                newOrdts.soluong = giohang.ElementAtOrDefault(i).SoLuong;
                newOrdts.dongia = giohang.ElementAtOrDefault(i).ThanhTien.ToString();
                db.chitietdonhang.Add(newOrdts);
                db.SaveChanges();
            }
            Session["MDH"] = newOrder.iddh;
            Session["Phone"] = phone;
            //xoá sạch giỏ hàng
            giohang.Clear();
            return RedirectToAction("HoaDon", "ThanhToan");
        }

        public ActionResult HoaDon()
        {
            return View();
        }
    }
}