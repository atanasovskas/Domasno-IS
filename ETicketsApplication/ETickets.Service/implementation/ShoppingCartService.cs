using ETickets.Domain.DomainModels;
using ETickets.Domain.DTO;
using ETickets.Repository.Interface;
using ETickets.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETickets.Service.implementation
{
    public class ShoppingCartService:IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<TicketInOrder> _producInOrder;
        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IUserRepository userRepository, IRepository<Order> orderRepository, IRepository<TicketInOrder> productInOrder)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _producInOrder = productInOrder;
        }

        public void DeleteProductFromShoppingCart(string userid, Guid id)
        {

            //Select * from users where id LIKE userid
            if (!string.IsNullOrEmpty(userid) && id != null)
            {
                var loggedInUser = this._userRepository.Get(userid);
                //katichkata na userot
                var userShoppingCart = loggedInUser.UserCart;
                //brisi odreden element od shopping cart od productInshoppingcart
                var itemToDelete = userShoppingCart.TicketInShoppingCarts.Where(z => z.Ticket.Id.Equals(id)).FirstOrDefault();
                userShoppingCart.TicketInShoppingCarts.Remove(itemToDelete);

                this._shoppingCartRepository.Update(userShoppingCart);
            }
        }

        public ShoppingCartDto getShoppingCartInfo(string userId)
        {
            var loggedInUser = this._userRepository.Get(userId);

            //katichkata na userot
            var userShoppingCart = loggedInUser.UserCart;
            //site producto vo kartichkata
            var AllProducts = userShoppingCart.TicketInShoppingCarts.ToList();
            //vkupna cena
            var allProductPrice = AllProducts.Select(z => new
            {
                ProductPrice = z.Ticket.TicketPrice,
                Quantity = z.Quantity
            });
            var totalPrice = 0;
            foreach (var item in allProductPrice)
            {
                totalPrice += item.Quantity * item.ProductPrice;
            }
            ShoppingCartDto scDto = new ShoppingCartDto
            {
                Tickets = AllProducts,
                TotalPrice = totalPrice

            };
            return scDto;
        }

        public bool OrderNow(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = this._userRepository.Get(userId);
                //katichkata na userot
                var userShoppingCart = loggedInUser.UserCart;

                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    User = loggedInUser,
                    UserId = userId

                };
                _orderRepository.Insert(order);


                List<TicketInOrder> productInOrders = new List<TicketInOrder>();
                var result = userShoppingCart.TicketInShoppingCarts.Select(z => new TicketInOrder
                {
                    Id = Guid.NewGuid(),
                    TicketId = z.TicketId,
                    OrderedTicket = z.Ticket,
                    OrderId = order.Id,
                    UserOrder = order

                }).ToList();
                productInOrders.AddRange(result);

                foreach (var item in productInOrders)
                {
                    this._producInOrder.Insert(item);
                }


                loggedInUser.UserCart.TicketInShoppingCarts.Clear();

                this._userRepository.Update(loggedInUser);
                return true;
            }
            return false;
        }

    }
}
