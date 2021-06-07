using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace StoreApp.Data.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly StoreDbContext context;

        public StoreRepository(StoreDbContext context)
        {
            this.context = context;
        }

        public  async Task<IEnumerable<Product>> GetFilteredProductsAsync(string categoryName = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            IQueryable<Product> Products = context.Products.Include(a => a.Authors);

            //Products = context.Products.FromSqlRaw("sp_GetProductsByCategory @CategoryName", categoryName);
            //await context.Database.OpenConnectionAsync();
            if (categoryName is not null)
            {
                Products = Products.Where(c => c.Categories.Name == categoryName);
            }
            
            if (minPrice is not null)
            {
                Products = Products.Where(p => p.Price >= minPrice);
            }

            if (maxPrice is not null)
            {
                Products = Products.Where(p => p.Price <= maxPrice);
            }

            return await Products.ToListAsync();
        }

        public async Task GetServices()
        {
            await context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetRandomProductsAsync()
        {

            Product[] randomList = new Product[5];

            for (int i = 0; i < randomList.Length; i++)
            {
                Product randomPr = await context.Products.FindAsync(RandomNumberGenerator.GetInt32(1, context.Products.Count()));

                while(randomList.Contains(randomPr))
                {
                    randomPr = await context.Products.FindAsync(RandomNumberGenerator.GetInt32(1, context.Products.Count()));
                }
                randomList[i] = randomPr;
            }


            //List<Product> randomProducts = new List<Product>(4);

            //for (int i = 0; i < 4; i++)
            //{
            //    Product randomProduct = await context.Products.FindAsync(RandomNumberGenerator.GetInt32(1, context.Products.Count()));

            //    while (randomProducts.Contains(randomProduct))
            //    {
            //       randomProduct = await context.Products.FindAsync(RandomNumberGenerator.GetInt32(1, context.Products.Count()));
            //    }

            //    randomProducts.Add(randomProduct);


            //    //int randomProductId = RandomNumberGenerator.GetInt32(1, context.Products.Count());
            //    //while (randomProducts.Contains(await context.Products.FindAsync(randomProductId)))
            //    //{
            //    //    randomProductId = RandomNumberGenerator.GetInt32(1, context.Products.Count());
            //    //}
            //    //randomProducts.Add(context.Products.Find(randomProductId));
            //}

            return randomList;
        }
    }
}
