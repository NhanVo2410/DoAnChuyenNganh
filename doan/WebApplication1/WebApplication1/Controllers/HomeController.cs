using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        diadiemanuongEntities db = new diadiemanuongEntities();
        public static List<quan> GetChinhanhs(diadiemanuongEntities db)
        {
            List<quan> listquan = db.quan.Select(n => n).ToList();
            return listquan;
        }
       
        public ActionResult Index()
        {
            List<quan> listsp = GetChinhanhs(db);
            return View(listsp);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}