using Pylon.BL.Interface;
using Pylon.DAL.Interface;
using Pylon.DAL.Models;
using System;
using System.Collections.Generic;

namespace Pylon.BL.Sevices
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public OrderDTO Get(int id)
        {
			var order = _unitOfWork.OrderManager.GetById(id); /*?? throw new*/ 
            return AutoMapper.Mapper.Map<OrderDTO>(order);
        }

        public ICollection<OrderDTO> GetByProfile(string id)
        {
            var list = _unitOfWork.OrderManager.Get(
                f => f.ProfileId == id,
                includeProperties: $"{nameof(Profile)}");
            return AutoMapper.Mapper.Map<List<OrderDTO>>(list);
        }

		public ICollection<OrderDTO> GetFilter(OrderDTO order)
		{
			var list = _unitOfWork.OrderManager.Get(
					 o => (order.ProfileId == o.ProfileId) &&
					 (order.ProductName == null ? o.Product.Name.Length > 0 : o.Product.Name.Contains(order.ProductName)) &&
					 (order.ProductModel == null ? o.Product.Model.Length > 0 : o.Product.Model.Contains(order.ProductModel))&&
					 (order.StartDate <= o.StartDate && order.EndDate >= o.EndDate));
			return AutoMapper.Mapper.Map<List<OrderDTO>>(list);
		}

		public ICollection<OrderDTO> GetAll()
        {
            var list = _unitOfWork.OrderManager.Get();
            return AutoMapper.Mapper.Map<List<OrderDTO>>(list);
        }

        public int Add(OrderDTO orderDTO)
        {
            var order = AutoMapper.Mapper.Map<Order>(orderDTO);
			var allOrders =  _unitOfWork.OrderManager.Get(x => x.ProductId == order.ProductId);
			foreach (var ord in allOrders)
			{
				if (order.StartDate < ord.StartDate && order.EndDate > ord.EndDate)
					return 0;
			}
            _unitOfWork.OrderManager.Insert(order);
            _unitOfWork.SaveChanges();
            return order.Id;
        }

        public void Delete(int id)
        {
            _unitOfWork.OrderManager.Delete(id);
            _unitOfWork.SaveChanges();
        }
       
        public void Update(OrderDTO orderDTO)
        {
            var order = _unitOfWork.OrderManager.GetById(orderDTO.Id);
            order.OrderNumber = orderDTO.OrderNumber;
            order.StartDate = orderDTO.StartDate;
            order.EndDate = orderDTO.EndDate;
            _unitOfWork.OrderManager.Update(order);
            _unitOfWork.SaveChanges();
        }
    }
}
