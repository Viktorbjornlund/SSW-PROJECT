using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSW_PROJECT.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(FormCollection collection)
        {
            string userName = collection["username"];
            string password = collection["password"];
            BL.User businesslogic = new BL.User();
            BL.User user = businesslogic.getUser(userName);

            if (user.Password == password)
            {
                Session["User"] = user;
                ViewBag.succed = "You are now logged in.";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.succed = "Failed to log in, username/password is invalid.";
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string userName = collection["username"];
                string password = collection["password"];
                string firstName = collection["firstname"];
                string lastName = collection["lastname"];
                string email = collection["email"];

                BL.User user = new BL.User();
                user.Password = password;
                user.UserName = userName;
                user.FirstName = firstName;
                user.LastName = lastName;
                user.Email = email;
                Session["User"] = user;
                ViewBag.succed = "You just created an account and you are now logged in.";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.succed = "Failed to create account.";
                return View();
            }
        }

        public ActionResult Remove(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Remove(int id, FormCollection collection)
        {
            try
            {
                string userName = collection["username"];
                string password = collection["password"];

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                string userName = collection["username"];
                string password = collection["password"];
                string firstName = collection["firstname"];
                string lastName = collection["lastname"];
                string email = collection["email"];

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
