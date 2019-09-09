using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using WebApplication1.Models;
using WebApplication1.Controllers;


namespace LapTrinhWeb.Controllers
{


    public class UserController : Controller
    {
        diadiemanuongEntities db = new diadiemanuongEntities();
        public bool checkUser(string name, string pass)
        {
            if (db.khachhang.Where(m => m.sdtkh == name && m.matkhau == pass).Count() > 0)
            {
                return true;
            }
            return false;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(khachhang user)
        {
            string password2 = PasswordCrypt.CreateMD5(user.matkhau);
            //xét email ko trùng
            if (ModelState.IsValid && db.khachhang.Where(m => m.sdtkh.Equals(user.sdtkh)).Count() == 0)

            {
                khachhang objKH = new khachhang();
                objKH.hovaten = user.hovaten;
                objKH.email = user.email;
                objKH.matkhau = password2;
                objKH.sdtkh = user.sdtkh;
                objKH.diachi = user.diachi;



                //chèn dữ liệu vào bảng khách hàng
                db.khachhang.Add(objKH);
                //lưu vào csdl

                db.SaveChanges();

                return RedirectToAction("Login", "user", HomeController.GetChinhanhs(db));
            }
            else if (ModelState.IsValid && db.khachhang.Where(m => m.sdtkh.Equals(user.sdtkh)).Count() > 0)
            // trùng email
            {
                ModelState.AddModelError("Email", "Email đã tồn tại !");
            }
            return View("Register");
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut(); //xoa cookie

            //WebSecurity.Logout();
            Session["Name"] = null;
            return RedirectToAction("LogIn", "User");
        }
        [HttpPost]
        public ActionResult LogIn(khachhang user1)
        {
            //dùng để clear lỗi của ràng buộc nhập tên kh.
            //ModelState.Where(m => m.Key == "tenkh").FirstOrDefault().Value.Errors.Clear();
            //ModelState.Where(m => m.Key == "sdt").FirstOrDefault().Value.Errors.Clear();
            if (ModelState.IsValid)
            {
                string pass = PasswordCrypt.CreateMD5(user1.matkhau);
                //ModelState.Where(m => m.Key == "tenkh").FirstOrDefault().Value.Errors.Clear();
                if (db.khachhang.Where(m => m.sdtkh == user1.sdtkh && m.matkhau == pass).Count() == 1)

                {
                    khachhang kh = db.khachhang.Where(m => m.sdtkh == user1.sdtkh && m.matkhau == pass).FirstOrDefault();
                    //gọi hàm GetRolesForUser(string username) 
                    //trong fie CustomRoleProvider.cs) 
                    //nó sẽ chuyền giá trị username để lấy quyền.
                    FormsAuthentication.SetAuthCookie(user1.email, true);

                    Session["Name"] = user1.sdtkh;
                    return RedirectToAction("Index", "Home", HomeController.GetChinhanhs(db));
                }
                else if (db.khachhang.Where(m => m.sdtkh == user1.sdtkh && m.matkhau == pass).Count() == 0)
                {
                    ViewBag.ErrorMessage = "SAI TÊN ĐĂNG NHẬP HOẶC MẬT KHẨU\n Chưa có tài khoản? Bấm Đăng ký";
                }
            }
            return View(user1);
          
        }

    }
}







