﻿using System.Collections.Generic;
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

            var model = new CustomInstrumentViewModel()
            {
                PartTypes = _context.PartTypes.Include(d => d.GuitarParts).ToList(),
                Instruments = _context.Instruments.ToList()
            };


            return View(model);
        }

        [HttpPost]
        [Authorize]
        //[ValidateAntiForgeryToken]
        public ActionResult Save(CustomInstrumentViewModel model)
        {
            var userId = User.Identity.GetUserId();

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
                    CustomInstrumentId = customInstrument.CustomInstrumentId,
                    GuitarPartId = type.GuitarPartId
                });
            }
            _context.CustomInstruments.Add(customInstrument);
            _context.CustomInstrumentParts.AddRange(partsList);
            _context.SaveChanges();
            _context.ShoppingCarts.Add(new ShoppingCart()
            {
                ApplicationUserId = User.Identity.GetUserId(),
                CustomInstrumentId = customInstrument.CustomInstrumentId
            });
            _context.SaveChanges();

            return RedirectToAction("Index", "ShoppingCart");
        }

        public ActionResult Details(int id, int? orderId)
        {
            var model = _context.CustomInstruments
                .Include(d=>d.CustomInstrumentParts.Select(cd=>cd.GuitarPart.PartType))
                .Include(d=>d.Instrument)
                .FirstOrDefault(d => d.CustomInstrumentId == id);

            ViewBag.OrderId = orderId;

            return View(model);
        }
    }
}