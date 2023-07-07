

using ETickets.Domain.DomainModels;
using ETickets.Domain.DTO;
using ETickets.Repository.Interface;
using ETickets.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ETickets.Service.Implementation
{

    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _productRepository;
        private readonly IUserRepository _userrepository;
        private readonly IRepository<TicketInShoppingCart> _productInShoppingCartRepository;
        private readonly ILogger<TicketService> _logger;
        public TicketService(IRepository<Ticket> productRepository, IUserRepository userrepository, IRepository<TicketInShoppingCart> productInShoppingCartRepository,ILogger<TicketService> logger)
        {
            _productRepository = productRepository;
            _userrepository = userrepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
            _logger = logger;
        }
        public bool AddToShoppingCart(AddToShoppingCartDto item, string userID)
        {
            var user = this._userrepository.Get(userID);
            var userShoppingCard = user.UserCart;

            if (item.TicketId != null && userShoppingCard != null)
            {
                var product = this._productRepository.Get(item.TicketId);
                if (product != null)
                {
                    TicketInShoppingCart itemToAdd = new TicketInShoppingCart
                    {
                        Id = Guid.NewGuid(),
                        Ticket= product,
                        TicketId = product.Id,
                        ShoppingCart = userShoppingCard,
                        ShoppingCartId = userShoppingCard.Id,
                        Quantity = item.Quantity
                    };

                    this._productInShoppingCartRepository.Insert(itemToAdd);
                    _logger.LogInformation("Product was sucesfully added to shopping card");
                    return true;
                }
                return false;
            }
            _logger.LogInformation("Somwthing went wrong");
            return false;
        }

        public void CreateNewProduct(Ticket p)
        {
            p.Id = Guid.NewGuid();
            this._productRepository.Insert(p);

        }

        public void DeleteProduct(Guid id)
        {
            var product = this.GetDetailsForProduct(id);

            this._productRepository.Delete(product);
        }

        public List<Ticket> GetAllProducts()
        {
            return this._productRepository.GetAll().ToList();
        }

        public Ticket GetDetailsForProduct(Guid? id)
        {
            return this._productRepository.Get(id);
        }

        public AddToShoppingCartDto GetShoppingCartInfo(Guid? id)
        {

            var product = this.GetDetailsForProduct(id);
            AddToShoppingCartDto model = new AddToShoppingCartDto
            {
                SelectedTicket = product,
                TicketId = product.Id,
                Quantity = 1
            };
            return model;
        }

        public void UpdeteExistingProduct(Ticket p)
        {
            this._productRepository.Update(p);
        }
    }
}
