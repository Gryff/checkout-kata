using System.Linq;

namespace CheckoutKata
{
    public class Checkout
    {
        private readonly Catalogue _catalogue = new Catalogue();

        public  int CalculatePrice(string products)
        {
            return products.Sum(_catalogue.Price);
        }
    }
}
