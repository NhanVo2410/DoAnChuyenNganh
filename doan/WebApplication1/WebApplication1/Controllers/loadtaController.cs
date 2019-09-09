using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class loadtaController : Controller
    {

        diadiemanuongEntities db = new diadiemanuongEntities();
        [ChildActionOnly]
        public ActionResult loadthucan(int idquan=0)
        {
            
                if (idquan != 0)
                {
                   // ViewBag.TieuDe = db.quan.SingleOrDefault(p => p.tenquan != null).tenquan;
                    var model = db.thucan.Where(p => p.idquan == idquan).ToList();
                 //  ViewBag.TieuDe = model.
                    return PartialView(model);
                }


            return PartialView();
        }
        // GET: chitiet
        public ActionResult Index()
        {
            
            return View();
        }

    }
}