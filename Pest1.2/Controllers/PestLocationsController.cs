using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pest1._2.Models;

namespace Pest1._2.Controllers
{
    public class PestLocationsController : Controller
    {
        private PestLocationEntities db = new PestLocationEntities();

        // GET: PestLocations
        public ActionResult Index()
        {
            return View(db.PestLocation.ToList());
        }

        // GET: PestLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PestLocation pestLocation = db.PestLocation.Find(id);
            if (pestLocation == null)
            {
                return HttpNotFound();
            }
            return View(pestLocation);
        }

        // GET: PestLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PestLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "column_0,Scientific_Name,Vernacular_name,Event_Date__parsed,Latitude,Longitude")] PestLocation pestLocation)
        {
            if (ModelState.IsValid)
            {
                db.PestLocation.Add(pestLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pestLocation);
        }

        // GET: PestLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PestLocation pestLocation = db.PestLocation.Find(id);
            if (pestLocation == null)
            {
                return HttpNotFound();
            }
            return View(pestLocation);
        }

        // POST: PestLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "column_0,Scientific_Name,Vernacular_name,Event_Date__parsed,Latitude,Longitude")] PestLocation pestLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pestLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pestLocation);
        }

        // GET: PestLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PestLocation pestLocation = db.PestLocation.Find(id);
            if (pestLocation == null)
            {
                return HttpNotFound();
            }
            return View(pestLocation);
        }

        // POST: PestLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PestLocation pestLocation = db.PestLocation.Find(id);
            db.PestLocation.Remove(pestLocation);
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
