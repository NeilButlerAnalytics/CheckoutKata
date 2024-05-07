
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
            // INCLUDE OUR NEW DISCOUNTS CATALOG AND SET THE PRICES OF OUR DISCOUNTS
            var discounts = new Discounts()
                    .DiscountProduct("A", 3, 130)
                    .DiscountProduct("B", 2, 45);
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