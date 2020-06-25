using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerwisGitar.Models;
using System.Data.Entity;
using SerwisGitar.Models.AppModels;
using SerwisGitar.Models.DbModels;
using SerwisGitar.ViewModels.Home;

namespace SerwisGitar.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            var model = _context.ContentEditor.Where(d => d.IsDraftVersion == false)
                .FirstOrDefault(d => d.Page == Page.HomeIndex);
            return View(model);
        }


        public ActionResult About()
        {
            var model = _context.ContentEditor.Where(d=>d.IsDraftVersion == false).FirstOrDefault(d => d.Page == Page.HomeAbout);
            return View(model);
        }


        public ActionResult Gallery()
        {
            var mainGallery = _context.MainGallery
                .Include(d=>d.ServiceGallery.ImageGalleries)
                .Include(d=>d.OurInstruments.ImageGalleries).FirstOrDefault();

            
            return View(mainGallery);
        }

        public ActionResult Services()
        {
            var model = new HomeServicesViewModel()
            {
                Instruments = _context.Instruments.ToList()
            };

            return View(model);
        }

        [HttpGet]
        public JsonResult GetList(int instrumentId)
        {
            _context.Configuration.ProxyCreationEnabled = false;

            var instrument = _context.Instruments.FirstOrDefault(d=>d.InstrumentId==instrumentId);

            var services = _context.Services.Include(d=>d.ServiceType).ToList();
            var instrumentServices = _context.InstrumentServices.ToList();

            var result = from service in services
                join ins in instrumentServices on service.ServiceId equals ins.ServiceId
                where ins.InstrumentId == instrumentId
                select service;

            var servicesList = result.ToList();

            var model = new List<InstrumentWithService>();
            foreach (var service in servicesList)
            {
                model.Add(new InstrumentWithService()
                {
                    ServiceId = service.ServiceId,
                    ServiceName = service.Name,
                    ServicePrice = service.Price,
                    InstrumentId = instrumentId,
                    ServiceTypeName = service.ServiceType.Name
                });
            }

            model = model.OrderBy(d => d.ServiceTypeName).ToList();

            return Json(model, JsonRequestBehavior.AllowGet);
        }


    }
}