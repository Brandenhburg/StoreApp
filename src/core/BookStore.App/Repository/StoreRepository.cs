using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Bookstore.Domain.Entities;
using Bookstore.Data.Contexts;

namespace Bookstore.App.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly BookStoreDbContext context;

        public StoreRepository(BookStoreDbContext context)
        {
            this.context = context;
        }

        public   IEnumerable<Product> GetFilteredProductsAsync(string categoryName = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            IQueryable<Product> products = context.Products.Include(a => a.Authors);

            if (categoryName is not null)
            {
                products = products.Where(p => p.Categories.Any(c => c.Name == categoryName));
            }
            
            if (minPrice is not null)
            {
                products = products.Where(p => p.Price >= minPrice);
            }

            if (maxPrice is not null)
            {
                products = products.Where(p => p.Price <= maxPrice);
            }

            return products;
        }

        public async Task GetServices()
        {
            await context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetRandomProductsAsync()
        {

            Product[] randomList = new Product[5];
            var products = await context.Products.ToArrayAsync();


            for (int i = 0; i < randomList.Length; i++)
            {
                var randomPr = products[RandomNumberGenerator.GetInt32(0, products.Length - 1)];

                while(randomList.Contains(randomPr))
                {
                    randomPr = products[RandomNumberGenerator.GetInt32(0, products.Length - 1)];
                }

                randomList[i] = randomPr;
            }

            return randomList;
        }
    }
}
