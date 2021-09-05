using Bookstore.Data.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.App.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly BookStoreDbContext context;

        public AuthorsController(BookStoreDbContext context)
        {
            this.context = context;
        }

        public IActionResult PublishNewBook()
        {
   
            return View();
        }
    }
}
