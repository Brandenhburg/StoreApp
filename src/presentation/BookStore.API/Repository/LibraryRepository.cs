using Bookstore.Data.Contexts;
using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.API.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly BookStoreDbContext contenxt;

        public LibraryRepository(BookStoreDbContext context)
        {
            this.contenxt = context;
        }

        public async Task<IEnumerable> GetProductsAsync()
        {
            return await contenxt.Products.ToListAsync();
        }

        public async Task<Product> GetSingleProductAsync(int id)
        {
            return await contenxt.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public bool ProductExists(int id)
        {
            return contenxt.Products.Any(p => p.ProductId == id);
        }
    }
}
