using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout
    {
        public Catalogue Catalogue { get; } = new Catalogue();

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
