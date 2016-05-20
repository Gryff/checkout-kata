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

            if (products.Contains("AAA")) result+= discountForA;
            if (products.Contains("BB")) result += discountForB;

            return result;
        }
    }
}
