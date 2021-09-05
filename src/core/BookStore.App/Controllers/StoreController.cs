using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Bookstore.App.Repository;

namespace Bookstore.App.Controllers
{
    public class StoreController : Controller
    {
        private IStoreRepository repository;

        public StoreController(IStoreRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index(string category = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var products = repository.GetFilteredProductsAsync(category, minPrice, maxPrice);

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
