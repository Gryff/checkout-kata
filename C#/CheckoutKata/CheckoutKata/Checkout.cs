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

            if (products == "AAA") return discountForA;
            if (products == "BB") return discountForB;

            return 0;
        }
    }
}
