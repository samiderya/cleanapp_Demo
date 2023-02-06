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
    [Route("api/general")]
    // [Controller]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private readonly IGeneralRepository _generalRepository;
        private readonly ILogger<GeneralController> _logger;
        public GeneralController(ILogger<GeneralController> logger, IGeneralRepository generalRepository)
        {
            this._logger = logger;
            _generalRepository = generalRepository ?? throw new ArgumentNullException(nameof(generalRepository));

        }


        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Save([FromBody] List<GeneralDto> model)
        {
            _logger.LogError("WorkExp=" + JsonConvert.SerializeObject(model));
            var response = new Responses();
            try
            {
                var lstModel = new List<General_info_answer>();
                foreach (var item in model)
                {
                    var qent = new General_info_answer()
                    {
                        quation_id = item.Qid,
                        answer = item.Qanswer,
                        userid = item.userid
                    };
                    lstModel.Add(qent);
                }

                var res = await _generalRepository.Save(lstModel);
                if (res)
                {
                    response.Message = "Work experiance Sucessfully Saved";
                }
                else
                {
                    response.DidError = true;
                    response.ErrorMessage = "Please try again,Work experiance";
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