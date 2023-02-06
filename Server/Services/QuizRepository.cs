using System;
using Server.Contexts;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Entity;
using Microsoft.EntityFrameworkCore;
using Server.Helpers;
using Server.Models.Dto;

namespace Server.Services
{
    public class QuizRepository : IQuizRepository, IDisposable
    {
        private CleanerDBContext _context;

        public QuizRepository(CleanerDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        // public async Task<List<Users>> getQuiz()
        // {
        //     // var res = (from q in _context.Quiz
        //     //            join qc in _context.Quiz_Choices
        //     //            on q.Id equals qc.quiz_id
        //     //            select q);
        //     return await _context.Users.ToListAsync();
        // }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<List<QuizDto>> getQuiz()
        {
            try
            {
                var result = _context.Quiz.Select(Dto =>
                  new QuizDto()
                  {
                      Id = Dto.Id,
                      quation_no = Dto.quation_no,
                      quation = Dto.quation,
                      ListChoice = _context.Quiz_Choices.Where(x => x.quiz_id == Dto.Id).ToList()
                  }

                );
                return result.ToListAsync();

            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        public async Task<bool> Save(List<User_quiz_answer> model)
        {
            try
            {

                await _context.User_Quiz_Answers.AddRangeAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }


    }
}