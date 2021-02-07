using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrelloKubra.Models.Entities;

namespace TrelloKubra.Controllers
{
    public class TrelloController : Controller
    {
        dbTrelloEntities db = new dbTrelloEntities();
        public ActionResult Index()
        {

            var degerler = db.tbl_GorevDurumlari.FirstOrDefault();
            //var degerler = db.GorevDurumları.FirstOrDefault();
            //tempdata ile bilgilerin bu sayafya taşınması
            TempData["Yapilacakis1"] = degerler.Yapilacakis1.ToString();
            TempData["Yapilacakis2"] = degerler.Yapilacakis2.ToString();
            TempData["Yapilacakis3"] = degerler.Yapilacakis3.ToString();
            TempData["Yapilacakis4"] = degerler.Yapilacakis4.ToString();
            TempData["TahminiTarih"] = degerler.tbl_Gorevler.TahminiTarih.ToString();
            return View();
        }
    }
}