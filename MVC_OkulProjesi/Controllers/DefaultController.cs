using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_OkulProjesi.Models.EntityFramework;

namespace MVC_OkulProjesi.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbOkulMVCEntities db = new DbOkulMVCEntities();
        public ActionResult Index()
        {
            var dersler = db.TBLDERSLER.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDers(TBLDERSLER ders)
        {
            db.TBLDERSLER.Add(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            var drs = db.TBLDERSLER.Find(id);
            return View("DersGetir",drs);
        }
        public ActionResult Guncelle(TBLDERSLER ders)
        {
            var drs = db.TBLDERSLER.Find(ders.DERSID);
            drs.DERSAD = ders.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}