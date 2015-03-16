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
        BL.Books buissnessLogicBook = new BL.Books();

        public ActionResult Index()
        {
            ViewBag.booklist = buissnessLogicBook.getAll();

            return View();
        }

        public ActionResult Searchpage()
        {
            return View();
        }

        public ActionResult Browsepage()
        {
            ViewBag.booklist = buissnessLogicBook.getAll();
            return View();
        }

        public ActionResult searchFunction()
        {
            ViewBag.searchResult = buissnessLogicBook.search(Request.QueryString.Get("search"));
            return View("index");
        }
    }
}
