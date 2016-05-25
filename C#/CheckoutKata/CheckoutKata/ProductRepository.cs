using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class ProductRepository
    {
        private readonly List<Product> _products = new List<Product>
        {
            new ProductWithDiscount('A', 50, 30, 3),
            new ProductWithDiscount('B', 30, 15, 2),
            new ProductWithoutDiscount('C', 20),
            new ProductWithoutDiscount('D', 15)
        };

        public Product Find(char product)
        {
            return _products.First(p => p.Matches(product));
        }
    }
}
