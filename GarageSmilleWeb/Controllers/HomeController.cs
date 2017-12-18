using GarageSmille_Ui.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarageSmille_Ui.Controllers
{
    [Seguranca]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}