using HW18.Models.Entities;
using HW18.Models.Interfaces.Users;
using HW18.Models.Repositories;

namespace HW18.Models.Services
{
    public class UsersService : IUserService
    {
        UserRepository _usersRepository=new UserRepository();

        public bool Login(string username, string password)
        {
            return _usersRepository.Login(username, password);
        }

        public bool Register(string name, string family, string username, string password)
        {
            var user=_usersRepository.FindByUsername(username);
            if (user is null)
            {
                User user2 = (new User { Name = name, Family = family, Username = username, Password = password });
                _usersRepository.Register(user2);
                return true;
            }
            return false;
        }
    }
}
