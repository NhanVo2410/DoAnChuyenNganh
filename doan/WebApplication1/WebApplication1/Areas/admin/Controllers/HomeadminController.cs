using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Areas.admin.Controllers
{
    public class HomeadminController : Controller
    {
        diadiemanuongEntities db = new diadiemanuongEntities();
        // GET: admin/Home
        public ActionResult Index()
        {
            if (Session["taikhoanadmin"] == null)
            {

            
                
                return RedirectToAction("Login", "useradmin");
            }
            else
            {
                return View();
            }
            
        }
       
      
    }
}