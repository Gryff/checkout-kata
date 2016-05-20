using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class ProductRepository
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product('A', 50, 30, 3),
            new Product('B', 30, 15, 2),
            new Product('C', 20, 0, 0),
            new Product('D', 15, 0, 0)
        };

        public Product Find(char product) =>
            _products.First(p => p.Name == product);
    }
}
