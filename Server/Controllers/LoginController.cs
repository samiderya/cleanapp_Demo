using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Entity;
using Server.Response;
using Server.Services;

namespace Server.Controllers
{
    [Route("api/login")]
    // [Controller]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        private readonly ILogger<LoginController> _logger;
        public LoginController(ILogger<LoginController> logger, ILoginRepository loginRepository)
        {
            this._logger = logger;
            _loginRepository = loginRepository ?? throw new ArgumentNullException(nameof(loginRepository));

        }
        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> getLoginType()
        {

            var response = new ListResponse<Login_Types>();
            try
            {
                var res = await _loginRepository.getLoginTypes();
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
        public async Task<IActionResult> Save([FromBody] Login_Types model)
        {

            var response = new Responses();
            try
            {
                var isExist = await _loginRepository.getLoginTypes(model.login_type);
                if (isExist)
                {
                    response.DidError = true;
                    response.ErrorMessage = $"{model.login_type} exist,Please try another LOGIN TYPE";
                    response.Message = $"{model.login_type} exist,Please try another LOGIN TYPE";
                }
                else
                {

                    response.DidError = false;
                    var res = await _loginRepository.Save(model);
                    if (res)
                    {
                        response.Message = "Login Type Successfully saved";
                    }
                    else
                    {
                        response.DidError = true;
                        response.ErrorMessage = "Please try again";
                    }

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