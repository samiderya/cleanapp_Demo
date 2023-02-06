using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Entity;
using Server.Models.Dto;

namespace Server.Services
{
    public interface IAgentRepository
    {
        Task<List<AgentDto>> getAgentNearest(double latitude, double longitude);
        Task<int> Save(Agent model);
        Task<bool> SaveAgentUser(Agent_Users model);
        Task<Agent> Update(Agent model);
        Task<List<Agent>> getAll();


    }
}