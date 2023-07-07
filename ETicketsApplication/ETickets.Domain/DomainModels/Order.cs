
using ETickets.Domain.Identity;
using System;
using System.Collections.Generic;

namespace ETickets.Domain.DomainModels
{
    public class Order:BaseEntity
    { 

        public string UserId { get; set; }
        public ETicketsApplicationUser User { get; set; }
        public IEnumerable<TicketInOrder> TicketInOrders { get; set; }
        
    }
}
