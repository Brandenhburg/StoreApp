using System.Collections.Generic;

namespace Bookstore.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }


        public List<Category> Categories { get; set; } = new List<Category>();
        //public int Categoryid { get; set; }
        //public Category Categories { get; set; }
        public int AuthorId { get; set; }
        public Author Authors { get; set; }
    }
}
