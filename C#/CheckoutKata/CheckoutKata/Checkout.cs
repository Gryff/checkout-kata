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
            return products
                .Distinct()
                .Sum(product => _catalogue.CalculateProductDiscount(
                    product, products.Count(p => p == product)));
        }
    }
}
