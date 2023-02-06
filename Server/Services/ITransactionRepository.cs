using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Entity;

namespace Server.Services
{
    public interface ITransactionRepository
    {
        Task<List<Transactions>> getTransactionByUserId(short userId);
        Task<bool> Save(Transactions model);
    }
}