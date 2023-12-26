using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppPViewIcc.Models;

namespace WebAppPViewIcc.Controllers
{
    public class CupsController : Controller
    {
        private WorldCupdbEntities db = new WorldCupdbEntities();

        // GET: Cups
        public ActionResult Index()
        {
            return View(db.Cups.ToList());
        }

        // GET: Cups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cup cup = db.Cups.Find(id);
            if (cup == null)
            {
                return HttpNotFound();
            }
            return View(cup);
        }

        // GET: Cups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamId,TeamName,NOWC")] Cup cup)
        {
            if (ModelState.IsValid)
            {
                db.Cups.Add(cup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cup);
        }

        // GET: Cups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cup cup = db.Cups.Find(id);
            if (cup == null)
            {
                return HttpNotFound();
            }
            return View(cup);
        }

        // POST: Cups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamId,TeamName,NOWC")] Cup cup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cup);
        }

        // GET: Cups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cup cup = db.Cups.Find(id);
            if (cup == null)
            {
                return HttpNotFound();
            }
            return View(cup);
        }

        // POST: Cups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cup cup = db.Cups.Find(id);
            db.Cups.Remove(cup);
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
