using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SerwisGitar.Models;
using SerwisGitar.Models.DbModels;
using System.Data.Entity;

namespace SerwisGitar.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var model = new Order()
            {
                ContactEmail = _context.Users.First(d=>d.Id == userId).Email
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(Order model)
        {
            var userId = User.Identity.GetUserId();
            var shoppingCart = _context.ShoppingCarts
                .Include(d=> d.Service)
                .Where(d => d.ApplicationUserId == userId).ToList();

            var orderList = new List<OrderDetails>();

            var order = new Order()
            {
                ApplicationUserId = userId,
                Message = model.Message,
                OrderStatus = OrderStatus.Utworzone,
                OrderDate = DateTime.Now,
                PhoneNumber = model.PhoneNumber,
                ContactEmail = model.ContactEmail
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (var cart in shoppingCart)
            {
                orderList.Add(new OrderDetails()
                {
                    OrderId = order.OrderId,
                    CustomInstrumentId = cart.CustomInstrumentId,
                    ServiceId = cart.ServiceId,
                    Price = cart.Service?.Price
                });
            }

            _context.OrderDetails.AddRange(orderList);
            _context.SaveChanges();

            var orderDetailsList = new List<OrderDetailsOrder>();

            foreach (var item in orderList)
            {
                orderDetailsList.Add(new OrderDetailsOrder()
                {
                    OrderId = order.OrderId,
                    OrderDetailsId = item.OrderDetailsId
                });
            }

            _context.OrderDetailsOrders.AddRange(orderDetailsList);
            _context.ShoppingCarts.RemoveRange(shoppingCart);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult MyOrders()
        {
            var userId = User.Identity.GetUserId();

            var model = _context.Orders.Where(d => d.ApplicationUserId == userId).ToList();
            return View(model);
        }

        public ActionResult OrderDetails(int id)
        {
            var model = _context.Orders
                .Include(d=>d.OrderDetailsOrder
                    .Select(s=>s.OrderDetails.Service))
                .FirstOrDefault(d => d.OrderId == id);
            return View(model);
        }
    }
}