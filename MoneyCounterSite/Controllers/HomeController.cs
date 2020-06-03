using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyCounterSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.urlSrc1 = Url.Content("~/Content/img/piechart_78388.png");
            ViewBag.urlSrc2 = Url.Content("~/Content/img/safebox_78389.png");
            ViewBag.urlSrc3 = Url.Content("~/Content/img/profits_78367.png");
            return View();
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