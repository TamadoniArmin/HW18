using HW18.Models.Entities;
using HW18.Models.Interfaces.Products;
using HW18.Models.Repositories;

namespace HW18.Models.Services
{
    public class ProductService : IProductService
    {
        ProductsRepository _productsRepository= new ProductsRepository();
        public bool AddProduct(string name, int price, int Qty, int CategoryId)
        {
            var product = _productsRepository.GetByName(name);
            if (product is null)
            {
                var category = _productsRepository.GetCategories(CategoryId);
                if (category != null)
                {
                    Product product2 = (new Product { Name = name, Price = price, Qty = Qty, CategoryId = category.Id});
                    _productsRepository.AddProduct(product2);
                    return true;
                }
            }
            return false;
        }

        public List<Product> GetAllProducts()
        {
            return _productsRepository.GetAllProducts();
        }

        public Product GetById(int id)
        {
            return _productsRepository.GetById(id);
        }

        public List<Product> GetProductByCategory(int categoryId)
        {
            return _productsRepository.GetProductByCategory(categoryId);
        }
    }
}
