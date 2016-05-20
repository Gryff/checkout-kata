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

            result += CalculateProductDiscount(products.Count(p => p == 'A'));

            if (products.Count(p => p == 'B') == discountThresholdForB) result += discountForB;

            return result;
        }

        private int CalculateProductDiscount(int itemCount)
        {
            var discountForA = 30;
            var discountThresholdForA = 3;

            var result = 0;

            if (itemCount == discountThresholdForA) result += discountForA;
            if (itemCount == 2*discountThresholdForA) result += 2*discountForA;

            return result;
        }
    }
}
