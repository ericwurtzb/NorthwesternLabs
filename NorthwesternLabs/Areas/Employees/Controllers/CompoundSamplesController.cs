using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NorthwesternLabs.DAL;
using NorthwesternLabs.Models;

namespace NorthwesternLabs.Areas.Employees.Controllers
{
    public class CompoundSamplesController : Controller
    {
        private NorthwesternLabsContext db = new NorthwesternLabsContext();

        // GET: Employees/CompoundSamples
        public ActionResult Index()
        {
            return View(db.CompoundSamples.ToList());
        }

        // GET: Employees/CompoundSamples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompoundSample compoundSample = db.CompoundSamples.Find(id);
            if (compoundSample == null)
            {
                return HttpNotFound();
            }
            return View(compoundSample);
        }

        // GET: Employees/CompoundSamples/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/CompoundSamples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompoundLT,CompoundSequenceCode,AssayID,QuantityMg,Appearance")] CompoundSample compoundSample)
        {
            if (ModelState.IsValid)
            {
                db.CompoundSamples.Add(compoundSample);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compoundSample);
        }

        // GET: Employees/CompoundSamples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompoundSample compoundSample = db.CompoundSamples.Find(id);
            if (compoundSample == null)
            {
                return HttpNotFound();
            }
            return View(compoundSample);
        }

        // POST: Employees/CompoundSamples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompoundLT,CompoundSequenceCode,AssayID,QuantityMg,Appearance")] CompoundSample compoundSample)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compoundSample).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compoundSample);
        }

        // GET: Employees/CompoundSamples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompoundSample compoundSample = db.CompoundSamples.Find(id);
            if (compoundSample == null)
            {
                return HttpNotFound();
            }
            return View(compoundSample);
        }

        // POST: Employees/CompoundSamples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompoundSample compoundSample = db.CompoundSamples.Find(id);
            db.CompoundSamples.Remove(compoundSample);
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
