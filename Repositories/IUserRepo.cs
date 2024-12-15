using EndPointParametersTask.Models;
using EndPointParametersTask.Controllers;

namespace EndPointParametersTask.Repositories
{
    public interface IUserRepo
    {
        void AddUser(User user);
        User GetUSer(string email, string password);
    }
}