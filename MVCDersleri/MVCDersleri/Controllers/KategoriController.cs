using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDersleri.Models.Entitiy;
using PagedList;
using PagedList.Mvc;
namespace MVCDersleri.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.Kategoriler.ToList();
            var degerler = db.Kategoriler.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult YeniKategori(Kategoriler kategori)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.Kategoriler.Add(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");  
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            return View("KategoriGetir",kategori);
        }
        public ActionResult Guncelle(Kategoriler kategori)
        {
            var ktgr = db.Kategoriler.Find(kategori.Id);
            ktgr.KategoriAd = kategori.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
      
    }
} 