using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Entity;

namespace Server.Services
{
    public interface ILoginRepository
    {
        Task<bool> getLoginTypes(string login_type);
        Task<List<Login_Types>> getLoginTypes();
        Task<bool> Save(Login_Types model);
    }
}