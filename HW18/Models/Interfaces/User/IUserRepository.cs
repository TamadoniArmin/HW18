using HW18.Models.Entities;

namespace HW18.Models.Interfaces.User
{
    public interface IUserRepository
    {
        bool Login(string username, string password);
        void Register(Entities.User user);
        Entities.User FindByUsername(string username);
    }
}
