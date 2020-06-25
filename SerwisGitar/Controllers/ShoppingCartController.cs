using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Schema;
using Microsoft.AspNet.Identity;
using SerwisGitar.Models;
using SerwisGitar.Models.DbModels;
using SerwisGitar.ViewModels.Home;
using SerwisGitar.ViewModels.ShoppingCart;
using System.Data.Entity;
namespace SerwisGitar.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var model = _context.ShoppingCarts
                .Include(d => d.Instrument)
                .Include(d => d.Service.ServiceType)
                .Include(d=>d.CustomInstrument.CustomInstrumentParts)
                .Include(d=>d.CustomInstrument.Instrument)
                .Where(d => d.ApplicationUserId == userId).ToList();


            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddToCart(HomeServicesViewModel model, int InstrumentId)
        {
            var userId = User.Identity.GetUserId();
            var shoppingList = new List<ShoppingCart>();

            foreach (var service in model.Services)
            {
                if (service.IsChecked)
                {
                    shoppingList.Add(new ShoppingCart()
                    {
                        ApplicationUserId = userId,
                        ServiceId = service.ServiceId,
                        InstrumentId = InstrumentId
                    });
                }
            }

            if (!string.IsNullOrWhiteSpace(model.Message))
            {
                shoppingList.Add(new ShoppingCart()
                {
                    ApplicationUserId = userId,
                    ServiceDescription = model.Message,
                    InstrumentId = InstrumentId
                });
            }

            _context.ShoppingCarts.AddRange(shoppingList);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteFromCart(int? itemId, string itemName, int? customInstrumentId)
        {
            var userId = User.Identity.GetUserId();
            ShoppingCart productToDelete = null;

            if (itemId!=null)
            {
                productToDelete = _context.ShoppingCarts.Where(d => d.ApplicationUserId == userId)
                    .FirstOrDefault(d => d.ServiceId == itemId);
            }else if (!String.IsNullOrWhiteSpace(itemName))
            {
                productToDelete = _context.ShoppingCarts.Where(d => d.ApplicationUserId == userId)
                    .FirstOrDefault(d => d.ServiceDescription == itemName);
            }
            else if (customInstrumentId != null)
            {
                productToDelete = _context.ShoppingCarts.Where(d => d.ApplicationUserId == userId)
                    .FirstOrDefault(d => d.CustomInstrumentId == customInstrumentId);
            }

            if (productToDelete != null)
            {
                _context.ShoppingCarts.Remove(productToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}