using HW18.Models.Entities;
using HW18.Models.Infrestructure.Configuration;
using HW18.Models.Interfaces.Category;

namespace HW18.Models.Repositories
{
    public class CategoriesRepository : ICategoryRepository
    {
        AppDbContext _DbContext=new AppDbContext();
        public Category FindCategory(int id)
        {
            var category=_DbContext.Categories.FirstOrDefault(c => c.Id == id);
            return category;
        }

        public List<Category> Categories()
        {
            return _DbContext.Categories.ToList();
        }

    }
}
