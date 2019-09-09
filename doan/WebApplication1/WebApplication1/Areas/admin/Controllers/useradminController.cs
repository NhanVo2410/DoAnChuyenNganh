using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Areas.admin.Controllers
{
    public class useradminController : Controller
    {
        diadiemanuongEntities db = new diadiemanuongEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        // GET: admin/useradmin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(FormCollection collection)
        {
            var tendn = collection["adacc"];
            var matkhau = collection["adpass"];
            if (ModelState.IsValid)
            {

                if (String.IsNullOrEmpty(tendn))
                {
                    ViewData["Loi1"] = "Vui lòng nhập tên đăng nhập";
                }
                else if (String.IsNullOrEmpty(matkhau))
                {
                    ViewData["Loi2"] = "Vui lòng nhập mật khẩu";
                }
                else
                {
                    Models.admin ad = db.admin.SingleOrDefault(n => n.adacc == tendn && n.adpass == matkhau);
                    if (ad != null)
                    {
                        Session["accname"] = tendn;
                        return RedirectToAction("Index", "trangchu");
                    }
                    else
                        ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
            }

            return View();

        }

        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session["accname"] = null;
            return RedirectToAction("Login", "useradmin");
        }
    }
}