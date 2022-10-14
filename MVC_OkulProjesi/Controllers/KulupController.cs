using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_OkulProjesi.Models.EntityFramework;

namespace MVC_OkulProjesi.Controllers
{
    public class KulupController : Controller
    {
        // GET: Kulup
        DbOkulMVCEntities db = new DbOkulMVCEntities();
        public ActionResult Index()
        {
            var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(TBLKULUPLER kulup)
        {
            db.TBLKULUPLER.Add(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir(int id)
        {
            var klp = db.TBLKULUPLER.Find(id);
            return View("KulupGetir", klp);

        }
        public ActionResult Guncelle(TBLKULUPLER kulup)
        {
            var klp = db.TBLKULUPLER.Find(kulup.KULUPID);
            klp.KULUPAD = kulup.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulup");

        }
    }
}