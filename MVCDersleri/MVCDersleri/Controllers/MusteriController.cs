using MVCDersleri.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MVCDersleri.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.Musteriler select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MusteriAd.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.Musteriler.ToList();
            //return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(Musteriler musteri)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.Musteriler.Add(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var musteri = db.Musteriler.Find(id);
            db.Musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.Musteriler.Find(id);
            return View("MusteriGetir", musteri);
        }
        public ActionResult Guncelle(Musteriler musteriler)
        {
            var mus = db.Musteriler.Find(musteriler.Id);
            mus.MusteriAd = musteriler.MusteriAd;
            mus.MusteriSoyad = musteriler.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}