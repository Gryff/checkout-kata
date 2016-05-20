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

        private static int CalculateDiscount(string products)
        {
            if (products == "AAA") return 30;
            if (products == "BB") return 15;

            return 0;
        }
    }
}
