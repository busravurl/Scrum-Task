using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrelloKubra.Models.Entities;

namespace TrelloKubra.Controllers
{
    public class GorevDurumController : Controller
    {
        dbTrelloEntities db = new dbTrelloEntities();
        public ActionResult Index()
        {
            var deger = db.tbl_GorevDurumlari.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult GorevDurumEkle()
        {
            List<SelectListItem> deger1 = (from i in db.tbl_Gorevler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.GorevAdi,
                                               Value = i.GorevId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.tbl_Durum.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.DurumAd,
                                               Value = i.DurumId.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from i in db.tbl_Kullanicilar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + " " + i.Soyad,
                                               Value = i.KullaniciId.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult GorevDurumEkle(tbl_GorevDurumlari d)
        {
            var grv = db.tbl_Gorevler.Where(k => k.GorevId == d.tbl_Gorevler.GorevId).FirstOrDefault();
            var drm = db.tbl_Durum.Where(k => k.DurumId == d.tbl_Durum.DurumId).FirstOrDefault();
            var klnci = db.tbl_Kullanicilar.Where(k => k.KullaniciId == d.tbl_Kullanicilar.KullaniciId).FirstOrDefault();
            d.tbl_Gorevler = grv;
            d.tbl_Durum = drm;
            d.tbl_Kullanicilar = klnci;
            db.tbl_GorevDurumlari.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GorevDurumGetir(int id)
        {
            var grv = db.tbl_GorevDurumlari.Find(id);
            List<SelectListItem> deger1 = (from i in db.tbl_Gorevler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.GorevAdi,
                                               Value = i.GorevId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.tbl_Durum.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.DurumAd,
                                               Value = i.DurumId.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from i in db.tbl_Kullanicilar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + " " + i.Soyad,
                                               Value = i.KullaniciId.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            return View("GorevDurumGetir", grv);
        }
        public ActionResult GorevDurumGuncelle(tbl_GorevDurumlari g)
        {
            var grv = db.tbl_GorevDurumlari.Find(g.GorevDurumId);
            grv.Aciklama = g.Aciklama;
            grv.GorevDurumTarihi = g.GorevDurumTarihi;
            grv.Yapilacakis1 = g.Yapilacakis1;
            grv.Yapilacakis2 = g.Yapilacakis2;
            grv.Yapilacakis3 = g.Yapilacakis3;
            grv.Yapilacakis4 = g.Yapilacakis4;
            var gorv = db.tbl_Gorevler.Where(k => k.GorevId == g.tbl_Gorevler.GorevId).FirstOrDefault();
            var drm = db.tbl_Durum.Where(k => k.DurumId == g.tbl_Durum.DurumId).FirstOrDefault();
            var kllnci = db.tbl_Kullanicilar.Where(k => k.KullaniciId == g.tbl_Kullanicilar.KullaniciId).FirstOrDefault();
            grv.GorevId = gorv.GorevId;
            grv.DurumId = drm.DurumId;
            grv.KullaniciId = kllnci.KullaniciId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GorevDurumSil(int id)
        {
            var grv = db.tbl_GorevDurumlari.Find(id);
            db.tbl_GorevDurumlari.Remove(grv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}