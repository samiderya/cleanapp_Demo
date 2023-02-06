using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Entity;
using Server.Helpers;
using Server.Models.Dto;
using Server.Response;
using Server.Services;
using Newtonsoft.Json;

namespace Server.Controllers
{
    [Route("api/backgroundcheck")]
    // [Controller]
    [ApiController]
    public class BackgroundcheckController : ControllerBase
    {
        private readonly IBackgroundRepository _backgroundRepository;
        private readonly ILogger<BackgroundcheckController> _logger;
        public BackgroundcheckController(ILogger<BackgroundcheckController> logger, IBackgroundRepository backgroundRepository)
        {
            this._logger = logger;
            _backgroundRepository = backgroundRepository ?? throw new ArgumentNullException(nameof(backgroundRepository));

        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Save([FromForm] BackgroundDto model)
        {
            _logger.LogError("BK=" + JsonConvert.SerializeObject(model));
            var response = new Responses();
            try
            {

                //Upload files
                var comm = new common();
                var fileNameID = comm.uploadfile(model.file_id, _logger);
                var fileNameSIN = comm.uploadfile(model.file_sin, _logger);
                var ent = new Background_check()
                {
                    userid = model.userid,
                    file_name_sin_no = fileNameSIN.Result,
                    file_name_idcard = fileNameID.Result
                };
                _logger.LogError("BK ENT=" + JsonConvert.SerializeObject(ent));
                var res = await _backgroundRepository.Save(ent);
                if (res)
                {
                    response.DidError = false;
                    response.Message = "Background Sucessfully Saved";
                }
                else
                {
                    response.DidError = true;
                    response.ErrorMessage = "error-Background Please try again";
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