using System.Collections.Generic;

/****** INITIAL CREATE OF THE CHECKOUT CLASS AND OBJECT *********/

namespace SupermarketCheckout
{
    public class Checkout
    {
        public Checkout()
        {
            this.ScannedItems = new Dictionary<string, int>();
        }

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
// Find the total cost
                }
                return total;
            }
        }
    }
}

