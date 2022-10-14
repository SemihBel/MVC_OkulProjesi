using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_OkulProjesi.Models.EntityFramework;
using MVC_OkulProjesi.Models;

namespace MVC_OkulProjesi.Controllers
{
    public class SinavController : Controller
    {
        // GET: Sinav
        DbOkulMVCEntities db = new DbOkulMVCEntities();
        public ActionResult Index()
        {
            var notlar = db.TBLNOTLAR.ToList();
            return View(notlar);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(TBLNOTLAR not)
        {
            db.TBLNOTLAR.Add(not);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotlariGetir(int id)
        {
            var not = db.TBLNOTLAR.Find(id);
            return View("NotlariGetir", not);

        }
        [HttpPost]
        public ActionResult NotlariGetir (OrtalamaHesapla model,TBLNOTLAR not,int sinav1=0, int sinav2 =0, int sinav3 =0, int proje =0)
        {
            if (model.islem=="HESAPLA")
            {  
                double ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
                ViewBag.ort = ortalama;
            }
            if (model.islem=="NOTGUNCELLE")
            {
                var snv = db.TBLNOTLAR.Find(not.NOTID);
                snv.SINAV1 = not.SINAV1;
                snv.SINAV2 = not.SINAV2;
                snv.SINAV3 = not.SINAV3;
                snv.PROJE = not.PROJE;
                snv.ORTALAMA = not.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Index", "Sinav");
            }
            return View();
        }
    }
}