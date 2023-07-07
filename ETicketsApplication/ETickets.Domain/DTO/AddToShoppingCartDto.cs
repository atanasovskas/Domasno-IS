﻿using ETickets.Domain.DomainModels;
using System;

namespace ETickets.Domain.DTO
{
    public class AddToShoppingCartDto
    {

        public Ticket SelectedTicket { get; set; }
        public Guid TicketId { get; set; }
        public int Quantity { get; set; }
    }
}
