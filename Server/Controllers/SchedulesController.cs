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
    [Route("api/schedules")]
    // [Controller]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<SchedulesController> _logger;
        public SchedulesController(ILogger<SchedulesController> logger, IUserRepository userRepository)
        {
            this._logger = logger;
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

        }


        /// <summary>
        [Route("[action]/{email}/{password}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> AuthenticateUser(string email, string password)
        {
            _logger.LogInformation(string.Format($"email={email},password={password}"));
            var response = new SingleResponse<Users>();
            try
            {
                var res = await _userRepository.getAccount(email, password);
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
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> getUsers()
        {

            var response = new ListResponse<Users>();
            try
            {
                var res = await _userRepository.getUsers();
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
        
    }
}