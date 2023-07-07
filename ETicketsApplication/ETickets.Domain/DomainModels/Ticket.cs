using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETickets.Domain.DomainModels
{
    public class Ticket:BaseEntity
    {
        
        [Required]
        public string TicketName { get; set; }
        [Required]
        public string ConcertImage { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int TicketPrice { get; set; }
        [Required]
        public string Genre { get; set; }

        public virtual ICollection<TicketInShoppingCart> TicketInShoppingCart { get; set; }
        public IEnumerable<TicketInOrder> TicketInOrders { get; set; }
    }
}
