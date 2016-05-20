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

            result += CalculateProductDiscount('A', products.Count(p => p == 'A'));
            result += CalculateProductDiscount('B', products.Count(p => p == 'B'));
            
            return result;
        }

        private int CalculateProductDiscount(char product, int itemCount)
        {
            var discount = ProductDiscount(product);
            var discountThreshold = ProductDiscountThreshold(product);

            if (itemCount >= discountThreshold)
                return (itemCount / discountThreshold) * discount;

            return 0;
        }

        private int ProductDiscount(char product)
        {
            return _discountLookup[product].Item2;
        }

        private int ProductDiscountThreshold(char product)
        {
            return _discountLookup[product].Item1;
        }
    }
}
