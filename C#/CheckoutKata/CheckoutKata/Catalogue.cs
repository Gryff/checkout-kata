namespace CheckoutKata
{
    public class Catalogue
    {
        private readonly ProductRepository _products = new ProductRepository();

        public int Price(char product) => _products.Find(product).Price;

        public int Discount(char productName, int itemCount)
        {
            var product = _products.Find(productName);
            if (!product.HasDiscount()) return 0;

            if (itemCount >= product.DiscountThreshold)
                return (itemCount/product.DiscountThreshold)*product.DiscountValue;

            return 0;
        }
    }
}