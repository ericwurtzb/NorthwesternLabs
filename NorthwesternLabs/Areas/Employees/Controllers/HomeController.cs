using NorthwesternLabs.DAL;
using NorthwesternLabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NorthwesternLabs.Areas.Employees.Controllers
{

    public class HomeController : Controller
    {
        private NorthwesternLabsContext db = new NorthwesternLabsContext();
        // GET: Employees/Home
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String username = form["Username"].ToString();
            String password = form["Password"].ToString();

            var currentUser =
                db.Database.SqlQuery<User>(
            "Select * " +
            "FROM [User] " +
            "WHERE Username = '" + username + "' AND " +
            "Password = '" + password + "'");

            if (currentUser.Count() > 0)
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe);

                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View();
            }
        }

        // GET: Employees/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Password,CustomerID,EmployeeID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

    }
}