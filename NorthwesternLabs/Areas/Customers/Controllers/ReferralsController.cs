using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NorthwesternLabs.DAL;
using NorthwesternLabs.Models;

namespace NorthwesternLabs.Areas.Customers.Controllers
{
    public class ReferralsController : Controller
    {
        private NorthwesternLabsContext db = new NorthwesternLabsContext();

        // GET: Customers/Referrals
        public ActionResult Index()
        {
            return View(db.Referrals.ToList());
        }

        // GET: Customers/Referrals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referral referral = db.Referrals.Find(id);
            if (referral == null)
            {
                return HttpNotFound();
            }
            return View(referral);
        }

        // GET: Customers/Referrals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Referrals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Email,PhoneNumber")] Referral referral)
        {
            if (ModelState.IsValid)
            {
                string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
                HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
                string UserName = ticket.Name; //Username is here!

                IEnumerable<Customer_User> query = db.Database.SqlQuery<Customer_User>("SELECT * FROM Customer_Users WHERE Username = '" + UserName + "'");

                int CurrentCustID = query.First().CustomerID;
                referral.CustomerID = CurrentCustID;
                db.Referrals.Add(referral);
                db.SaveChanges();
                return View("Thank");
            }

            return View(referral);
        }

        public ActionResult Thank()
        {
            return View();
        }

        // GET: Customers/Referrals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referral referral = db.Referrals.Find(id);
            if (referral == null)
            {
                return HttpNotFound();
            }
            return View(referral);
        }

        // POST: Customers/Referrals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Email,PhoneNumber")] Referral referral)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referral).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(referral);
        }

        // GET: Customers/Referrals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referral referral = db.Referrals.Find(id);
            if (referral == null)
            {
                return HttpNotFound();
            }
            return View(referral);
        }

        // POST: Customers/Referrals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Referral referral = db.Referrals.Find(id);
            db.Referrals.Remove(referral);
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
}
