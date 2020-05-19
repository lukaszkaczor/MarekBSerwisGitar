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
using SerwisGitar.ViewModels.Instruments;

namespace SerwisGitar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InstrumentsController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Instruments
        public ActionResult Index()
        {
            return View(_context.Instruments.ToList());
        }


        public ActionResult Save(int? id)
        {
            var services = _context.Services.Include(d => d.ServiceType).ToList();
            var instrument = new Instrument();
            if (id != null)
            {
                instrument = _context.Instruments.Find(id);

                var instrumentServices = _context.InstrumentServices.Where(d => d.InstrumentId == instrument.InstrumentId);

                foreach (var service in services)
                    if (instrumentServices.Any(d => d.ServiceId == service.ServiceId))
                        service.IsChecked = true;

            }

            var model = new CreateInstrumentViewModel()
            {
                Services = services,
                Instrument = instrument
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CreateInstrumentViewModel model)
        {
            var instrumentServices = _context.InstrumentServices.Where(d=>d.InstrumentId == model.Instrument.InstrumentId).ToList();
            var services = _context.Services.Include(d => d.ServiceType).ToList();

            if (model.Instrument.InstrumentId == 0)
            {
                _context.Instruments.Add(model.Instrument);
                _context.SaveChanges();
            }
            else
            {
                var instrument = _context.Instruments.Find(model.Instrument.InstrumentId);
                instrument.Name = model.Instrument.Name;
                instrument.ImageUrl = model.Instrument.ImageUrl;
            }

            foreach (var service in model.Services)
            {
                if (service.IsChecked && instrumentServices.All(d => d.ServiceId != service.ServiceId))
                {
                    _context.InstrumentServices.Add(new InstrumentServices()
                    {
                        ServiceId = service.ServiceId,
                        InstrumentId = model.Instrument.InstrumentId
                    });
                }
                else if (!service.IsChecked && instrumentServices.Any(d => d.ServiceId == service.ServiceId))
                {
                    _context.InstrumentServices.Remove(instrumentServices.First(d => d.ServiceId == service.ServiceId && d.InstrumentId == model.Instrument.InstrumentId));
                }
                else if (service.IsChecked && instrumentServices.Any(d => d.ServiceId == service.ServiceId))
                {
                    service.IsChecked = !service.IsChecked;
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrument instrument = _context.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            return View(instrument);
        }

        // POST: Instruments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instrument instrument = _context.Instruments.Find(id);
            _context.Instruments.Remove(instrument);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
