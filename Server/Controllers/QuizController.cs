using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Entity;
using Server.Models.Dto;
using Server.Response;
using Server.Services;
using Newtonsoft.Json;

namespace Server.Controllers
{
    [Route("api/quiz")]
    // [Controller]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizRepository _quizRepository;
        private readonly ILogger<QuizController> _logger;
        public QuizController(ILogger<QuizController> logger, IQuizRepository quizRepository)
        {
            this._logger = logger;
            _quizRepository = quizRepository ?? throw new ArgumentNullException(nameof(quizRepository));

        }


        /// <summary>
        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetQuiz()
        {

            var response = new ListResponse<QuizDto>();
            try
            {
                var res = await _quizRepository.getQuiz();
                if (res == null)
                {
                    response.DidError = false;
                    response.ErrorMessage = "Data not found";
                }
                else
                {

                    response.DidError = false;
                    response.Model = res;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Stopped program because of exception");
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
                throw;

            }
            return response.ToHttpResponse();

        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Save([FromBody] List<QuizAnswerDto> model)
        {
            _logger.LogError("Quiz=" + JsonConvert.SerializeObject(model));
            var response = new Responses();
            try
            {
                var lstModel = new List<User_quiz_answer>();
                foreach (var item in model)
                {
                    var qent = new User_quiz_answer()
                    {
                        quiz_id = item.Qid,
                        answer_given = item.Qanswer.ToString(),
                        userid = item.userid
                    };
                    lstModel.Add(qent);
                }
                _logger.LogError("Quiz2=" + JsonConvert.SerializeObject(lstModel));
                var res = await _quizRepository.Save(lstModel);
                if (res)
                {
                    response.Message = "quiz Sucessfully Saved";
                }
                else
                {
                    response.DidError = true;
                    response.ErrorMessage = "Please try again quiz";
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Stopped program because of exception");
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
                throw;

            }
            return response.ToHttpResponse();

        }



    }
}