using ETickets.Domain.DomainModels;
using ETickets.Domain;
using ETickets.Repository.Interface;
using ETickets.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETickets.Service.implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<Order> getAllOrders()
        {
            return this._orderRepository.getAllOrders();
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return this._orderRepository.getOrderDetails(model);
        }
    }
}
