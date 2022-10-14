using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_OkulProjesi.Models.EntityFramework;

namespace MVC_OkulProjesi.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        DbOkulMVCEntities db = new DbOkulMVCEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCILER.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> kulupler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.kulup = kulupler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER ogrenci)
        {
            var klp = db.TBLKULUPLER.Where(m => m.KULUPID == ogrenci.TBLKULUPLER.KULUPID).FirstOrDefault();
            ogrenci.TBLKULUPLER = klp;
            db.TBLOGRENCILER.Add(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }

        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogr = db.TBLOGRENCILER.Find(id);
            return View("OgrenciGetir",ogr);
        }
        public ActionResult Guncelle(TBLOGRENCILER ogrenci)
        {
            var ogr = db.TBLOGRENCILER.Find(ogrenci.OGRENCIID);
            ogr.OGRAD = ogrenci.OGRAD;
            ogr.OGRSOYAD = ogrenci.OGRSOYAD;
            ogr.OGRFOTOGRAF = ogrenci.OGRFOTOGRAF;
            ogr.OGRKULUP = ogrenci.OGRKULUP;
            ogr.OGRCINSIYET = ogrenci.OGRCINSIYET;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }
    }
}