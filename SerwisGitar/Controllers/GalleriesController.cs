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
        private ApplicationDbContext _context = new ApplicationDbContext();


        public ActionResult Index()
        {
            return View(_context.Galleries.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = _context.Galleries.Find(id);
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
                _context.Galleries.Add(gallery);
                _context.SaveChanges();
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
            Gallery gallery = _context.Galleries.Find(id);


            var images =
                from image in _context.Images
                join imgGallery in _context.ImageGalleries on image.ImageId equals imgGallery.ImageId
                join galleries in _context.Galleries on imgGallery.GalleryId equals galleries.GalleryId
                where imgGallery.GalleryId == id
                orderby imgGallery.Order
                select image;

            var imgGalleries = _context.ImageGalleries.Where(d => d.GalleryId == id).OrderBy(d => d.Order).ToList();

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
                _context.Entry(gallery).State = EntityState.Modified;
                _context.SaveChanges();
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
            Gallery gallery = _context.Galleries.Find(id);
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
            Gallery gallery = _context.Galleries.Find(id);
            _context.Galleries.Remove(gallery);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddImage(int id)
        {
            var editedGallery = _context.Galleries.Find(id);

            if (editedGallery == null) return HttpNotFound();

            var orderValue = _context.ImageGalleries.Where(d => d.GalleryId == id).Max(d => d.Order) + 1 ?? 1;

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


            var imageFromDb = _context.Images.FirstOrDefault(d => d.Url == model.Image.Url);

            if (imageFromDb == null)
            {
                _context.Images.Add(image);
                _context.SaveChanges();
                imageFromDb = image;
            }

            var imgGalleryAlreadyExists = _context.ImageGalleries
                .Where(d => d.GalleryId == model.Gallery.GalleryId).Any(d => d.ImageId == imageFromDb.ImageId);

            if (!imgGalleryAlreadyExists)
            {
                var imgGallery = new ImageGallery()
                {
                    GalleryId = model.Gallery.GalleryId,
                    ImageId = imageFromDb.ImageId,
                    Order = model.ImageGallery.Order
                };
                _context.ImageGalleries.Add(imgGallery);
                _context.SaveChanges();

                //_galleryManager = new GalleryManager(_context);

                //_galleryManager.SetOrderOfImageGalleries(imgGallery);
            }

            return RedirectToAction("Edit", new { id = model.Gallery.GalleryId });
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteImageFromGallery(int galleryId, int imageId)
        {
            GalleryManager galleryManager = new GalleryManager(_context);

            var imageToDelete = _context.ImageGalleries.Where(d => d.GalleryId == galleryId).FirstOrDefault(d => d.ImageId == imageId);
            _context.ImageGalleries.Remove(imageToDelete);
            _context.SaveChanges();

            galleryManager.OrderAndSave(_context.ImageGalleries.Where(d => d.GalleryId == galleryId).ToList());

            return RedirectToAction("Edit", new { id = galleryId });
        }

        public ActionResult SetPositionOfImage(int galleryId, int imageId, bool actionType)
        {
            GalleryManager galleryManager = new GalleryManager(_context);
            var action = actionType ? 1 : -1;
            var imageGallery = _context.ImageGalleries.Where(d => d.GalleryId == galleryId)
                .FirstOrDefault(d => d.ImageId == imageId);

            if (imageGallery == null) return HttpNotFound();

            imageGallery.Order = imageGallery.Order += action;
            galleryManager.SetOrderOfImageGalleries(imageGallery);

            return RedirectToAction("Edit", new { id = galleryId });
        }
    }
}
