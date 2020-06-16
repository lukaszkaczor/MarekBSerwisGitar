using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SerwisGitar.Models;
using SerwisGitar.ViewModels.OrdersManagement;
using System.Data.Entity;
using SerwisGitar.Models.DbModels;

namespace SerwisGitar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrdersManagementController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET
        public ActionResult Index()
        {
            var model = _context.Orders.Where(d => d.EmployeeId == null).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrder(int id)
        {
            var adminId = User.Identity.GetUserId();

            var model = _context.Orders.Where(d => d.EmployeeId == null).FirstOrDefault(d => d.OrderId == id);
            if (model != null) model.EmployeeId = adminId;
            if (model != null) model.OrderStatus = OrderStatus.Przyjęte;
            _context.SaveChanges();

            return RedirectToAction("ManageOrder", new { id = id});
        }

        public ActionResult ManageOrder(int id)
        {
            var order = _context.Orders
                .Include(d => d.ApplicationUser)
                .FirstOrDefault(d => d.OrderId == id);

            var orderDetails = _context.OrderDetails
                .Include(d=>d.Instrument)
                .Include(d=>d.Order)
                .Include(d=>d.CustomInstrument.Instrument)
                .Include(d=>d.Service.ServiceType).Where(d => d.OrderId == id).ToList();

            var model = new ManageOrderViewModel()
            {
                Order = order,
                OrderDetails = orderDetails
            };
            return View(model);
        }

        public ActionResult AcceptedOrders()
        {
            var adminId = User.Identity.GetUserId();
            var model = _context.Orders.Where(d => d.EmployeeId == adminId)
                .Where(d => d.OrderStatus == OrderStatus.Przyjęte).ToList();
            return View(model);
        }

        public ActionResult ChangeStatus(int orderDetailsId)
        {
            var orderDetails = _context.OrderDetails.Include(d => d.Order).FirstOrDefault(d => d.OrderDetailsId == orderDetailsId);

            orderDetails.IsCompleted = !orderDetails.IsCompleted;
            _context.SaveChanges();

            return RedirectToAction("ManageOrder", new { id = orderDetails.Order.OrderId });
        }


        public ActionResult SetStatusToCompleted(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            var orderDetails = _context.OrderDetails.Where(d => d.OrderId == orderId);

            if (!orderDetails.All(d => d.IsCompleted))
                return HttpNotFound();


            order.OrderStatus = OrderStatus.Zakończone;
            _context.SaveChanges();

            return RedirectToAction("History");
        }

        public ActionResult SetStatusToCancelled(int orderId)
        {
            var order = _context.Orders.Find(orderId);

            order.OrderStatus = OrderStatus.Anulowane;
            _context.SaveChanges();

            return RedirectToAction("History");
        }

        public ActionResult History()
        {
            var userId = User.Identity.GetUserId();

            var model = new List<Order>();

            model = _context.Orders
                .Where(d => d.EmployeeId == userId)
                .Where(d => d.OrderStatus != OrderStatus.Utworzone && d.OrderStatus != OrderStatus.Przyjęte).ToList();

            return View(model);
        }
    }
}