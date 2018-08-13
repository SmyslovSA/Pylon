using PagedList;
using Pylon.BL;
using Pylon.BL.Interface;
using Pylon.Models;
using Pylon.Website.Extension;
using System;
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
		public ActionResult GetCustomerOrders(int page = 1)
        {
            var list = _orderService.GetByProfile(User.GetUserId());
            return View(list.ToPagedList(page,5));
        }

		[HttpPost]
		public ActionResult GetFilter(OrderFilterModel model, string userId)
		{
			OrderDTO product = new OrderDTO
			{
				ProfileId = userId,
				ProductName = model.ProductName,
				ProductModel = model.ProductModel,
				StartDate = model.StartDate == DateTime.MinValue ? model.StartDate = DateTime.Parse("01.01.2000") : model.StartDate,
				EndDate = model.EndDate == DateTime.MinValue ? model.EndDate = DateTime.MaxValue : model.EndDate,
			};
			var list = _orderService.GetFilter(product);
			return View("GetCustomerOrders", list.ToPagedList(1, 5));
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