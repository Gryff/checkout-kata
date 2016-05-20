namespace CheckoutKata
{
    public class Catalogue
    {
        private readonly ProductRepository _products;

        public Catalogue(ProductRepository productRepository)
        {
            this._products = productRepository;
        }

        public int Price(char product) => _products.Find(product).Price;

        public int Discount(char productName, int itemCount)
        {
            var product = _products.Find(productName);

            return product.Discount(itemCount);
        }
    }
}