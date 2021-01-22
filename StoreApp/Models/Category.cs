using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
