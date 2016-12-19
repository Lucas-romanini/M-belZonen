using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using System.Web.Mvc;
using MZrepo;

namespace MøbelZonen
{
    public class HomeController : Controller
    {
        IndholdFac ihf = new IndholdFac();
        KontaktFac KonF = new KontaktFac();
        BrugerFac bf = new BrugerFac();
        // GET: Home
        public ActionResult Index()
        {
            return View(ihf.Get(1));
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string adgangskode)
        {
            Bruger bruger = bf.Login(email.Trim(), Crypto.Hash(adgangskode.Trim()));

            if(bruger.ID > 0)
            {
                FormsAuthentication.SetAuthCookie(bruger.ID.ToString(), false);
                Response.Redirect("/Admin/ADefault/Index/");
            }

            return Redirect("/Home/Login/");
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }

        public ActionResult GlemtAdgangskode()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GlemtAdgangskode(string email)
        {
            if (bf.UserExist(email))
            {
                Uploader uploader = new Uploader();
                string nyAdgangskode = uploader.GenRnd(8);

                bf.UpdateAdgangskode(email, Crypto.Hash(nyAdgangskode));

                MailFac mf = new MailFac("smtp.gmail.com", "webitgrenaa@gmail.com", "webitgrenaa@gmail.com","Fedeaba2000",587);

                mf.Send("Ny adgangskode", nyAdgangskode, email);

                ViewBag.MSG = "Du vil om lidt modtage en email med en ny adgangskode!";
            }
            else
            {
                ViewBag.MSG = "Brugeren findes ikke i databasen";
            }
            return View();
        }

        public ActionResult Kontakt()
        {
            return View(KonF.Get(1));
        }
    }


}