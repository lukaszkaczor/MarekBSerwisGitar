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

            var carts = _context.ShoppingCarts
                .Include(d => d.Instrument)
                .Include(d => d.Service)
                .Where(d => d.ApplicationUserId == userId).ToList();

            var model = new List<ShoppingCart>();



            return View(carts);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddToCart(HomeServicesViewModel model, int InstrumentId, string serviceDescription)
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

            if (!string.IsNullOrWhiteSpace(serviceDescription))
            {
                shoppingList.Add(new ShoppingCart()
                {
                    ApplicationUserId = userId,
                    ServiceDescription = serviceDescription,
                    InstrumentId = InstrumentId
                });
            }

            _context.ShoppingCarts.AddRange(shoppingList);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteFromCart(int itemId)
        {
            var userId = User.Identity.GetUserId();

            var productToDelete = _context.ShoppingCarts.Where(d => d.ApplicationUserId == userId)
                .FirstOrDefault(d => d.ServiceId == itemId);

            _context.ShoppingCarts.Remove(productToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}