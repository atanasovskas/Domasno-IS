using ETickets.Domain.DomainModels;
using ETickets.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETickets.Service.Interface
{
    public interface IOrderService
{
        public List<Order> getAllOrders();
        public Order getOrderDetails(BaseEntity model);
    }
}
