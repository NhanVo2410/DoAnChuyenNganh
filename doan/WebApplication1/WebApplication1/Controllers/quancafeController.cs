using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class quancafeController : Controller
    {
        diadiemanuongEntities db = new diadiemanuongEntities();
        public ActionResult getquancafe(int idloai=4 )
        {


            if (idloai != 0)
            {
                // ViewBag.TieuDe = db.quan.SingleOrDefault(p => p.tenquan != null).tenquan;
                var model = db.quan.Where(p => p.idloaiquan == idloai).ToList();
                //  ViewBag.TieuDe = model.
                return PartialView(model);
            }

            return PartialView();

        }
        // GET: quancafe
        public ActionResult Index()
        {
            return View();
        }
    }
}