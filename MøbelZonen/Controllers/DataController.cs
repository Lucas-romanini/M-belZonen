﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MZrepo;

namespace MøbelZonen
{
    public class DataController : Controller
    {
        KategoriFac katF = new KategoriFac();
        KontaktFac konF = new KontaktFac();
        
        // GET: Data
        [ChildActionOnly]
        public ActionResult Menu()
        {
            return PartialView(katF.GetAll());
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView(konF.Get(1));
        }
    }
}