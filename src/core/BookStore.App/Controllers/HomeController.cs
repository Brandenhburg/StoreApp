using Microsoft.AspNetCore.Mvc;
using Bookstore.App.Repository;
using Bookstore.App.ViewModels;
using System.Threading.Tasks;

namespace Bookstore.App.Controllers
{
    [Route("")]
    [Route("[controller]")]
    public class HomeController: Controller
    {

        private readonly IStoreRepository repository;

        public HomeController(IStoreRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await repository.GetRandomProductsAsync());
        }


        [Route("[action]")]
        public IActionResult About()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO: Implement MailService
                ViewBag.Message = "Mail Sent";
                ModelState.Clear();
            }
            return View();
        }
    }
}
