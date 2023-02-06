using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Entity;
using Server.Models.Dto;

namespace Server.Services
{
    public interface IBackgroundRepository
    {
        // Task<List<QuizDto>> getQuiz();
        Task<bool> Save(Background_check model);

    }
}