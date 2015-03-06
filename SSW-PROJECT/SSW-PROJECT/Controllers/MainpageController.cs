using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSW_PROJECT.Controllers
{
    public class MainpageController : Controller
    {
        //
        // GET: /Mainpage/

        public ActionResult Index()
        {
            BL.Books buissnesslogic = new BL.Books();
            ViewBag.booklist = buissnesslogic.getAll();
            return View();
        }

        public ActionResult Searchpage()
        {
            return View();
        }

        public ActionResult Browsepage()
        {
            return View();
        }

        public ActionResult searchFunction()
        {
            return View();
        }
    }
}
