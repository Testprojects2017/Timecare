using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeCare.Models;

namespace TimeCare.Controllers
{
    public class TrainSchedulesController : Controller
    {
        private TimeCareContext db = new TimeCareContext();

        // GET: TrainSchedules
        public ActionResult Index()
        {
            return View(db.TrainSchedules.ToList());
        }

        // GET: TrainSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainSchedule trainSchedule = db.TrainSchedules.Find(id);
            if (trainSchedule == null)
            {
                return HttpNotFound();
            }
            return View(trainSchedule);
        }

        // GET: TrainSchedules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainScheduleId,PassName,StartTime,Duration,Description,ReminderDuration,ChangeoverTimeBefore,ChangeoverTimeAfter,TrainType")] TrainSchedule trainSchedule)
        {
            if (ModelState.IsValid)
            {
                trainSchedule.TrainScheduleTypeId = 3;
                db.TrainSchedules.Add(trainSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainSchedule);
        }

        // GET: TrainSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainSchedule trainSchedule = db.TrainSchedules.Find(id);
            if (trainSchedule == null)
            {
                return HttpNotFound();
            }
            return View(trainSchedule);
        }

        // POST: TrainSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainScheduleId,PassName,StartTime,Duration,Description,ReminderDuration,,ChangeoverTimeBefore,ChangeoverTimeAfter,TrainType")] TrainSchedule trainSchedule)
        {
            if (ModelState.IsValid)
            {
                trainSchedule.TrainScheduleTypeId = 3;
                db.Entry(trainSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainSchedule);
        }

        // GET: TrainSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainSchedule trainSchedule = db.TrainSchedules.Find(id);
            if (trainSchedule == null)
            {
                return HttpNotFound();
            }
            return View(trainSchedule);
        }

        // POST: TrainSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainSchedule trainSchedule = db.TrainSchedules.Find(id);
            db.TrainSchedules.Remove(trainSchedule);
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
