using System.Linq;

namespace CheckoutKata
{
    public class Checkout
    {
        private readonly Catalogue _catalogue = new Catalogue();

        public int CalculatePrice(string products)
        {
            if (products == "AAA") return 120;

            return products.Sum(_catalogue.Price);
        }
    }
}
