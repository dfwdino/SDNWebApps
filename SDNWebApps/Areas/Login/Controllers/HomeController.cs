﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using SDNWebApps.Views;

namespace SDNWebApps.Areas.Login.Controllers
{
    public class HomeController : Controller
    {
        private SDNAppsEntities db = new SDNAppsEntities();


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Person person)
        {
            Person loginPerson = db.People.First(m => m.Username == person.Username);

            bool val = EncryptionUtilities.IsPasswordValid(person.Password, loginPerson.Password);

            if (val)
            {
                //HttpCookieCollection SDNWebApps = Request.Cookies;

                HttpCookie myCookie = new HttpCookie("LoggedIn",person.Username);
                HttpCookie idCookie = new HttpCookie("SDNID", loginPerson.ID.ToString());

                myCookie.Expires = DateTime.Now.AddDays(1);

                Response.Cookies.Add(myCookie);

                idCookie.Expires = DateTime.Now.AddDays(1);

                Response.Cookies.Add(idCookie);


                return RedirectToAction("Index", "DoneThings", new { area = "Baby" });
            }
            else
            {
               
                return View();
            }


            return View();
        }

        // GET: Login/LogIn
        public ActionResult Index()
        {
            return View(db.People.ToList());
        }

        public ActionResult LogOut()
        {
            //HttpCookieCollection SDNWebApps = Request.Cookies;
            HttpCookie myCookie = new HttpCookie("LoggedIn");
            myCookie.Expires = DateTime.Now.AddDays(-1d);
           
            Response.Cookies.Add(myCookie);


            HttpCookie idCookie = new HttpCookie("SDNID");
            idCookie.Expires = DateTime.Now.AddDays(-1d);

            Response.Cookies.Add(idCookie);

            return RedirectToAction("Index","DoneThings",new {area = "Baby"});
        }

        // GET: Login/LogIn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Login/LogIn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/LogIn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PersonName,Username,Password,SaltHash")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Login/LogIn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Login/LogIn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PersonName,Username,Password,SaltHash")] Person person)
        {
            if (ModelState.IsValid)
            {
                //if(person.SaltHash.Length.Equals(0))
                //    person.SaltHash = GenerateSaltValue();

                person.Password = EncryptionUtilities.CreatePasswordSalt(person.Password);

                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Login/LogIn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Login/LogIn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
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


    }

    public static class EncryptionUtilities
    {
        private const int SALT_SIZE = 8;
        private const int NUM_ITERATIONS = 1000;

        private static readonly RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        /// <summary>
        /// Creates a signature for a password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>the "salt:hash" for the password.</returns>
        public static string CreatePasswordSalt(string password)
        {
            byte[] buf = new byte[SALT_SIZE];
            rng.GetBytes(buf);
            string salt = Convert.ToBase64String(buf);

            Rfc2898DeriveBytes deriver2898 = new Rfc2898DeriveBytes(password.Trim(), buf, NUM_ITERATIONS);
            string hash = Convert.ToBase64String(deriver2898.GetBytes(16));
            return salt + ':' + hash;
        }

        /// <summary>
        /// Validate if a password will generate the passed in salt:hash.
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <param name="saltHash">The "salt:hash" this password should generate.</param>
        /// <returns>true if we have a match.</returns>
        public static bool IsPasswordValid(string password, string saltHash)
        {
            string[] parts = saltHash.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
                return false;
            byte[] buf = Convert.FromBase64String(parts[0]);
            Rfc2898DeriveBytes deriver2898 = new Rfc2898DeriveBytes(password.Trim(), buf, NUM_ITERATIONS);
            string computedHash = Convert.ToBase64String(deriver2898.GetBytes(16));
            return parts[1].Equals(computedHash);
        }
    }
}