using HW18.Models.Entities;
using HW18.Models.Infrestructure.Configuration;
using HW18.Models.Interfaces.User;

namespace HW18.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        AppDbContext _appDbContext= new AppDbContext();

        public User FindByUsername(string username)
        {
            var user = _appDbContext.Users.FirstOrDefault(x => x.Username == username);
            return user;
        }

        public bool Login(string username, string password)
        {
            var user= _appDbContext.Users.FirstOrDefault(x=>x.Username==username && x.Password==password);
            if (user is not null)
            {
                return true;
            }
            return false;
        }

        public void Register(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
        }
    }
}
