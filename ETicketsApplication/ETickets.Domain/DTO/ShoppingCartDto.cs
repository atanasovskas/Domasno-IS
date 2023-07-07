
using ETickets.Domain.DomainModels;
using System.Collections.Generic;

namespace ETickets.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<TicketInShoppingCart> Tickets { get; set; }
        public double TotalPrice { get; set; }
    }
}
