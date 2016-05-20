using NUnit.Framework;

namespace CheckoutKata
{
    [TestFixture]
    class CheckoutShould
    {
        private Checkout _checkout;

        [SetUp]
        public void SetUp()
        {
            _checkout = new Checkout();
        }

        [Test]
        public void ReturnZeroGivenAnEmptyString()
        {
            var price = _checkout.CalculatePrice("");

            Assert.That(price, Is.EqualTo(0));
        }

        [TestCase("A", 50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 15)]
        public void PriceSingleProduct(string products, int expected)
        {
            var price = _checkout.CalculatePrice(products);

            Assert.That(price, Is.EqualTo(expected));
        }

        [TestCase("AB", 80)]
        [TestCase("ABC", 100)]
        [TestCase("ABCD", 115)]
        [TestCase("ABCDACD", 200)]
        public void PriceCombinationsOfProducts(string products, int expected)
        {
            var price = _checkout.CalculatePrice(products);

            Assert.That(price, Is.EqualTo(expected));
        }

        [TestCase("AAA", 120)]
        [TestCase("BB", 45)]
        [TestCase("AAABB", 165)]
        [TestCase("AAABBAAA", 285)]
        public void PriceDiscountsOnMultipleProducts(string products, int expected)
        {
            var price = _checkout.CalculatePrice(products);

            Assert.That(price, Is.EqualTo(expected));
        }
    }
}
