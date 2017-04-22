using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TimeCare.Models;

namespace TimeCare.Controllers
{
    public class WorkSchedulesController : Controller
    {
        private TimeCareContext db = new TimeCareContext();

        // GET: WorkSchedules
        public ActionResult allpassIndex()
        {
            var workpass = db.WorkSchedules.Select(e => e).ToList();
            var socialpass = db.SocialSchedules.Select(e => e).ToList();
            var allpass = db.WorkSchedules.Select(p => new { p.PassName, p.StartTime ,p.Duration, p.Description })
                 .Union(db.SocialSchedules.Select(q => new { q.PassName, q.StartTime, q.Duration, q.Description }))
                 .Union(db.TrainSchedules.Select(r => new { r.PassName, r.StartTime, r.Duration, r.Description })).ToList().Select(e => new Pass
                 {
                PassName = e.PassName,
                StartTime = e.StartTime,
                Duration = e.Duration,
                Description = e.Description
                }).ToList().OrderBy(x => x.StartTime);
            //var allpass = db.WorkSchedules.Select(e => e).ToList().Select(e => new Pass
           
            return View(allpass.ToList());
           
        }

        public ActionResult Index()
        {
            return View(db.WorkSchedules.ToList());
        }

        // GET: WorkSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkSchedule workSchedule = db.WorkSchedules.Find(id);
            if (workSchedule == null)
            {
                return HttpNotFound();
            }
            return View(workSchedule);
        }

        // GET: WorkSchedules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkScheduleId,PassName,StartTime,Duration,Description,ReminderDuration")] WorkSchedule workSchedule)
        {
            if (ModelState.IsValid)
            {
                workSchedule.WorkScheduleTypeId = 1;
                db.WorkSchedules.Add(workSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workSchedule);
        }

        // GET: WorkSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkSchedule workSchedule = db.WorkSchedules.Find(id);
            if (workSchedule == null)
            {
                return HttpNotFound();
            }
            return View(workSchedule);
        }

        // POST: WorkSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkScheduleId,PassName,StartTime,Duration,Description,ReminderDuration")] WorkSchedule workSchedule)
        {
            if (ModelState.IsValid)
            {
                workSchedule.WorkScheduleTypeId = 1;
                db.Entry(workSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workSchedule);
        }

        // GET: WorkSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkSchedule workSchedule = db.WorkSchedules.Find(id);
            if (workSchedule == null)
            {
                return HttpNotFound();
            }
            return View(workSchedule);
        }

        // POST: WorkSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkSchedule workSchedule = db.WorkSchedules.Find(id);
            db.WorkSchedules.Remove(workSchedule);
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
