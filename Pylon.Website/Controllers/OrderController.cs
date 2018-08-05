using Pylon.BL;
using Pylon.BL.Interface;
using Pylon.Website.Extension;
using Pylon.Website.Models;
using System;
using System.Globalization;
using System.Web.Mvc;

namespace Pylon.Website.Controllers
{
	[Authorize(Roles = "customer")]
    public class OrderController : Controller
    {
        private IOrderService _orderService;

        public OrderController(IOrderService service)
        {
            _orderService = service;
        }

        [HttpGet]
        public ActionResult GetOrder()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCustomerOrders()
        {
            var list = _orderService.GetByProfile(User.GetUserId());
            return View(list);
        }

        [HttpGet]
        public ActionResult GetAllOrders()
        {
            var list = _orderService.GetAll();
            return View(list);
        }

        [HttpPost]
        public ActionResult AddOrder(string startDate, string endDate, int productId)
        {
            OrderDTO orderDTO = new OrderDTO
            {
                StartDate = DateTime.Parse(startDate),
                EndDate = DateTime.Parse(endDate),
				ProductId = productId,
                ProfileId = User.GetUserId()
            };

            _orderService.Add(orderDTO);
            return RedirectToAction("GetAll", "Product");
        }

        public ActionResult RemoveOrder(int id)
        {
            _orderService.Delete(id);
            return RedirectToAction("GetCustomerOrders");
        }
    }
}