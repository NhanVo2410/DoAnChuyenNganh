using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class timkiemController : Controller
    {
        diadiemanuongEntities db = new diadiemanuongEntities();

        // POST: timkiem
        public ActionResult kqtimkiemtheodiachi(FormCollection f)
        {

            string key = f["timkiem"].ToString();
            List<quan> kqloaiquan = db.quan.Where(n => n.mota.Contains(key)).ToList();
            List<quan> kqtp = db.quan.Where(n => n.tentp.Contains(key)).ToList();
            List<quan> kqquanhuyen = db.quan.Where(n => n.tenquanhuyen.Contains(key)).ToList();
            List<quan> kqphuongxa = db.quan.Where(n => n.tenphuongxa.Contains(key)).ToList();
            List<quan> kqduong = db.quan.Where(n => n.tenduong.Contains(key)).ToList();
           

            if (kqtp.Count != 0)
            {
                return View(kqtp);
            }
            else if (kqloaiquan.Count != 0)
            {
                return View(kqloaiquan);
            }
            else if(kqquanhuyen.Count != 0)
            {
                return View(kqquanhuyen);
            }
            else if (kqphuongxa.Count != 0)
            {
                return View(kqphuongxa);
            }
            else if (kqduong.Count != 0)
            {
                return View(kqduong);
            }
            

            return RedirectToAction("Index", "Home", HomeController.GetChinhanhs(db));
        }
    
    }
}
