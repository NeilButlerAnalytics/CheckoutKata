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
        public Discounts DiscountProduct(string sku, int numberOfItems, int priceOfPackage)
        {
            this.discounts.RemoveAll(x => x.Sku == sku);
            this.discounts.Add(new Discount(sku, numberOfItems, priceOfPackage));
            return this;
        }

        public int GetDiscountedPrice(string sku, ref int ItemsToCalculate)
        {
            var discount = this.discounts.Where(x => x.Sku == sku).FirstOrDefault();
            //WE HAVE NOT FOUND A DISCOUNTED PRICE FOR THIS PRODUCT
            if (discount == null) return 0; 

            var discountedPrice = (ItemsToCalculate / discount.NumberOfItems) * discount.PackagePrice;


            ItemsToCalculate = ItemsToCalculate % discount.NumberOfItems;

            return discountedPrice;
        }

    }
}
