using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Entity;
using Server.Models.Dto;

namespace Server.Services
{
    public interface IGeneralRepository
    {
        Task<bool> Save(List<General_info_answer> model);
    }
}