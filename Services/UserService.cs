using EndPointParametersTask.Models;
using EndPointParametersTask.Repositories;
using EndPointParametersTask.Controllers;
using EndPointParametersTask.Repositories;

namespace WebApplication4.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userrepo;

        public UserService(IUserRepo userrepo)
        {
            _userrepo = userrepo;
        }


        public void AddUser(User user)
        {

            _userrepo.AddUser(user);
        }

        public User GetUser(string email, string password)
        {
            return _userrepo.GetUSer(email, password);

        }


    }
}
