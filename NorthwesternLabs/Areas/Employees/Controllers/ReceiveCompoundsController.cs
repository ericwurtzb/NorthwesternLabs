using NorthwesternLabs.DAL;
using NorthwesternLabs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwesternLabs.Areas.Employees.Controllers
{
    public class ReceiveCompoundsController : Controller
    {
        private NorthwesternLabsContext db = new NorthwesternLabsContext();

        // GET: Employees/WorkOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/WorkOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkOrderID,CustomerID,InvoiceID,DueDate,Status,ConfirmationSent,ConfirmationDate,Comments,EmployeeID")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                db.WorkOrder.Add(workOrder);
                db.SaveChanges();
                int passWorkOrder = workOrder.WorkOrderID;
                return RedirectToAction("CompoundList", new { id = passWorkOrder });
            }

            return View(workOrder);
        }

        // GET: Employees/Compounds/Create
        public ActionResult CompoundList(int id)
        {
            var workOrderID = id;

            var currentWorkOrder =
                db.Database.SqlQuery<Compound>(
            "Select * " +
            "FROM Compound " +
            "WHERE WorkOrderID = '" + id + "'");

            return View(currentWorkOrder);
        }

        // POST: Employees/Compounds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompoundList([Bind(Include = "CompoundLT,WorkOrderID,CompoundName,DateArrived,ReceivedBy,Weight,Mass,MTD")] Compound compound)
        {
            if (ModelState.IsValid)
            {
                db.Compounds.Add(compound);
                db.SaveChanges();
                return RedirectToAction("CompoundList");
            }

            return View(compound);
        }

        // GET: Employees/Compounds/Create
        public ActionResult CompoundCreate()
        {
            return View();
        }

        // POST: Employees/Compounds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompoundCreate([Bind(Include = "CompoundLT,WorkOrderID,CompoundName,DateArrived,ReceivedBy,Weight,Mass,MTD")] Compound compound)
        {
            if (ModelState.IsValid)
            {
                db.Compounds.Add(compound);
                db.SaveChanges();
                int passWorkOrder = compound.WorkOrderID;
                return RedirectToAction("CompoundList", new { id = passWorkOrder });
            }

            return View(compound);
        }

    }
}