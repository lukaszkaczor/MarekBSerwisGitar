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
using SerwisGitar.ViewModels.Galleries;

namespace SerwisGitar.Controllers
{
    public class GalleriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Galleries.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GalleryId,Name")] Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                db.Galleries.Add(gallery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gallery);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);


            var images =
                from image in db.Images
                join imgGallery in db.ImageGalleries on image.ImageId equals imgGallery.ImageId
                join galleries in db.Galleries on imgGallery.GalleryId equals galleries.GalleryId
                where imgGallery.GalleryId == id
                orderby imgGallery.Order
                select image;

            var imgGalleries = db.ImageGalleries.Where(d => d.GalleryId == id).OrderBy(d => d.Order).ToList();

            var model = new GalleryViewModel()
            {
                Images = images.ToList(),
                Gallery = gallery,
                ImageGalleries = imgGalleries
            };

            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GalleryId,Name")] Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gallery);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gallery gallery = db.Galleries.Find(id);
            db.Galleries.Remove(gallery);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddImage(int id)
        {
            var editedGallery = db.Galleries.Find(id);

            if (editedGallery == null) return HttpNotFound();

            var orderValue = db.ImageGalleries.Where(d => d.GalleryId == id).Max(d => d.Order) + 1 ?? 1;

            var model = new AddImageViewModel()
            {
                Gallery = editedGallery,
                ImageGallery = new ImageGallery()
                {
                    Order = orderValue
                }
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddImage(AddImageViewModel model, int? imageId)
        {
            var image = model.Image;


            var imageFromDb = db.Images.FirstOrDefault(d => d.Url == model.Image.Url);

            if (imageFromDb == null)
            {
                db.Images.Add(image);
                db.SaveChanges();
                imageFromDb = image;
            }

            var imgGalleryAlreadyExists = db.ImageGalleries
                .Where(d => d.GalleryId == model.Gallery.GalleryId).Any(d => d.ImageId == imageFromDb.ImageId);

            if (!imgGalleryAlreadyExists)
            {
                var imgGallery = new ImageGallery()
                {
                    GalleryId = model.Gallery.GalleryId,
                    ImageId = imageFromDb.ImageId,
                    Order = model.ImageGallery.Order
                };
                db.ImageGalleries.Add(imgGallery);
                db.SaveChanges();

                //_galleryManager = new GalleryManager(db);

                //_galleryManager.SetOrderOfImageGalleries(imgGallery);
            }

            return RedirectToAction("Edit", new { id = model.Gallery.GalleryId });
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
