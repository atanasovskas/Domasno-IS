
using ETickets.Domain.DomainModels;
using ETickets.Domain.DTO;
using System;
using System.Collections.Generic;

namespace ETickets.Service.Interface
{
    public interface ITicketService
    {
        List<Ticket> GetAllProducts();
        Ticket GetDetailsForProduct(Guid? id);
        void CreateNewProduct(Ticket p);
        void UpdeteExistingProduct(Ticket p);
        AddToShoppingCartDto GetShoppingCartInfo(Guid? id);
        void DeleteProduct(Guid id);
        bool AddToShoppingCart(AddToShoppingCartDto item, string userID);
    }
}