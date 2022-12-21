using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MVCDersleri.Models.Entitiy;

namespace MVCDersleri.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.Urunler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler=(from i in db.Kategoriler.ToList() 
                                           select new SelectListItem 
                                           { 
                                               Text = i.KategoriAd,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urunler urun)
        {
            var ktg=db.Kategoriler.Where(m=>m.Id==urun.Kategoriler.Id).FirstOrDefault();
            urun.Kategoriler=ktg;
            db.Urunler.Add(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urun = db.Urunler.Find(id);
            db.Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.Urunler.Find(id);
            List<SelectListItem> degerler = (from i in db.Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("UrunGetir",urun);  
        }
        public ActionResult Guncelle(Urunler urunler)
        {
            var urun = db.Urunler.Find(urunler.Id);
            urun.UrunAd = urunler.UrunAd;
            urun.Marka=urunler.Marka;
            var ktg = db.Kategoriler.Where(m => m.Id == urunler.Kategoriler.Id).FirstOrDefault();
            urun.kategorid=ktg.Id;
            urun.Stok=urunler.Stok;
            urun.Fiyat=urunler.Fiyat;
            db.SaveChanges();
            return RedirectToAction("Index");  
        }
    }
}