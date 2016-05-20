using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout
    {
        public Catalogue Catalogue { get; } = new Catalogue();

        public Dictionary<char, Tuple<int, int>> DiscountLookup { get; } = new Dictionary<char, Tuple<int, int>>
        {
            ['A'] = new Tuple<int, int>(3, 30),
            ['B'] = new Tuple<int, int>(2, 15)
        };

        public int CalculatePrice(string products)
        {
            int discount = CalculateDiscount(products);

            return products.Sum(Catalogue.Price) - discount;
        }

        private int CalculateDiscount(string products)
        {
            var result = 0;

            result += Catalogue.CalculateProductDiscount('A', products.Count(p => p == 'A'), this);
            result += Catalogue.CalculateProductDiscount('B', products.Count(p => p == 'B'), this);
            
            return result;
        }
    }
}
