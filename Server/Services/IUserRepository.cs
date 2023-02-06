using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Entity;

namespace Server.Services
{
    public interface IUserRepository
    {
        Task<Users> getAccount(string email, string password);
        Task<List<Users>> getUsers();
        Task<Users> getUserName(string email);
        Task<List<Users>> getUsersByService(char serviceId);
        Task<Users> Register(Users model);
        Task<Users> Update(Users model);

    }
}