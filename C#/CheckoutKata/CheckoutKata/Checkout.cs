using System.Linq;

namespace CheckoutKata
{
    public class Checkout
    {
        private readonly Catalogue _catalogue = 
            new Catalogue(new ProductRepository());

        public int CalculatePrice(string products)
        {
            return TotalBeforeDiscount(products) - Discount(products);
        }

        private int TotalBeforeDiscount(string products)
        {
            return products.Sum(_catalogue.Price);
        }

        private int Discount(string products)
        {
            return products
                .GroupBy(Identity)
                .Sum(ProductDiscount);
        }

        private char Identity(char p) => p;

        private int ProductDiscount(IGrouping<char, char> group) => 
            _catalogue.Discount(group.Key, group.Count());
    }
}
