using System;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketCheckout
{
    public class Checkout
    {
        public Checkout(ProductCatalog catalog, Discounts discounts)
        {
            this.Catalog = catalog;
            this.Discounts = discounts;
            this.ScannedItems = new Dictionary<string, int>();
        }

        private readonly ProductCatalog Catalog;
        private readonly Discounts Discounts;
        private readonly Dictionary<string, int> ScannedItems;

        public void Scan(string sku, int times = 1)
        {
            if (ScannedItems.ContainsKey(sku))
            {
                ScannedItems[sku] += times;
            }
            else
            {
                ScannedItems.Add(sku, times);
            }
        }
        // The total has been amended to simply calculate the addition of bags. Using the calculation we discussed
        // we simply update the total by appending the number of items /5, encase that in Math.Ceiling, then multiple that integer
        // by 0.05 to give us the total amount of cost for the bags.
        // So if customer bought 13 of product 'A' then the total will be 50*13 = 650, 13/5 = 2.6 (round up) = 3, 3*0.05 = 0.15
        // So 650 + 0.15 = 650.15 (15 pence extra for the bags.
        // I also changed the 'total' variable and the return type to a double rather than an int
        public double Total
        {
            get
            {
                double total = 0;
                foreach (var group in ScannedItems)
                {
                    var sku = group.Key;
                    var number_of_items = group.Value;
                    total += Discounts.GetDiscountedPrice(sku, ref number_of_items);
                    total += number_of_items * Catalog.GetPriceForProduct(group.Key);
                    total += (Math.Ceiling((number_of_items / 5.0)))*0.05;
                }
                return total;
            }
        }
        public int CalculateBagsNeeded()
        {
            // Calculate the total number of items requiring bags by summing up the quantities of all items scanned
            int totalItemsRequiringBags = ScannedItems.Sum(item => item.Value);

            // Calculate the number of bags needed based on the total number of items requiring bags
            return (int)Math.Ceiling((double)totalItemsRequiringBags / 5);
        }

        // This is the isScan method that I wanted to just return a boolean. Over thought it... obviously the 'Any' LINQ
        // will return true if it finds anything in Scanned Items
        public bool isScan()
        {
            return ScannedItems.Any();

        }
    }
}

