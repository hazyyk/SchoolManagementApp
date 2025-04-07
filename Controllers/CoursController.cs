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
    public class CoursController : Controller
    {
        private SchoolDB2Entities db = new SchoolDB2Entities();

        // GET: Cours
        public ActionResult Index()
        {
            var tblCourses = db.tblCourses.Include(t => t.tblDepartment);
            return View(tblCourses.ToList());
        }

        // GET: Cours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCours tblCours = db.tblCourses.Find(id);
            if (tblCours == null)
            {
                return HttpNotFound();
            }
            return View(tblCours);
        }

        // GET: Cours/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.tblDepartments, "DepartmentID", "Name");
            return View();
        }

        // POST: Cours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,Title,Credits,DepartmentID")] tblCours tblCours)
        {
            if (ModelState.IsValid)
            {
                db.tblCourses.Add(tblCours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.tblDepartments, "DepartmentID", "Name", tblCours.DepartmentID);
            return View(tblCours);
        }

        // GET: Cours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCours tblCours = db.tblCourses.Find(id);
            if (tblCours == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.tblDepartments, "DepartmentID", "Name", tblCours.DepartmentID);
            return View(tblCours);
        }

        // POST: Cours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,Title,Credits,DepartmentID")] tblCours tblCours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.tblDepartments, "DepartmentID", "Name", tblCours.DepartmentID);
            return View(tblCours);
        }

        // GET: Cours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCours tblCours = db.tblCourses.Find(id);
            if (tblCours == null)
            {
                return HttpNotFound();
            }
            return View(tblCours);
        }

        // POST: Cours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCours tblCours = db.tblCourses.Find(id);
            db.tblCourses.Remove(tblCours);
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
