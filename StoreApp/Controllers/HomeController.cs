using Microsoft.AspNetCore.Mvc;
using StoreApp.Data;
using StoreApp.Data.Repository;
using StoreApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Controllers
{
    public class HomeController: Controller
    {

        private readonly IStoreRepository repository;

        public HomeController(IStoreRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("")]
        [HttpGet("home")]
        public async Task<IActionResult> Index()
        {
            return View(await repository.GetRandomProductsAsync());
        }


        [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }


        [HttpGet("contact")]
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
