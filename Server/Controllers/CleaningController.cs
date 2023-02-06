using System;
using System.Collections.Generic;
using System.IO;
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
    [Route("api/cleaning")]
    // [Controller]
    [ApiController]
    public class CleaningController : ControllerBase
    {
        private readonly ICleaningRepository _cleaningRepository;
        private readonly ILogger<CleaningController> _logger;
        public CleaningController(ILogger<CleaningController> logger, ICleaningRepository cleaningRepository)
        {
            this._logger = logger;
            _cleaningRepository = cleaningRepository ?? throw new ArgumentNullException(nameof(cleaningRepository));

        }

        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> getAll()
        {

            var response = new ListResponse<Cleaning_type>();
            try
            {
                var res = await _cleaningRepository.getAll();
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
        public async Task<IActionResult> Save([FromForm] CleaningTypeDto model)
        {

            var response = new Responses();
            try
            {
                var isExist = await _cleaningRepository.getCleaningTypes(model.cleaning_type);
                if (isExist)
                {
                    response.DidError = true;
                    response.ErrorMessage = $"{model.cleaning_type} with name exist,Please try another";
                    response.Message = $"{model.cleaning_type} with name exist,Please try another";
                }
                else
                {

                    response.DidError = false;
                    var uploadDirecotroy = "uploads/";
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), uploadDirecotroy);
                    //_logger.LogError($"uploadPath={uploadPath}");

                    if (!Directory.Exists(uploadPath))
                        Directory.CreateDirectory(uploadPath);

                    var fileName = Guid.NewGuid() + Path.GetExtension(model.file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), uploadDirecotroy, fileName);

                    if (model.file.Length > 0)
                    {

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await model.file.CopyToAsync(fileStream);
                        }
                    }
                    var ent = new Cleaning_type()
                    {
                        cleaning_type = model.cleaning_type,
                        imgName = fileName,
                        created_by = model.created_by
                    };
                    var res = await _cleaningRepository.Save(ent);
                    if (res)
                    {
                        response.Message = "cleaning type Sucessfully Saved";
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


        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CleaningDetailSave([FromBody] CleaningDetailDto model)
        {

            var response = new Responses();
            try
            {

                response.DidError = false;
                var ent = new Cleaning_details()
                {
                    cleaning_typeid = model.cleaning_typeid,
                    min_hour = model.total_hour,
                    package_typeid = model.package_typeid,
                    employee_no = model.total_employee,
                    agentid = model.agentid.Value,
                    due_date = model.due_date,
                    created_at = DateTime.Now,
                    is_active = 1,
                    transactionid = 0,
                    agent_rateid = 0
                };
                var res = await _cleaningRepository.CleaningDetailSave(ent);
                response.Id=res;
                if (res!=0)
                {
                    response.Message = "cleaning details Sucessfully Saved";
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

            /// <summary>
        [Route("[action]/{agentid}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetCleaningHistory(int agentid)
        {

            var response = new ListResponse<Cleaning_details>();
            try
            {
                var res = await _cleaningRepository.GetCleaningHistory(agentid);
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