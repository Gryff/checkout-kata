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
            var discountForB = 15;
            var discountThresholdForB = 2;
            var result = 0;

            result += CalculateProductDiscount('A', products.Count(p => p == 'A'));

            if (products.Count(p => p == 'B') == discountThresholdForB) result += discountForB;

            return result;
        }

        private int CalculateProductDiscount(char product, int itemCount)
        {
            if(product == 'A')
            {
                var discountForA = 30;
                var discountThresholdForA = 3;

                if (itemCount >= discountThresholdForA)
                    return (itemCount / discountThresholdForA) * discountForA;
            }

            if (product == 'B')
            {
                var discountForB = 15;
                var discountThresholdForB = 2;

                if (itemCount >= discountThresholdForB)
                    return (itemCount / discountThresholdForB) * discountForB;
            }
            return 0;
        }
    }
}
