namespace CheckoutKata
{
    public class Product
    {
        public char Name;
        public int Price;
        private readonly int _discountValue;
        private readonly int _discountThreshold;

        public Product(
            char name, int price, int discountValue, int discountThreshold)
        {
            this.Name = name;
            this.Price = price;
            this._discountValue = discountValue;
            this._discountThreshold = discountThreshold;
        }

        public int Discount(int itemCount)
        {
            if (_discountValue != 0 && itemCount >= _discountThreshold)
                return (itemCount / _discountThreshold) * _discountValue;

            return 0;
        }
    }
}
