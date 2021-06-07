using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Controllers
{
    public class ShopController : Controller
    {
        private IStoreRepository repository;

        public ShopController(IStoreRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> Index(string category = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var products = await repository.GetFilteredProductsAsync(category, minPrice, maxPrice);

            ViewBag.Category = category;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            return View(products);
        }

        [Authorize]
        public IActionResult Buy()
        {
            return View();
        }

    }
}
