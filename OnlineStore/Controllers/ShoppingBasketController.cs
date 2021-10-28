using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Context;
using Microsoft.AspNetCore.Authorization;
using OnlineStore.Core.Abstracts;
using OnlineStore.View.ViewModels;

namespace OnlineStore.View.Controllers
{
    [Authorize(Roles = "User")]
    public class ShoppingBasketController : Controller
    {
        private readonly ApplicationContext _applicationContext;

        private string AuthorizedUserId => User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;

        public ShoppingBasketController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IActionResult Basket()
        {
            var purchases = _applicationContext.Purchases.Where(p => p.UserId == AuthorizedUserId);

            var products = new List<IProduct>();
            foreach (var purchase in purchases)
            {
                products.AddRange(_applicationContext.Products.Where(p => p.Id == purchase.ProductId));
            }

            var model = new ShoppingBasketViewModel()
            {
                Products = products
            };

            return View(model);
        }
    }
}