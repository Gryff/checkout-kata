namespace CheckoutKata
{
    public abstract class Product
    {
        private readonly char _name;

        public int Price { get; }

        protected Product(char name, int price)
        {
            _name = name;
            Price = price;
        }

        public abstract int Discount(int itemCount);

        public bool Matches(char product)
        {
            return _name == product;
        }
    }

    internal class ProductWithoutDiscount : Product
    {
        public ProductWithoutDiscount(char name, int price) : base(name, price)
        {
        }

        public override int Discount(int itemCount)
        {
            return 0;
        }
    }

    public class ProductWithDiscount : Product
    {
        private readonly int _discountValue;
        private readonly int _discountThreshold;

        public ProductWithDiscount(char name, int price, int discountValue, int discountThreshold) : base(name, price)
        {
            _discountValue = discountValue;
            _discountThreshold = discountThreshold;
        }

        public override int Discount(int itemCount)
        {
            return (itemCount / _discountThreshold) * _discountValue;
        }
    }
}
