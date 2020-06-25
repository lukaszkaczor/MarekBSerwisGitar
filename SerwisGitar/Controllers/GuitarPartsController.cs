using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SerwisGitar.Models;
using SerwisGitar.Models.DbModels;

namespace SerwisGitar.Controllers
{
    public class GuitarPartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GuitarParts
        public ActionResult Index()
        {
            var guitarParts = db.GuitarParts.Include(g => g.PartType);
            return View(guitarParts.ToList());
        }

        // GET: GuitarParts/Create
        public ActionResult Create()
        {
            ViewBag.PartTypeId = new SelectList(db.PartTypes, "PartTypeId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GuitarPartId,Name,ImageUrl,PartTypeId")] GuitarPart guitarPart)
        {
            if (ModelState.IsValid)
            {
                db.GuitarParts.Add(guitarPart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PartTypeId = new SelectList(db.PartTypes, "PartTypeId", "Name", guitarPart.PartTypeId);
            return View(guitarPart);
        }

        // GET: GuitarParts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuitarPart guitarPart = db.GuitarParts.Find(id);
            if (guitarPart == null)
            {
                return HttpNotFound();
            }
            ViewBag.PartTypeId = new SelectList(db.PartTypes, "PartTypeId", "Name", guitarPart.PartTypeId);
            return View(guitarPart);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GuitarPartId,Name,ImageUrl,PartTypeId")] GuitarPart guitarPart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guitarPart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PartTypeId = new SelectList(db.PartTypes, "PartTypeId", "Name", guitarPart.PartTypeId);
            return View(guitarPart);
        }

        // GET: GuitarParts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuitarPart guitarPart = db.GuitarParts.Include(d=>d.PartType).FirstOrDefault(d => d.GuitarPartId == id);
            if (guitarPart == null)
            {
                return HttpNotFound();
            }
            return View(guitarPart);
        }

        // POST: GuitarParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GuitarPart guitarPart = db.GuitarParts.Find(id);
            db.GuitarParts.Remove(guitarPart);
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
