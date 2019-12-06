//Eric Wurtzbacher, Aaron Hayden, Katie Bankhead, Ryan Ham 2-16
//Last edited: 12/5

//This is the main "Home Controller" for the website - it has the 
// login page, which directs to two different landing pages (customer, employee)


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
        //returns employee landing page
        [Authorize]
        public ActionResult Index()
        {
            string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
            string username = ticket.Name; //Username is here!

            //this is our role redirection system - since the base homepage is set to  Employees/Home/Index, we don't want customers getting in here. So we query with the username from the authentication cookie and get the "Role" from the query, and redirect accordingly
            IEnumerable<User> currentUser =
                 db.Database.SqlQuery<User>(
             "Select EmployeeID as IDNum, Username, Password, 'Employee' as Role " +
             "FROM [Employee_Users] " +
             "WHERE Username = '" + username + "'" +
            "UNION ALL " +
            "Select *, 'Customer' " +
             "FROM [Customer_Users] " +
             "WHERE Username = '" + username + "'"
            );

            string CurrentCustRole = currentUser.First().Role;
            
            if (CurrentCustRole == "Employee")
            {
                return View();
            }
            else if (CurrentCustRole == "Customer")
            {
                return View("~/Areas/Customers/Views/CustHome/Index.cshtml");
            }

            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        //BASE LOGIN PAGE - searches both employee_users and customer_users - redirects to respective landing page 
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