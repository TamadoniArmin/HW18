using HW18.Models.Entities;

namespace HW18.Models.Interfaces.Products
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        public Product GetById(int id);
        public bool AddProduct(string name,int price,int Qty,int CategoryId);
        List<Product> GetProductByCategory(int categoryId);
    }
}
