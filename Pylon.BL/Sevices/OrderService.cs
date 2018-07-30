using Pylon.BL.Interface;
using Pylon.DAL;
using Pylon.DAL.Interface;
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

        public OrderDTO GetProduct(int id)
        {
            var order = _unitOfWork.OrderManager.GetById(id);
            return AutoMapper.Mapper.Map<OrderDTO>(order);
        }

        public ICollection<OrderDTO> GetProducts(string id)
        {
            var list = _unitOfWork.OrderManager.Get(f => f.ProfileId == id);
            return AutoMapper.Mapper.Map<List<OrderDTO>>(list);
        }

        public ICollection<OrderDTO> GetAllProducts()
        {
            var list = _unitOfWork.OrderManager.Get();
            return AutoMapper.Mapper.Map<List<OrderDTO>>(list);
        }

        public int AddProduct(OrderDTO orderDTO)
        {
            var order = AutoMapper.Mapper.Map<Order>(orderDTO);
            _unitOfWork.OrderManager.Insert(order);
            _unitOfWork.SaveChanges();
            return order.Id;
        }

        public void DeleteProduct(int id)
        {
            _unitOfWork.OrderManager.Delete(id);
            _unitOfWork.SaveChanges();
        }
       
        public void UpdateProduct(OrderDTO orderDTO)
        {
            var order = _unitOfWork.OrderManager.GetById(orderDTO.Id);
            order.OrderNumber = orderDTO.OrderNumber;
            order.StartDate = orderDTO.StartDate;
            order.EndDate = orderDTO.EndDate;
            order.Count = order.Count;
            _unitOfWork.OrderManager.Update(order);
            _unitOfWork.SaveChanges();
        }
    }
}
