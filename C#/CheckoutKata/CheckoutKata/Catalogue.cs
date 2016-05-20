using System.Collections.Generic;

namespace CheckoutKata
{
    public class Catalogue
    {
        private readonly Dictionary<char, Product> _products = 
            new Dictionary<char, Product>
            {
                ['A'] = new Product('A', 50, 30, 3),
                ['B'] = new Product('B', 30, 15, 2),
                ['C'] = new Product('C', 20),
                ['D'] = new Product('D', 15)
            };

        public int Price(char product) => _products[product].Price;

        public int CalculateProductDiscount(char product, int itemCount)
        {
            var discount = ProductDiscount(product);

            if (discount != null)
            {
                var discountThreshold = ProductDiscountThreshold(product).Value;

                if (itemCount >= discountThreshold)
                    return (itemCount / discountThreshold) * discount.Value;
            }

            return 0;
        }

        private int? ProductDiscount(char product) =>
            _products[product].DiscountValue;

        private int? ProductDiscountThreshold(char product) =>
            _products[product].DiscountThreshold;
    }
}