using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication2.Controllers
{
    public class danhmucController : Controller
    {
        // GET: danhmuc
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult loaddanhmuc()
        {
            diadiemanuongEntities db = new diadiemanuongEntities();
            List<danhmuc> catlist = db.danhmuc.Select(n => n).ToList();
            return PartialView(catlist);
        }
        public ActionResult danhsachcacdanhmuc(int id)
        {
            diadiemanuongEntities db = new diadiemanuongEntities();
            List<quan> dsquan = (from q in db.quan where q.iddm == id select q).ToList();
            return View(dsquan);
        }
    }
}