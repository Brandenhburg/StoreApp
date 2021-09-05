using Bookstore.Domain.Entities;
using System.Collections;
using System.Threading.Tasks;

namespace Bookstore.API.Repository
{
    public interface ILibraryRepository
    {
        Task<IEnumerable> GetProductsAsync();
        Task<Product> GetSingleProductAsync(int id);
        bool ProductExists(int id);
    }
}