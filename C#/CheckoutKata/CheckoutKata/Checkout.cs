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

            var result = 0;

            if (products.Count(p => p == 'A') == 3) result += discountForA;
            if (products.Count(p => p == 'B') == 2) result += discountForB;

            return result;
        }
    }
}
