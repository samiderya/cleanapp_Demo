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

namespace Server.Controllers
{
    [Route("api/rate")]
    // [Controller]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IRateRepository _rateRepository;
        private readonly ILogger<RateController> _logger;
        public RateController(ILogger<RateController> logger, IRateRepository rateRepository)
        {
            this._logger = logger;
            _rateRepository = rateRepository ?? throw new ArgumentNullException(nameof(rateRepository));

        }


        /// <summary>
        [Route("[action]/{userId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> getRateByUserId(short userId)
        {

            var response = new ListResponse<Star_rate_detail>();
            try
            {
                var res = await _rateRepository.getRateByUserId(userId);
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
        public async Task<IActionResult> getAllRates()
        {

            var response = new ListResponse<Star_rate_detail>();
            try
            {
                var res = await _rateRepository.getAllRates();
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
        public async Task<IActionResult> RateStarSave([FromBody] StarRateDetailDto model)
        {

            var response = new Responses();
            try
            {

                response.DidError = false;
                var ent = new Server.Entity.Star_rate_detail()
                {
                    star_rate = model.star_rate,
                    user_id = model.userid,
                    user_type_id = model.user_type_id,
                    service_type_id = model.service_type_id,
                    service_detail_id = model.service_detail_id,
                    review_descriptions = model.review_descriptions
                };
                var res = await _rateRepository.RateStarSave(ent);
                if (res)
                {
                    response.Message = "Star_rate_detail Sucessfully Saved";
                }
                else
                {
                    response.DidError = true;
                    response.ErrorMessage = "Please try again";
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