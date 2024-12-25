using HW18.Models.Entities;
using HW18.Models.Infrestructure.Configuration;
using HW18.Models.Interfaces.Products;
using Microsoft.EntityFrameworkCore;

namespace HW18.Models.Repositories
{
    public class ProductsRepository : IProductRepository
    {
        AppDbContext _dbContext= new AppDbContext();
        public List<Product> GetAllProducts()
        {
            return  _dbContext.Products.AsNoTracking().ToList();
        }
        public Product GetById(int id)
        {
            return _dbContext.Products.SingleOrDefault(x=>x.Id==id);
        }
        public void AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }
        public Category GetCategories(int id)
        {
            CategoriesRepository categoryRepository = new CategoriesRepository();
            var category =categoryRepository.FindCategory(id);
            return category;
        }

        public Product GetByName(string name)
        {
            var product=_dbContext.Products.FirstOrDefault(x=>x.Name==name);
            return product;
        }

        public List<Product> GetProductByCategory(int categoryId)
        {
            var products=_dbContext.Products.Where(x=>x.CategoryId==categoryId).ToList();
            return products;
        }
    }
}
