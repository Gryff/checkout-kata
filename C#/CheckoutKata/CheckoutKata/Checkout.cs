using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout
    {
        private readonly Catalogue _catalogue = new Catalogue();
        private readonly Dictionary<char, Tuple<int, int>> _discountLookup = 
            new Dictionary<char, Tuple<int, int>>
            {
                ['A'] = new Tuple<int, int>(3, 30),
                ['B'] = new Tuple<int, int>(2, 15)
            };

        public int CalculatePrice(string products)
        {
            int discount = CalculateDiscount(products);

            return products.Sum(_catalogue.Price) - discount;
        }

        private int CalculateDiscount(string products)
        {
            var result = 0;

            result += _catalogue.CalculateProductDiscount('A', products.Count(p => p == 'A'), this);
            result += _catalogue.CalculateProductDiscount('B', products.Count(p => p == 'B'), this);
            
            return result;
        }

        public int ProductDiscount(char product)
        {
            return _discountLookup[product].Item2;
        }

        public int ProductDiscountThreshold(char product)
        {
            return _discountLookup[product].Item1;
        }
    }
}
