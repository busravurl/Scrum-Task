using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrelloKubra.Models.Entities;


namespace TrelloKubra.Controllers
{
    [Authorize]
    public class GorevController : Controller
    {
        dbTrelloEntities db = new dbTrelloEntities();
        public ActionResult Index()
        {
            var deger = db.tbl_Gorevler.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult GorevEkle()
        {
            List<SelectListItem> deger1 = (from i in db.tbl_Durum.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.DurumAd,
                                               Value = i.DurumId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult GorevEkle(tbl_Gorevler g)
        {
            var drm = db.tbl_Durum.Where(k => k.DurumId == g.tbl_Durum.DurumId).FirstOrDefault();
            g.tbl_Durum = drm;
            db.tbl_Gorevler.Add(g);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GorevGetir(int id)
        {
            var grv = db.tbl_Gorevler.Find(id);
            List<SelectListItem> deger1 = (from i in db.tbl_Durum.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.DurumAd,
                                               Value = i.DurumId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View("GorevGetir", grv);
        }
        public ActionResult GorevGuncelle(tbl_Gorevler g)
        {
            var grv = db.tbl_Gorevler.Find(g.GorevId);
            grv.Aciklama = g.Aciklama;
            grv.GerceklesenTarih = g.GerceklesenTarih;
            grv.GorevAdi = g.GorevAdi;
            grv.GorevTarihi = g.GorevTarihi;
            grv.Notlar = g.Notlar;
            grv.TahminiTarih = g.TahminiTarih;
            var drm = db.tbl_Durum.Where(k => k.DurumId == g.tbl_Durum.DurumId).FirstOrDefault();
            grv.DurumId = drm.DurumId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GorevSil(int id)
        {
            var grv = db.tbl_Gorevler.Find(id);
            db.tbl_Gorevler.Remove(grv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}