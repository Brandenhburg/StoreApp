using StoreApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Data.Repository
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Product>> GetFilteredProductsAsync(string category = null,
            decimal? minPrice = null, decimal? maxPrice = null);
        Task<IEnumerable<Product>> GetRandomProductsAsync();
        Task GetServices();
    }
}