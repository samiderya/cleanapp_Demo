using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Entity;

namespace Server.Services
{
    public interface ICleaningRepository
    {
        Task<bool> getCleaningTypes(string cleaning_type);
        Task<List<Cleaning_type>> getAll();
        Task<bool> Save(Cleaning_type model);

        Task<int> CleaningDetailSave(Cleaning_details model);
        Task<List<Cleaning_details>> GetCleaningHistory(int id);
    }
}