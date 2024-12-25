using HW18.Models.Entities;

namespace HW18.Models.Interfaces.Category
{
    public interface ICategoryRepository
    {
        Entities.Category FindCategory(int id);
        List<Entities.Category> Categories();
    }
}
