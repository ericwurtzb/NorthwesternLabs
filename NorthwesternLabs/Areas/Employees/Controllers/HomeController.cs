using NorthwesternLabs.DAL;
using NorthwesternLabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;

namespace NorthwesternLabs.Areas.Employees.Controllers
{

    public class HomeController : Controller
    {
        private NorthwesternLabsContext db = new NorthwesternLabsContext();
        // GET: Employees/Home
        [Authorize]
        public ActionResult Index()
        {
            string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
            string UserName = ticket.Name; //You have the UserName!
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(System.Web.Mvc.FormCollection form, bool rememberMe = false)
        {
            String username = form["Username"].ToString();
            String password = form["Password"].ToString();

            IEnumerable<User> currentUser =
                 db.Database.SqlQuery<User>(
             "Select EmployeeID as IDNum, Username, Password, 'Employee' as Role " +
             "FROM [Employee_Users] " +
             "WHERE Username = '" + username + "' AND " +
             "Password = '" + password + "' " +
            "UNION ALL " +
            "Select *, 'Customer' " +
             "FROM [Customer_Users] " +
             "WHERE Username = '" + username + "' AND " +
             "Password = '" + password + "';"
            );

            if (currentUser.Count() > 0)
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe);

                if (currentUser.First().Role == "Customer")
                {
                    //return customer page
                    
                    return RedirectToAction("Index", "CustHome", new { area = "Customers" });
                    //return Content("employee");
                }

                if (currentUser.First().Role == "Employee")
                {

                    return RedirectToAction("Index", "Home");
                }

                return Content("not found");

            }
            else
            {
                return View();
            }
        }
       

    }
}