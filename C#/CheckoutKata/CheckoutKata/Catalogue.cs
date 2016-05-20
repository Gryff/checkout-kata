using System;
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
                ['C'] = new Product('C', 20, 0, 0),
                ['D'] = new Product('D', 15, 0, 0)
            };

        private readonly Dictionary<char, int> _catalogue =
            new Dictionary<char, int>
            {
                ['A'] = 50,
                ['B'] = 30,
                ['C'] = 20,
                ['D'] = 15
            };

        private readonly Dictionary<char, Tuple<int, int>> _discountLookup = 
            new Dictionary<char, Tuple<int, int>>
            {
                ['A'] = new Tuple<int, int>(3, 30),
                ['B'] = new Tuple<int, int>(2, 15)
            };

        public int Price(char product) => _products[product].Price;

        public int CalculateProductDiscount(char product, int itemCount)
        {
            var discount = ProductDiscount(product);
            var discountThreshold = ProductDiscountThreshold(product);

            if (itemCount >= discountThreshold)
                return (itemCount / discountThreshold) * discount;

            return 0;
        }

        private int ProductDiscount(char product) =>
            _products[product].DiscountValue;

        private int ProductDiscountThreshold(char product) =>
            _products[product].DiscountThreshold;
    }
}