using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSW_PROJECT.Controllers
{
    public class MainpageController : Controller
    {
        BL.Book businessLogicBook = new BL.Book();

        public ActionResult StartPage()
        {
            return View();
        }
        public ActionResult SearchPage()
        {
            return View();
        }

        public ActionResult BrowsePage()
        {
            ViewBag.booklist = businessLogicBook.getAll();
            return View();
        }

        public ActionResult searchFunction()
        {
            ViewBag.searchResult=businessLogicBook.search(Request.QueryString.Get("search"));
            return View("SearchPage");
        }
    }
}
