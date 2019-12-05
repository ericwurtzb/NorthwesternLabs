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
    public class CustWorkOrdersController : Controller
    {
        private NorthwesternLabsContext db = new NorthwesternLabsContext();

        // GET: Customers/CustWorkOrders
        public ActionResult Index()
        {
            string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
            string UserName = ticket.Name; //Username is here!

            IEnumerable<Customer_User> query = db.Database.SqlQuery<Customer_User>("SELECT * FROM Customer_Users WHERE Username = '" + UserName + "'");

            int CurrentCustID = query.First().CustomerID;

            return View(db.WorkOrder.Where(a => a.CustomerID == CurrentCustID));
        }

        public ActionResult ViewTesting(int id)
        {
            return View(db.Compounds.Where(a => a.WorkOrderID == id));
        }

        public ActionResult ViewInvoice(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            return View(invoice);
        }

        public ActionResult ViewAssays(int id)
        {
            IEnumerable<AssayInfo> list = db.Database.SqlQuery<AssayInfo>("SELECT Compound.CompoundLT, CompoundSequenceCode, [Desc], CompletionEstimate, Datetimescheduled, ExtraTestNotes, ResultsLink " +
                                            "FROM Compound INNER JOIN CompoundSample ON CompoundSample.CompoundLT = Compound.CompoundLT " +
                                            "INNER JOIN ASSAY ON Assay.AssayID = CompoundSample.AssayID " +
                                            "WHERE Compound.CompoundLT = " + id);
     
            return View(list);
        }

        // GET: Customers/CustWorkOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrder.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // GET: Customers/CustWorkOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/CustWorkOrders/Create
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
                return RedirectToAction("Index");
            }

            return View(workOrder);
        }

        // GET: Customers/CustWorkOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrder.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // POST: Customers/CustWorkOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkOrderID,CustomerID,InvoiceID,DueDate,Status,ConfirmationSent,ConfirmationDate,Comments,EmployeeID")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workOrder);
        }

        // GET: Customers/CustWorkOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrder.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // POST: Customers/CustWorkOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkOrder workOrder = db.WorkOrder.Find(id);
            db.WorkOrder.Remove(workOrder);
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
