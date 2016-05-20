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
            var discountForA = 30;
            var discountForB = 15;
            var discountThresholdForA = 3;
            var discountThresholdForB = 2;

            var result = 0;

            var countForA = products.Count(p => p == 'A');

            if (countForA == discountThresholdForA) result += discountForA;
            if (countForA == 2 * discountThresholdForA) result += 2 * discountForA;
            if (products.Count(p => p == 'B') == discountThresholdForB) result += discountForB;

            return result;
        }
    }
}
