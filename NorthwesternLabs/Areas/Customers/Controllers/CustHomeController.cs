using NorthwesternLabs.DAL;
using NorthwesternLabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NorthwesternLabs.Areas.Customers.Controllers
{

    public class CustHomeController : Controller
    {
        private NorthwesternLabsContext db = new NorthwesternLabsContext();
        // GET: Employees/Home
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

       

        // GET: Employees/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.rn View(user);
        

    }
}