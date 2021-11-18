using Social_Media_MDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace Social_Media_MDS.Controllers
{
    public class LoginController : Controller
    {
        private socialappdbEntities db = new socialappdbEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string username = form["Username"];
            string password = form["Password"];
            var user = db.users.Where(i => i.username == username && i.password == password).FirstOrDefault();
            Session["FirstName"] = user.first_name;
            Session["Username"] = user.username;
            if(user != null )
            {
                if (user.isAdmin == null || user.isAdmin == 0)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return RedirectToAction("Index", "users");
                }

            }
            return RedirectToAction("Index");
        }
    }
}