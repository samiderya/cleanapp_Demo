using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Entity;
using Server.Models.Dto;

namespace Server.Services
{
    public interface IQuizRepository
    {
        Task<List<QuizDto>> getQuiz();
        Task<bool> Save(List<User_quiz_answer> model);

    }
}