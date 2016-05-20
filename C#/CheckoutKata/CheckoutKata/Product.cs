namespace CheckoutKata
{
    class Product
    {
        public char Name;
        public int Price;
        public int DiscountValue;
        public int DiscountThreshold;

        public Product(
            char name, int price, int discountValue, int discountThreshold)
        {
            this.Name = name;
            this.Price = price;
            this.DiscountValue = discountValue;
            this.DiscountThreshold = discountThreshold;
        }
    }
}
