
using Xunit;

namespace SupermarketCheckout.Tests
{
    public class CheckoutTests
    {
        public CheckoutTests()
        {

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

        Checkout checkout;
        [Fact]
        public void true_FindPriceOfItemA()
        {                                      
            checkout.Scan("A");
            
            Assert.Equal(50, checkout.Total);
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