namespace StorageMaster.Models.Products.ProductFactory
{
    using StorageMaster.Models.Intefaces;
    using System;
    public class ProductFactory : IProductFactory
    {
        public IProduct CreateProduct(string type, double price)
        {
            IProduct product = null;
            switch (type)
            {
                case "Gpu":
                    product = new Gpu(price);
                    return product;
                case "HardDrive":
                    product = new HardDrive(price);
                    return product;
                case "Ram":
                    product = new Ram(price);
                    return product;
                case "SolidStateDrive":
                    product = new SolidStateDrive(price);
                    return product;
                default:
                    throw new InvalidOperationException("Invalid product type!");
            }
        }
    }
}
