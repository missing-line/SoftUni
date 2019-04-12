namespace StorageMaster.Models.Products.ProductFactory
{
    using StorageMaster.Models.Intefaces;
    public interface IProductFactory
    {
        IProduct CreateProduct(string type, double price);
    }
}
