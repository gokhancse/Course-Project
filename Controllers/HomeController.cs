using Gokhan_Selale_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Gokhan_Selale_Project.Controllers
{
    public class HomeController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
           return View();
        }
        public ActionResult KursListele()
        {
            List<Kurslar> kursListe = db.Kurslars.OrderByDescending(m => m.KursID).ToList();
            return View(kursListe);
        }
        public ActionResult KursEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KursEkle(Kurslar kurs)
        {
            //Kurslar ekle = new Kurslar();
            //ekle.KursAd = kurs.KursAd;
            //ekle.Baslik = kurs.Baslik;
            //db.Kurslars.Add(ekle);
            //db.SaveChanges();
            //return Redirect("/Home/KursListele");

            if (!ModelState.IsValid)
                return View(kurs);
            else
            { 
            Kurslar ekle = new Kurslar();
            ekle.KursAd = kurs.KursAd;
            ekle.Baslik = kurs.Baslik;
            db.Kurslars.Add(ekle);
            db.SaveChanges();
            }
            return RedirectToAction("Index", "Home"); //this will redirect the user to home. You can return a view or redirect user somewhere else.
        }
        public ActionResult KursSil(int id)
        {
            var silinecekkurs = db.Kurslars.Find(id);
            db.Kurslars.Remove(silinecekkurs);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult KursGuncelle(int id)
        {
            var duzenle = db.Kurslars.Where(s => s.KursID == id).FirstOrDefault();
            return View(duzenle);
        }
        [HttpPost]
        public ActionResult KursGuncelle(Kurslar kurs)
        {
            if (ModelState.IsValid)
            {
                var kayit = db.Kurslars.Where(x => x.KursID == kurs.KursID).SingleOrDefault();
                kayit.KursAd = kurs.KursAd;
                kayit.Baslik = kurs.Baslik;
                db.Kurslars.AddOrUpdate(kayit);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Kayıt Edilirken Hata Oluştu...");
                return View();
            }

        }
        public ActionResult KursaKaydet(int? id)
        {
            string str = "";
            var kursismi = db.Kurslars.Where(x => x.KursID == id).Select(x => x).ToList();
            foreach (var item in kursismi)
            {
                str = item.KursAd;
            }

            var tarihler = db.KursKayitlars.Select(x => x.Tarih).Distinct().ToList();
            ViewBag.Tarihler = new SelectList(tarihler);
            ViewBag.Kursismi = str;
            return View();
        }
        [HttpPost]
        public ActionResult KursaKaydet(KursKayitlar kayitlar)
        {
            if (!ModelState.IsValid)
                return View();
            else
            {
                KursKayitlar ekle = new KursKayitlar();
                ekle.GelenKisiSayisi = kayitlar.GelenKisiSayisi;
                ekle.Tarih = kayitlar.Tarih;
                ekle.KursId = kayitlar.ID;
                db.KursKayitlars.Add(ekle);
                ViewBag.Successfully = "Başarıyla Eklendi!";
                db.SaveChanges();
            }
            return View();
        }
        public ActionResult KursKayitlari()
        {
            var kayitlar = db.KursKayitlars.Select(x => x).ToList();
            return View(kayitlar);
        }
        public ActionResult KursKayitEkle()
        {
            List<SelectListItem> kurslar = new List <SelectListItem>();

            foreach (var item in db.Kurslars.Select(x=>x).Distinct().ToList())
            { 
                kurslar.Add(new SelectListItem { Text = item.KursAd, Value = item.KursAd});
            }

            ViewBag.KursKayitlar = kurslar;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KursKayitEkle(KursKayitlar kurskayit,FormCollection form)
        {
            string str = form["KursKayitlar"].ToString();
            int id=0;

            var kursidbul = db.Kurslars.Where(x=>x.KursAd==str).Select(x=>x).ToList();
            foreach (var item in kursidbul)
            {
                id = item.KursID;
            }
            if (!ModelState.IsValid)
                return View(kurskayit);
           
            KursKayitlar ekle = new KursKayitlar();
            ekle.GelenKisiSayisi = kurskayit.GelenKisiSayisi;
            ekle.KursId = id;
            ekle.Tarih = kurskayit.Tarih;
               
                db.KursKayitlars.Add(ekle);
                db.SaveChanges();
            
            return RedirectToAction("KursKayitlari", "Home"); //this will redirect the user to home. You can return a view or redirect user somewhere else.
        }
        public ActionResult KursKayitGuncelle(int id)
        {
            List<SelectListItem> kurslar = new List<SelectListItem>();

            foreach (var item in db.Kurslars.Select(x => x).Distinct().ToList())
            {
                kurslar.Add(new SelectListItem { Text = item.KursAd, Value = item.KursAd });
            }

            ViewBag.KursKayitlar = kurslar;

            var duzenle = db.KursKayitlars.Where(s => s.ID == id).FirstOrDefault();
            return View(duzenle);
        }
        [HttpPost]
        public ActionResult KursKayitGuncelle(KursKayitlar kurskayit, FormCollection form)
        {
            string str = form["KursKayitlar"].ToString();
            int id = 0;

            var kursidbul = db.Kurslars.Where(x => x.KursAd == str).Select(x => x).ToList();
            foreach (var item in kursidbul)
            {
                id = item.KursID;
            }

            if (ModelState.IsValid)
            {
                var kayit = db.KursKayitlars.Where(x => x.ID == kurskayit.ID).SingleOrDefault();
                kayit.GelenKisiSayisi = kurskayit.GelenKisiSayisi;
                kayit.Tarih = kurskayit.Tarih;
                kayit.KursId = id;
                db.KursKayitlars.AddOrUpdate(kayit);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Kayıt Edilirken Hata Oluştu...");
                return View();
            }

        }
        public ActionResult KursKayitSil(int id)
        {
            var silinecekkurs = db.KursKayitlars.Find(id);
            db.KursKayitlars.Remove(silinecekkurs);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Chart(int? id)
        {
            string str = "";
            int kursid = 0;
            var kursismi = db.Kurslars.Where(x => x.KursID == id).Select(x => x).ToList();
            foreach (var item in kursismi)
            {
                str = item.KursAd;
                kursid = item.KursID;
            }

            List<SelectListItem> kurslar = new List<SelectListItem>();
            foreach (var item in db.KursKayitlars.Where(x => x.KursId == id).Select(x => x).ToList())
            {
                kurslar.Add(new SelectListItem { Text=item.Tarih.ToString(), Value = item.Tarih.ToString() });
            }
            ViewBag.Kurslar = kurslar;
            ViewBag.KursIsmi = str;
            ViewBag.KursId = kursid;
            //var kayit = db.KursKayitlars.Where(x => x.KursId == id).Select(x=>x.Tarih).ToList();
            ////var kursidbul = db.Kurslars.Where(x => x.KursAd == str).Select(x => x).ToList();
            //ViewBag.KursKayitlar = kayit;
            return View();
        }
        [HttpPost]
        public ActionResult Chart(FormCollection form)
        {
            string str = form["Tarihler"];
            DateTime date = Convert.ToDateTime(str);
            string value = form.Get("name");
            int kisisayisi = 0;
            int intvalue = Convert.ToInt32(value);
            var kisiler = db.KursKayitlars.Where(x => x.Tarih == date).Where(x => x.KursId == intvalue).Select(x=>new { x.GelenKisiSayisi }).ToList();
            foreach (var item in kisiler)
            {
                kisisayisi = item.GelenKisiSayisi;
            }

            var myChart = new Chart(width: 400, height: 300, theme: ChartTheme.Green)
            .AddTitle("Katılanlar")
            .AddSeries(
             name: "Kursa Katılanlar",
             xValue: new[] { str },
             yValues: new[] { kisisayisi })
              .Write();
            return File(myChart.ToWebImage().GetBytes(), "image/jpeg");


            //  .GetBytes("png");


            //return File(myChart, "images/jpeg");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}