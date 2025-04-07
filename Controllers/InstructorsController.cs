using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolManagementApp;

namespace SchoolManagementApp.Controllers
{
    public class InstructorsController : Controller
    {
        private SchoolDB2Entities db = new SchoolDB2Entities();

        // GET: Instructors
        public ActionResult Index()
        {
            return View(db.tblInstructors.ToList());
        }

        // GET: Instructors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInstructor tblInstructor = db.tblInstructors.Find(id);
            if (tblInstructor == null)
            {
                return HttpNotFound();
            }
            return View(tblInstructor);
        }

        // GET: Instructors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instructors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstructorID,FirstName,LastName,HireDate")] tblInstructor tblInstructor)
        {
            if (ModelState.IsValid)
            {
                db.tblInstructors.Add(tblInstructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblInstructor);
        }

        // GET: Instructors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInstructor tblInstructor = db.tblInstructors.Find(id);
            if (tblInstructor == null)
            {
                return HttpNotFound();
            }
            return View(tblInstructor);
        }

        // POST: Instructors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstructorID,FirstName,LastName,HireDate")] tblInstructor tblInstructor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblInstructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblInstructor);
        }

        // GET: Instructors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInstructor tblInstructor = db.tblInstructors.Find(id);
            if (tblInstructor == null)
            {
                return HttpNotFound();
            }
            return View(tblInstructor);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblInstructor tblInstructor = db.tblInstructors.Find(id);
            db.tblInstructors.Remove(tblInstructor);
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
