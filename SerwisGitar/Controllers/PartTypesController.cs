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
    public class PartTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PartTypes
        public ActionResult Index()
        {
            return View(db.PartTypes.ToList());
        }

        // GET: PartTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartType partType = db.PartTypes.Find(id);
            if (partType == null)
            {
                return HttpNotFound();
            }
            return View(partType);
        }

        // GET: PartTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartTypes/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PartTypeId,Name")] PartType partType)
        {
            if (ModelState.IsValid)
            {
                db.PartTypes.Add(partType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partType);
        }

        // GET: PartTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartType partType = db.PartTypes.Find(id);
            if (partType == null)
            {
                return HttpNotFound();
            }
            return View(partType);
        }

        // POST: PartTypes/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PartTypeId,Name")] PartType partType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partType);
        }

        // GET: PartTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartType partType = db.PartTypes.Find(id);
            if (partType == null)
            {
                return HttpNotFound();
            }
            return View(partType);
        }

        // POST: PartTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartType partType = db.PartTypes.Find(id);
            db.PartTypes.Remove(partType);
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
