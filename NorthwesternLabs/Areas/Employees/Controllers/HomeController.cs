using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NorthwesternLabs.Models;

namespace NorthwesternLabs.Areas.Employees.Controllers
{
    public class HomeController : Controller
    {
        // GET: Employees/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}