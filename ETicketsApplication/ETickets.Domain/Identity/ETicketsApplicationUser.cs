
using ETickets.Domain.DomainModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ETickets.Domain.Identity
{
    public class ETicketsApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public virtual ShoppingCart UserCart { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
