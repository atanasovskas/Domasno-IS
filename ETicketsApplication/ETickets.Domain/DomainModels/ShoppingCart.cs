
using ETickets.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace ETickets.Domain.DomainModels
{
    public class ShoppingCart:BaseEntity
    {
        
        public virtual ICollection<TicketInShoppingCart> TicketInShoppingCarts { get; set; }
        public string OwnerId { get; set; }
        public virtual ETicketsApplicationUser Owner { get; set; }
    }
}
