using System.Collections.Generic;

namespace CheckoutKata
{
    public class Catalogue
    {
        private readonly Dictionary<char, int> _catalogue =
            new Dictionary<char, int>
            {
                ['A'] = 50,
                ['B'] = 30,
                ['C'] = 20,
                ['D'] = 15
            };

        public int Price(char product)
        {
            return _catalogue[product];
        }

        public int CalculateProductDiscount(char product, int itemCount, Checkout checkout)
        {
            var discount = checkout.ProductDiscount(product);
            var discountThreshold = checkout.ProductDiscountThreshold(product);

            if (itemCount >= discountThreshold)
                return (itemCount / discountThreshold) * discount;

            return 0;
        }
    }
}