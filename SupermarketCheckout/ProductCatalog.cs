using System.Collections.Generic;
using System.Linq;

namespace SupermarketCheckout
{
    public class ProductCatalog
    {
        private List<Product> catalog = new List<Product>();

        public ProductCatalog UpdateProductPrice(string sku, int price)
        {
            this.catalog.RemoveAll(x => x.Sku == sku);
            this.catalog.Add(new Product(sku, price));
            return this;
        }

    }

   
}
