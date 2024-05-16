using System;
using Xunit;
using Xunit.Abstractions;

namespace SupermarketCheckout.Tests
{
    public class CheckoutTests
    {
        private Checkout checkout;

        private readonly ITestOutputHelper output;

        public CheckoutTests(ITestOutputHelper output)
        {
            this.output = output; // Assign the parameter to the local field

            var catalog = new ProductCatalog()
                    .UpdateProductPrice("A", 50)
                    .UpdateProductPrice("B", 30)
                    .UpdateProductPrice("C", 20)
                    .UpdateProductPrice("D", 15);

            var discounts = new Discounts()
                    .DiscountProduct("A", 3, 130)
                    .DiscountProduct("B", 2, 45);
            checkout = new Checkout(catalog, discounts);

        }

        [Fact]
        // Check to see if we have any scanned item
        public void true_haveWeScanned()
        {
            checkout.Scan("A"); // Ensure you scan an item first
            bool result = checkout.isScan();
            Assert.True(result);
        }

        [Fact]
        // This should now fail as the cost of the shop has increased by 5p
        public void true_FindPriceOfItemA()
        {
            checkout.Scan("A");
            Assert.Equal(50, checkout.Total);
        }

        // This is the same test but with the correct price, this should return successfully
        // At the moment all other tests will fail as the prices to check against do not consider the extra cost for bags 
        // unlike the below test.
        [Fact]
        public void true_FindPriceOfItemAWithBag()
        {
            checkout.Scan("A");
            Assert.Equal(50.05, checkout.Total);
        }

        [Fact]
        public void calculateBagsNeeded_ReturnsCorrectNumberOfBags()
        {
            // Scan 12 items
            for (int i = 0; i < 12; i++)
            {
                checkout.Scan("A");
            }

            // Calculate bags needed
            int bagsNeeded = checkout.CalculateBagsNeeded();
            output.WriteLine($"Number of items: {12}, Bags needed: {bagsNeeded}");
            // Assert
            Assert.Equal(3, bagsNeeded); // 12 items should need 3 bags
        }

        [Fact]
        public void trueFindPriceOfItemB()
        {
            checkout.Scan("B");
            Assert.Equal(30, checkout.Total);
        }

        // This method is a parameterized test executed multiple times
        [Theory]
        [InlineData('A', 50)]
        [InlineData('B', 30)]
        [InlineData('C', 20)]
        [InlineData('D', 15)]
        public void trueFindPriceOfItem(string sku, int expected_total)
        {
            checkout.Scan(sku);
            Assert.Equal(expected_total, checkout.Total);
        }

        [Theory]
        [InlineData('A', 2, 100)]
        [InlineData('B', 1, 30)]
        [InlineData('C', 10, 200)]
        [InlineData('D', 5, 75)]
        public void trueFindPriceOfMultiples(string sku, int number_of_items, int expected_total)
        {
            checkout.Scan(sku, number_of_items);
            Assert.Equal(expected_total, checkout.Total);
        }

        [Theory]
        [InlineData('A', 3, 130)]
        [InlineData('B', 2, 45)]
        [InlineData('A', 7, 310)]
        [InlineData('B', 11, 255)]
        public void trueCalculateDiscounts(string sku, int number_of_items, int expected_total)
        {
            checkout.Scan(sku, number_of_items);
            Assert.Equal(expected_total, checkout.Total);
        }

        [Theory]
        [InlineData("AABCCDC", 205)]
        public void trueFindPriceForStream(string stream, int expected_total)
        {
            foreach (var sku in stream)
            {
                checkout.Scan("" + sku);
            }

            Assert.Equal(expected_total, checkout.Total);
        }
    }
}
