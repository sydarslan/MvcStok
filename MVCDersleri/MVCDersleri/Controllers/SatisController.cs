using MVCDersleri.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDersleri.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbStokEntities db=new MvcDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis() 
        {
            return View();  
        }
        [HttpPost]
        public ActionResult YeniSatis(Satislar satis)
        {
            db.Satislar.Add(satis);
            db.SaveChanges();
            return View("Index");
        }
    }
}