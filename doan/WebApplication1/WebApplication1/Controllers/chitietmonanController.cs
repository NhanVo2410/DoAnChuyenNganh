using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class chitietmonanController : Controller
    {
        // GET: chitietmonan
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult loadchitiet(string id)
        {
            diadiemanuongEntities db = new diadiemanuongEntities();
            List<thucan> ds = (from q in db.thucan where q.idta == id select q).ToList();
            return View(ds);
        }
    }
}