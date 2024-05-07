﻿using System.Collections.Generic;

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

        public int Total
        {
            get
            {
                var total = 0;
                foreach (var group in ScannedItems)
                {
                    var sku = group.Key;
                    var number_of_items = group.Value;
                    total += Discounts.GetDiscountedPrice(sku, ref number_of_items);
                    total += number_of_items * Catalog.GetPriceForProduct(group.Key);
                }
                return total;
            }
        }
    }
}

