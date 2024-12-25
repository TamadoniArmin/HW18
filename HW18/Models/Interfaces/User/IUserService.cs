using HW18.Models.Entities;

namespace HW18.Models.Interfaces.Users
{
    public interface IUserService
    {
        bool Login(string username, string password);
        bool Register(string name,string family,string username,string password);
    }
}
