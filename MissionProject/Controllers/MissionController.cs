using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MissionProject.Models;
using XaviersSchool.Models;

namespace MissionProject.Controllers
{
    public class MissionController : Controller
    {
        private MissionContext db = new MissionContext();

        public ActionResult Search(string SearchBox)
        {
            var missions = (from m in db.Missions
                            where
                               m.MissionName.Contains(SearchBox)
                               || m.MissionDescription.Contains(SearchBox)
                               || m.mutant.MutantName.Contains(SearchBox)
                               || m.status.StatusName.Contains(SearchBox)
                            select m).ToList();
            return View("Index", missions);
        }


        // GET: Mission
        public ActionResult Index()
        {
            var missions = db.Missions.Include(m => m.mutant).Include(m => m.status);
            return View(missions.ToList());
        }

        // GET: Mission/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mission mission = db.Missions.Find(id);
            if (mission == null)
            {
                return HttpNotFound();
            }
            return View(mission);
        }

        // GET: Mission/Create
        public ActionResult Create()
        {
            ViewBag.MutantId = new SelectList(db.Mutants, "MutantId", "MutantName");
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName");
            return View();
        }

        // POST: Mission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MissionId,MissionName,MissionDescription,AssignDate,MutantId,StatusId")] Mission mission)
        {
            if (ModelState.IsValid)
            {
                db.Missions.Add(mission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MutantId = new SelectList(db.Mutants, "MutantId", "MutantName", mission.MutantId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName", mission.StatusId);
            return View(mission);
        }

        // GET: Mission/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mission mission = db.Missions.Find(id);
            if (mission == null)
            {
                return HttpNotFound();
            }
            ViewBag.MutantId = new SelectList(db.Mutants, "MutantId", "MutantName", mission.MutantId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName", mission.StatusId);
            return View(mission);
        }

        // POST: Mission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MissionId,MissionName,MissionDescription,AssignDate,MutantId,StatusId")] Mission mission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MutantId = new SelectList(db.Mutants, "MutantId", "MutantName", mission.MutantId);
            ViewBag.StatusId = new SelectList(db.Statuses, "StatusId", "StatusName", mission.StatusId);
            return View(mission);
        }

        // GET: Mission/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mission mission = db.Missions.Find(id);
            if (mission == null)
            {
                return HttpNotFound();
            }
            return View(mission);
        }

        // POST: Mission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mission mission = db.Missions.Find(id);
            db.Missions.Remove(mission);
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
