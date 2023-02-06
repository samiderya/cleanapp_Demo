using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Entity;

namespace Server.Services
{
    public interface IRateRepository
    {
        Task<List<Star_rate_detail>> getAllRates();
        Task<List<Star_rate_detail>> getRateByUserId(short userId);
        Task<bool> RateStarSave(Star_rate_detail model);


    }
}