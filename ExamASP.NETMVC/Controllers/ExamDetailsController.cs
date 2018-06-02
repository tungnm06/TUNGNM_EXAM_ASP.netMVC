using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamASP.NETMVC.Models;

namespace ExamASP.NETMVC.Controllers
{
    public class ExamDetailsController : Controller
    {
        private ExamContext db = new ExamContext();

        // GET: ExamDetails
        public ActionResult Index()
        {
            var examDetails = db.ExamDetails.Include(e => e.ClassRoom1).Include(e => e.ExamSubject1).Include(e => e.Faculty);
            return View(examDetails.ToList());
        }

        // GET: ExamDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamDetail examDetail = db.ExamDetails.Find(id);
            if (examDetail == null)
            {
                return HttpNotFound();
            }
            return View(examDetail);
        }

        // GET: ExamDetails/Create
        public ActionResult Create()
        {
            ViewBag.ClassRoom = new SelectList(db.ClassRooms, "ClassRoom1", "NameTeacher");
            ViewBag.ExamSubject = new SelectList(db.ExamSubjects, "ExamSubject1", "Id");
            ViewBag.FacultyName = new SelectList(db.Faculties, "FacultyName", "FacultyName");
            return View();
        }

        // POST: ExamDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamId,StartTime,ExamDate,ExamDuration,ExamSubject,ClassRoom,FacultyName,Status")] ExamDetail examDetail)
        {
            if (ModelState.IsValid)
            {
                DateTime time = Convert.ToDateTime(examDetail.ExamDate);
                if (time.Millisecond < DateTime.Now.Millisecond)
                {
                    examDetail.Status = "done";
                }
                if(time.Millisecond == DateTime.Now.Millisecond)
                {
                    examDetail.Status = "ON going";

                }
                if (time.Millisecond > DateTime.Now.Millisecond)
                {
                    examDetail.Status = "up coming";

                }
                db.ExamDetails.Add(examDetail);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassRoom = new SelectList(db.ClassRooms, "ClassRoom1", "NameTeacher", examDetail.ClassRoom);
            ViewBag.ExamSubject = new SelectList(db.ExamSubjects, "ExamSubject1", "Id", examDetail.ExamSubject);
            ViewBag.FacultyName = new SelectList(db.Faculties, "FacultyName", "FacultyName", examDetail.FacultyName);
            return View(examDetail);
        }

        // GET: ExamDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamDetail examDetail = db.ExamDetails.Find(id);
            if (examDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassRoom = new SelectList(db.ClassRooms, "ClassRoom1", "NameTeacher", examDetail.ClassRoom);
            ViewBag.ExamSubject = new SelectList(db.ExamSubjects, "ExamSubject1", "Id", examDetail.ExamSubject);
            ViewBag.FacultyName = new SelectList(db.Faculties, "FacultyName", "FacultyName", examDetail.FacultyName);
            return View(examDetail);
        }

        // POST: ExamDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamId,StartTime,ExamDate,ExamDuration,ExamSubject,ClassRoom,FacultyName")] ExamDetail examDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassRoom = new SelectList(db.ClassRooms, "ClassRoom1", "NameTeacher", examDetail.ClassRoom);
            ViewBag.ExamSubject = new SelectList(db.ExamSubjects, "ExamSubject1", "Id", examDetail.ExamSubject);
            ViewBag.FacultyName = new SelectList(db.Faculties, "FacultyName", "FacultyName", examDetail.FacultyName);
            return View(examDetail);
        }

        // GET: ExamDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamDetail examDetail = db.ExamDetails.Find(id);
            if (examDetail == null)
            {
                return HttpNotFound();
            }
            return View(examDetail);
        }

        // POST: ExamDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamDetail examDetail = db.ExamDetails.Find(id);
            db.ExamDetails.Remove(examDetail);
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
