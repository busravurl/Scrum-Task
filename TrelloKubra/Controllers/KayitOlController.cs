using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrelloKubra.Models.Entities;

namespace TrelloKubra.Controllers
{
    public class KayitOlController : Controller
    {
        // GET: KayitOl
        dbTrelloEntities db = new dbTrelloEntities();
        [HttpGet]

        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]

        public ActionResult KayitOl(tbl_Kullanicilar k)
        {
            if (!ModelState.IsValid)
            {
                return View("KayitOl");
            }
            db.tbl_Kullanicilar.Add(k);
            db.SaveChanges();
            return View();
        }
    }
}