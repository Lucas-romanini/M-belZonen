using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MøbelZonen.Areas.Admin.Controllers
{
    public class ADefaultController : Controller
    {
        // GET: Admin/ADefault
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}