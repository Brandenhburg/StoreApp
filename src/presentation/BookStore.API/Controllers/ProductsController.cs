using AutoMapper;
using Bookstore.Domain.Entities;
using Bookstore.API.DTOs;
using Bookstore.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.API.Controllers
{
    [Route("api/products")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILibraryRepository libRepository;
        private readonly IMapper mapper;

        public ProductsController(ILibraryRepository libRepository, IMapper mapper)
        {
            this.libRepository = libRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await libRepository.GetProductsAsync();

            return Ok(mapper.Map<IEnumerable<ProductReadDTO>>(products));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            Product expectedProduct = await libRepository.GetSingleProductAsync(id);

            if (expectedProduct is null)
                return NotFound();

            return Ok(mapper.Map<ProductReadDTO>(expectedProduct));
        }
    }
}
