using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MZrepo;
using System.Web.Helpers;

namespace MøbelZonen.Areas.Admin.Controllers
{
    public class BrugerController : Controller
    {
        BrugerFac bf = new BrugerFac();
        // GET: Admin/Bruger
        public ActionResult Opret()
        {
            return View();
        }

        /// <summary>
        /// bruges til at lave en bruger
        /// </summary>
        /// <param name="bruger">her indsætes data til databasen, så en bruger kan oprettes</param>
        /// <param name="gentag">Server side validering af adgangskode</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Opret(Bruger bruger, string gentag)
        {
            if (!bf.UserExist(bruger.Email))
            {
                if(bruger.Adgangskode == gentag)
                {
                    bruger.Transfer = "Default";

                    if(ModelState.IsValid)
                    {
                        bruger.Adgangskode = Crypto.Hash(bruger.Adgangskode);
                        bf.Insert(bruger);

                        ViewBag.MSG = "Brugeren er nu oprettet!";
                    }
                }
                else
                {
                    ViewBag.MSG = "De to adgangskoder skal være ens!";
                }
            }
            else
            {
                ViewBag.MSG = "Brugerem findes allerede, brug en anden email!";
            }
            return View();
        }

        public ActionResult EditBruger()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditBruger(Bruger bruger,string NyAdgangskode, string gentaf)
        {
            if(bruger.Adgangskode == bruger.Adgangskode)
            {
                if(NyAdgangskode != bruger.Adgangskode)
                {



                }
                else
                {
                    ViewBag.NyAdgangskode = "Den nye adgangs kode må ikke være den samme som den gamle adgangskode!";
                }
            }
            else
            {
                ViewBag.GammelAdgangskode = "Din adganskode skal matche din gamle adgangskode!";
            }

            return View();
        }

    }
}