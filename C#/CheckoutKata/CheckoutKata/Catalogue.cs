using System;
using System.Collections.Generic;

namespace CheckoutKata
{
    public class Catalogue
    {
        private List<Product> _products = new List<Product>
        {
            new Product {Name = 'A', Price = 50, DiscountValue = 30, DiscountThreshold = 3},
            new Product {Name = 'B', Price = 30, DiscountValue = 15, DiscountThreshold = 2},
            new Product {Name = 'C', Price = 20},
            new Product {Name = 'D', Price = 15}
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

        public int Price(char product) => _catalogue[product];

        public int CalculateProductDiscount(char product, int itemCount)
        {
            var discount = ProductDiscount(product);
            var discountThreshold = ProductDiscountThreshold(product);

            if (itemCount >= discountThreshold)
                return (itemCount / discountThreshold) * discount;

            return 0;
        }

        private int ProductDiscount(char product) =>
            _discountLookup[product].Item2;

        private int ProductDiscountThreshold(char product) =>
            _discountLookup[product].Item1;
    }
}