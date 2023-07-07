using ETickets.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETickets.Service.Interface { 
    public interface IShoppingCartService
{
     ShoppingCartDto getShoppingCartInfo(string userId);
    void DeleteProductFromShoppingCart(string userid, Guid id);
    bool OrderNow(string userId);
}
}
