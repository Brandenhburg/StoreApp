using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public int Categoryid { get; set; }
        public Category Categories { get; set; }
        public int AuthorId { get; set; }
        public Author Authors { get; set; }

    }
}
