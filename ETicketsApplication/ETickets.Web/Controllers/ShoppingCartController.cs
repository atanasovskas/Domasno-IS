using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using System.Collections.Generic;
using ETickets.Domain.DTO;
using ETickets.Domain.DomainModels;
using ETickets.Repository;
using ETickets.Service.Interface;

namespace ETickets.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        public IActionResult Index()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //Select * from users where id LIKE userid

            return View(this._shoppingCartService.getShoppingCartInfo(userid));
        }
        public IActionResult DeleteFromShoppingCart(Guid id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            this._shoppingCartService.DeleteProductFromShoppingCart(userId, id);
            return RedirectToAction("Index", "ShoppingCart");
        }

        public IActionResult Order()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = this._shoppingCartService.OrderNow(userid);
            if (result)
                return RedirectToAction("Index", "ShoppingCart");
            else
            {
                return RedirectToAction("Index", "ShoppingCart");
            }
        }
    }
}
