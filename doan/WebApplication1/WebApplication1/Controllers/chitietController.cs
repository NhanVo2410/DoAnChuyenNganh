using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class chitietController : Controller
    {
        // GET: chitiet
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult loadchitiet(int id)
        {
            diadiemanuongEntities db = new diadiemanuongEntities();
            List<quan> ds = (from q in db.quan where q.idquan == id select q).ToList();
            return View(ds);
        }
    }
}