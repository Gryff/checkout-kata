namespace CheckoutKata
{
    public class Catalogue
    {
        private readonly ProductRepository _products = new ProductRepository();
        
        public int Price(char product) => _products.Find(product).Price;

        public int Discount(char product, int itemCount)
        {
            if (!_products.Find(product).HasDiscount()) return 0;

            var discount = ProductDiscount(product);
            var discountThreshold = ProductDiscountThreshold(product);

            if (itemCount >= discountThreshold)
                return (itemCount/discountThreshold)*discount;

            return 0;
        }

        private int ProductDiscount(char product) =>
            _products.Find(product).DiscountValue;

        private int ProductDiscountThreshold(char product) =>
            _products.Find(product).DiscountThreshold;
    }
}