using System.Collections.Generic;

namespace Bookstore.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public List<Author> Authors { get; set; } = new List<Author>();
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
