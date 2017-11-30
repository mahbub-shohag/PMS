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
    public class UserProjectController : Controller
    {
        private PMSDbContext db = new PMSDbContext();

        // GET: /UserProject/
        public ActionResult Index()
        {
            var userprojects = db.UserProjects.Include(u => u.project).Include(u => u.user);
            return View(userprojects.ToList());
        }

        // GET: /UserProject/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProject userproject = db.UserProjects.Find(id);
            if (userproject == null)
            {
                return HttpNotFound();
            }
            return View(userproject);
        }

        // GET: /UserProject/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: /UserProject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,UserId,ProjectId")] UserProject userproject)
        {
            if (ModelState.IsValid)
            {
                db.UserProjects.Add(userproject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", userproject.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", userproject.UserId);
            return View(userproject);
        }

        // GET: /UserProject/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProject userproject = db.UserProjects.Find(id);
            if (userproject == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", userproject.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", userproject.UserId);
            return View(userproject);
        }

        // POST: /UserProject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,UserId,ProjectId")] UserProject userproject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userproject).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", userproject.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", userproject.UserId);
            return View(userproject);
        }

        // GET: /UserProject/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProject userproject = db.UserProjects.Find(id);
            if (userproject == null)
            {
                return HttpNotFound();
            }
            return View(userproject);
        }

        // POST: /UserProject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProject userproject = db.UserProjects.Find(id);
            db.UserProjects.Remove(userproject);
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
