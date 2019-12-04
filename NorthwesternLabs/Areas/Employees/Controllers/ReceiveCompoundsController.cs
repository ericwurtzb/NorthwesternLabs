using NorthwesternLabs.DAL;
using NorthwesternLabs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NorthwesternLabs.Areas.Employees.Controllers
{
    public class ReceiveCompoundsController : Controller
    
    {
        private NorthwesternLabsContext db = new NorthwesternLabsContext();
        public static int newCurrentWorkOrder;

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
            newCurrentWorkOrder = id;
            ViewBag.WorkOrder = newCurrentWorkOrder;
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
            ViewBag.WorkOrder = newCurrentWorkOrder;
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
                compound.WorkOrderID = newCurrentWorkOrder;
                db.Compounds.Add(compound);
                db.SaveChanges();
                int passWorkOrder = compound.WorkOrderID;
                return RedirectToAction("CompoundList", new { id = passWorkOrder });
            }

            return View(compound);
        }

        //--------------------------------------------------------------------
        // GET: Employees/Compounds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compound compound = db.Compounds.Find(id);
            if (compound == null)
            {
                return HttpNotFound();
            }
            return View(compound);
        }

        // POST: Employees/Compounds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompoundLT,WorkOrderID,CompoundName,DateArrived,ReceivedBy,Weight,Mass,MTD")] Compound compound)
        {
            if (ModelState.IsValid)
            {
                compound.WorkOrderID = newCurrentWorkOrder;
                db.Entry(compound).State = EntityState.Modified;
                db.SaveChanges();
                int passWorkOrder = compound.WorkOrderID;
                return RedirectToAction("CompoundList", new { id = passWorkOrder });
            }
            return View(compound);
        }

        // GET: Employees/Compounds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compound compound = db.Compounds.Find(id);
            if (compound == null)
            {
                return HttpNotFound();
            }
            return View(compound);
        }

        // POST: Employees/Compounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compound compound = db.Compounds.Find(id);
            db.Compounds.Remove(compound);
            db.SaveChanges();
            compound.WorkOrderID = newCurrentWorkOrder;
            int passWorkOrder = compound.WorkOrderID;
            return RedirectToAction("CompoundList", new { id = passWorkOrder });
        }

        // GET: Employees/Compounds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compound compound = db.Compounds.Find(id);
            if (compound == null)
            {
                return HttpNotFound();
            }
            return View(compound);
        }

    }
}