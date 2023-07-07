using ETickets.Domain.DomainModels;
using ETickets.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETickets.Repository.Interface
{
    public interface IOrderRepository
{
        public List<Order> getAllOrders();
        public Order getOrderDetails(BaseEntity model);
    }
}
