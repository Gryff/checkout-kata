using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout
    {
        private readonly Catalogue _catalogue = new Catalogue();

        public int CalculatePrice(string products)
        {
            int discount = CalculateDiscount(products);

            return products.Sum(_catalogue.Price) - discount;
        }

        private int CalculateDiscount(string products)
        {
            var result = 0;

            result += _catalogue.CalculateProductDiscount('A', products.Count(p => p == 'A'));
            result += _catalogue.CalculateProductDiscount('B', products.Count(p => p == 'B'));
            
            return result;
        }
    }
}
