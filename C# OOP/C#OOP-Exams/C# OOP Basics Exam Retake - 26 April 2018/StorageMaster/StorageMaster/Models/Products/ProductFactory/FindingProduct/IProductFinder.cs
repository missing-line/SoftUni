using StorageMaster.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Products.ProductFactory
{
    public interface IProductFinder
    {
        Product FindProduct(List<Product> products, string name);
               
    }
}
