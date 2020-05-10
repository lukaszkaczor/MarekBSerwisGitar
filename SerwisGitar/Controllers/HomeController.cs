using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerwisGitar.Models;
using System.Data.Entity;

namespace SerwisGitar.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var model = _context.ContentEditor.Where(d=>d.IsDraftVersion == false).FirstOrDefault(d => d.Page == Page.HomeAbout);
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Gallery()
        {
            var mainGallery = _context.MainGallery
                .Include(d=>d.ServiceGallery.ImageGalleries)
                .Include(d=>d.ServiceGallery.ImageGalleries).FirstOrDefault();

            return View(mainGallery);
        }


    }
}