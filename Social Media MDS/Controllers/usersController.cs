using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Social_Media_MDS.Models;

namespace Social_Media_MDS.Controllers
{
    public class usersController : Controller
    {
        private socialappdbEntities db = new socialappdbEntities();
        // GET: users
        public ActionResult Index()
        {
            var users = db.users.Include(u => u.user1);
            return View(users.ToList());
        }

        // GET: users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: users/Create
        public ActionResult Create()
        {
            ViewBag.id_partener = new SelectList(db.users, "id_user", "last_name");
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_user,register_date,last_name,first_name,username,email,sex,date_of_birth,description,job,marital_status,id_partener,password,isAdmin")] user user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                string path = HostingEnvironment.ApplicationPhysicalPath + "UsersFolder";


                try
                {
                    // Determine whether the directory exists.
                    if (Directory.Exists(path))
                    {
                        Console.WriteLine("That path exists already.");
                        DirectoryInfo di = Directory.CreateDirectory(path + "\\" + user.username);
                    }

                    // Delete the directory.
/*                    di.Delete();
                    Console.WriteLine("The directory was deleted successfully.");*/
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }
                return RedirectToAction("Index");
            }

            ViewBag.id_partener = new SelectList(db.users, "id_user", "last_name", user.id_partener);
            return View(user);
        }

        // GET: users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_partener = new SelectList(db.users, "id_user", "last_name", user.id_partener);
            return View(user);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_user,register_date,last_name,first_name,username,email,sex,date_of_birth,description,job,marital_status,id_partener,password,isAdmin")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_partener = new SelectList(db.users, "id_user", "last_name", user.id_partener);
            return View(user);
        }

        // GET: users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string path = HostingEnvironment.ApplicationPhysicalPath + "UsersFolder" + "\\" + Session["Username"];
            Directory.Delete(path);
            user user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult FirstPage()
        {
            return View("Login");
        }


    }
}
