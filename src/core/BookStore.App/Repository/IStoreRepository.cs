using Bookstore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.App.Repository
{
    public interface IStoreRepository
    {
        IEnumerable<Product> GetFilteredProductsAsync(string category = null,
            decimal? minPrice = null, decimal? maxPrice = null);
        Task<IEnumerable<Product>> GetRandomProductsAsync();
        Task GetServices();
    }
}