using HW18.Models.Entities;

namespace HW18.Models.Interfaces.Products
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetById(int id);
        Product GetByName(string name);
        Entities.Category GetCategories(int id);
        void AddProduct(Product product);
        List<Product> GetProductByCategory(int  categoryId);
    }
}
