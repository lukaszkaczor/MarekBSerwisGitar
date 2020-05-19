using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SerwisGitar.Models;
using SerwisGitar.Models.AppModels;
using SerwisGitar.ViewModels.CustomInstruments;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using SerwisGitar.Models.DbModels;

namespace SerwisGitar.Controllers
{
    public class CustomInstrumentsController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET
        public ActionResult Index()
        {
            var partTypes = _context.PartTypes.ToList();
            var partsList = new List<TypeWithItsParts>();

            //foreach (var partType in partTypes)
            //{
            //    partsList.Add(new TypeWithItsParts()
            //    {
            //        Type = 
            //        Parts = partType.GuitarParts
            //    });
            //}

            var model = new CustomInstrumentViewModel()
            {
                PartTypes = _context.PartTypes.Include(d=>d.GuitarParts).ToList(),
                Instruments = _context.Instruments.ToList()
            };


            return View(model);
        }

        [HttpPost]
        public ActionResult Save(CustomInstrumentViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var guitarParts = _context.GuitarParts.ToList();

            var partsList = new List<CustomInstrumentParts>();

            var customInstrument = new CustomInstrument()
            {
                ApplicationUserId = userId,
                InstrumentId = model.Instrument.InstrumentId,
                PrimaryColor = model.PrimaryColor,
                SecondaryColor = model.SecondaryColor
            };

            foreach (var type in model.SelectedParts)
            {
                partsList.Add(new CustomInstrumentParts()
                {
                    CustomInstrumentId = model.Instrument.InstrumentId,
                    GuitarPartId = type.GuitarPartId
                });
            }

            _context.CustomInstruments.AddOrUpdate(customInstrument);
            _context.CustomInstrumentParts.AddRange(partsList);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}