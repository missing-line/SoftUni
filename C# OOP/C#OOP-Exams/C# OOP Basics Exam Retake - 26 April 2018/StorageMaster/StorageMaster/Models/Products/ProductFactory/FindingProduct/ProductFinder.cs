namespace StorageMaster.Models.Products.ProductFactory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class ProductFinder : IProductFinder
    {
        public Product FindProduct(List<Product> products, string name)
        {

            if (products.Any(x => x.GetType().Name == name))
            {
                Product product = products.Last(x => x.GetType().Name == name);//
                int index = products.LastIndexOf(product);
                products.RemoveAt(index);
                return product;
            }
            else
            {
                throw new InvalidOperationException($"{name} is out of stock!");
            }
        }
    }
}
