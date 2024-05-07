using System.Collections.Generic;
using System.Linq;

namespace SupermarketCheckout
{
    public class Discount
    {
        public Discount (string sku, int numberOfItems, int priceOfPackage)
        {
            this.Sku = sku;
            this.NumberOfItems = numberOfItems;
            this.PackagePrice = priceOfPackage;
        }

        public readonly string Sku;
        public readonly int NumberOfItems;
        public readonly int PackagePrice;
    }

    public class Discounts
    {
        private List<Discount> discounts = new List<Discount>();

    }
}
