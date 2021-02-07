using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TrelloKubra.Models.Entities;

namespace TrelloKubra.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        dbTrelloEntities db = new dbTrelloEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(tbl_Kullanicilar k)
        {
            var bilgiler = db.tbl_Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == k.KullaniciAdi && x.Sifre == k.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                return RedirectToAction("Index", "Gorev");
            }
            else
            {
                return View();
            }

        }
    }
}