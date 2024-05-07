
using Xunit;

namespace SupermarketCheckout.Tests
{
    public class CheckoutTests
    {
        public CheckoutTests()
        {
            // INCLUDE OUR NEW PRODUCTCATALOG AND SET THE PRICES OF OUR PRODUCTS
            var catalog = new ProductCatalog()
                    .UpdateProductPrice("A", 50)
                    .UpdateProductPrice("B", 30)
                    .UpdateProductPrice("C", 20)
                    .UpdateProductPrice("D", 15);
            checkout = new Checkout();
        }

        Checkout checkout;
        [Fact]
        public void true_FindPriceOfItemA()
        {
            // Assume we create an object called 'checkout' as part of our code                                               
            checkout.Scan("A");
            
            // within checkout we will retrieve the price of the product and compare
            Assert.Equal(50, checkout.Total);
        }

        [Fact]
        public void trueFindPriceOfItemB()
        {
            // Assume we create an object called 'checkout' as part of our code                                                           
            checkout.Scan("B");

            // within checkout we will retrieve the price of the product and compare                                                         
            Assert.Equal(30, checkout.Total);
        }


    }
}                                                                           