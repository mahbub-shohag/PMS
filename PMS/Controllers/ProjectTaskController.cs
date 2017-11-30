using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PMS.Models;
using PMS;

namespace PMS.Controllers
{
    public class ProjectTaskController : Controller
    {
        private PMSDbContext db = new PMSDbContext();

        // GET: /ProjectTask/
        public ActionResult Index()
        {
            var projecttasks = db.ProjectTasks.Include(p => p.project).Include(p => p.user);
            return View(projecttasks.ToList());
        }

        // GET: /ProjectTask/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTask projecttask = db.ProjectTasks.Find(id);
            if (projecttask == null)
            {
                return HttpNotFound();
            }
            return View(projecttask);
        }

        // GET: /ProjectTask/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: /ProjectTask/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Description,DueDate,Priority,ProjectId,UserId")] ProjectTask projecttask)
        {
            if (ModelState.IsValid)
            {
                db.ProjectTasks.Add(projecttask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", projecttask.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", projecttask.UserId);
            return View(projecttask);
        }

        // GET: /ProjectTask/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTask projecttask = db.ProjectTasks.Find(id);
            if (projecttask == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", projecttask.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", projecttask.UserId);
            return View(projecttask);
        }

        // POST: /ProjectTask/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Description,DueDate,Priority,ProjectId,UserId")] ProjectTask projecttask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projecttask).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", projecttask.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", projecttask.UserId);
            return View(projecttask);
        }

        // GET: /ProjectTask/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTask projecttask = db.ProjectTasks.Find(id);
            if (projecttask == null)
            {
                return HttpNotFound();
            }
            return View(projecttask);
        }

        // POST: /ProjectTask/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectTask projecttask = db.ProjectTasks.Find(id);
            db.ProjectTasks.Remove(projecttask);
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
