
using Xunit;

namespace SupermarketCheckout.Tests
{
    public class CheckoutTests
    {
        // THIS WILL INITIALLY FAIL - BUILD ERRORS EXPECTED

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