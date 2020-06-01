using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerwisGitar.Models;
using SerwisGitar.Models.AppModels;
using SerwisGitar.Models.DbModels;
using SerwisGitar.ViewModels.Admin;
using SerwisGitar.ViewModels.ContentEditor;

namespace SerwisGitar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentEditor(Page? page)
        {
            var pages = Enum.GetNames(typeof(Page))
                .Where(d => d != Page.Temporary.ToString())
                .Select(d => new SelectListItem() { Value = d, Text = d.ToString() });

            var model = new ContentEditorViewModel()
            {
                Pages = PageToEditList.PagesList
            };

            if (page != Page.Temporary)
                model.ContentEditor = _context.ContentEditor
                    .Where(d => d.IsDraftVersion == false)
                    .FirstOrDefault(d => d.Page == page);


                return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveContent(ContentEditorViewModel model)
        {
            var contentEditor = model.ContentEditor;

            if (contentEditor.Page == Page.Temporary)
            {
                return HttpNotFound();
            }

            var itemList = _context.ContentEditor.Where(d => d.Page == contentEditor.Page);

            var draftVersion = itemList.FirstOrDefault(d => d.IsDraftVersion);
            var finalVersion = itemList.FirstOrDefault(d => d.IsDraftVersion == false);

            if (finalVersion != null && !contentEditor.IsDraftVersion)
            {
                finalVersion.Content = contentEditor.Content;
                finalVersion.IsDraftVersion = contentEditor.IsDraftVersion;
            }
            else if (draftVersion != null && contentEditor.IsDraftVersion)
            {
                draftVersion.Content = contentEditor.Content;
                draftVersion.IsDraftVersion = contentEditor.IsDraftVersion;
            }
            else
            {
                _context.ContentEditor.Add(contentEditor);
            }


            _context.SaveChanges();

            return View("Index");
        }

        public ActionResult EditMainGallery()
        {
            var mainGallery = _context.MainGallery.FirstOrDefault();
            var galleries = _context.Galleries.ToList();

            if (mainGallery != null)
            {
                galleries = galleries.OrderBy(d=>d.Name).ToList();
            }

            var model = new EditMainGalleryViewModel()
            {
                Gallery = mainGallery,
                Galleries = galleries
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMainGallery(EditMainGalleryViewModel model)
        {
            if (model.Gallery is null) throw new NullReferenceException();
            
            var mainGallery = _context.MainGallery.FirstOrDefault();
            
            if (mainGallery is null)
            {
                _context.MainGallery.Add(model.Gallery);
            }
            else
            {
                mainGallery.OurInstrumentsId = model.Gallery.OurInstrumentsId;
                mainGallery.ServiceGalleryId = model.Gallery.ServiceGalleryId;
                mainGallery.Title= model.Gallery.Title;
                mainGallery.Description= model.Gallery.Description;
            }

            _context.SaveChanges();

            return RedirectToAction("Gallery", "Home");
        }
    }
}