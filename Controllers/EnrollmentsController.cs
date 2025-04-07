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
    public class EnrollmentsController : Controller
    {
        private SchoolDB2Entities db = new SchoolDB2Entities();

        // GET: Enrollments
        public ActionResult Index()
        {
            var tblEnrollments = db.tblEnrollments.Include(t => t.tblCours).Include(t => t.tblStudent);
            return View(tblEnrollments.ToList());
        }

        // GET: Enrollments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEnrollment tblEnrollment = db.tblEnrollments.Find(id);
            if (tblEnrollment == null)
            {
                return HttpNotFound();
            }
            return View(tblEnrollment);
        }

        // GET: Enrollments/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.tblCourses, "CourseID", "Title");
            ViewBag.StudentID = new SelectList(db.tblStudents, "StudentID", "FirstName");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollmentID,CourseID,StudentID,Grade")] tblEnrollment tblEnrollment)
        {
            if (ModelState.IsValid)
            {
                db.tblEnrollments.Add(tblEnrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.tblCourses, "CourseID", "Title", tblEnrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.tblStudents, "StudentID", "FirstName", tblEnrollment.StudentID);
            return View(tblEnrollment);
        }

        // GET: Enrollments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEnrollment tblEnrollment = db.tblEnrollments.Find(id);
            if (tblEnrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.tblCourses, "CourseID", "Title", tblEnrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.tblStudents, "StudentID", "FirstName", tblEnrollment.StudentID);
            return View(tblEnrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollmentID,CourseID,StudentID,Grade")] tblEnrollment tblEnrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEnrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.tblCourses, "CourseID", "Title", tblEnrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.tblStudents, "StudentID", "FirstName", tblEnrollment.StudentID);
            return View(tblEnrollment);
        }

        // GET: Enrollments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEnrollment tblEnrollment = db.tblEnrollments.Find(id);
            if (tblEnrollment == null)
            {
                return HttpNotFound();
            }
            return View(tblEnrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEnrollment tblEnrollment = db.tblEnrollments.Find(id);
            db.tblEnrollments.Remove(tblEnrollment);
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
