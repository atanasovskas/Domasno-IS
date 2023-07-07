using System;

namespace ETicketsAdminApplication.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string TicketName { get; set; }

        public string ConcertImage { get; set; }

        public string Description { get; set; }

        public double TicketPrice { get; set; }

        public string Genre { get; set; }
    }
}
