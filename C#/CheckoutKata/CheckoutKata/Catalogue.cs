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
            var discount = checkout.Catalogue.ProductDiscount(product, checkout);
            var discountThreshold = checkout.Catalogue.ProductDiscountThreshold(product, checkout);

            if (itemCount >= discountThreshold)
                return (itemCount / discountThreshold) * discount;

            return 0;
        }

        private int ProductDiscount(char product, Checkout checkout)
        {
            return checkout.DiscountLookup[product].Item2;
        }

        private int ProductDiscountThreshold(char product, Checkout checkout)
        {
            return checkout.DiscountLookup[product].Item1;
        }
    }
}