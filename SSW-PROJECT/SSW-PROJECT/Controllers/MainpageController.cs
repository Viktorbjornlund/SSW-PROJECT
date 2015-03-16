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
        //
        // GET: /Mainpage/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Searchpage()
        {
            return View();
        }

        public ActionResult Browsepage()
        {
            ViewBag.booklist = businessLogicBook.getAll();
            return View();
        }

        public ActionResult searchFunction()
        {
            ViewBag.searchResult=businessLogicBook.search(Request.QueryString.Get("search"));
            return View("Index");
        }
    }
}
