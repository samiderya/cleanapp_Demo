using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Server.Entity;
using Server.Helpers;
using Server.Models.Dto;
using Server.Response;
using Server.Services;

namespace Server.Controllers
{
    [Route("api/account")]
    // [Controller]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AccountController> _logger;
        private IHostingEnvironment _Environment;
        public AccountController(ILogger<AccountController> logger, IUserRepository userRepository, IHostingEnvironment Environment)
        {
            this._logger = logger;
            this._Environment = Environment;
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
            }
            return response.ToHttpResponse();

        }



        [Route("[action]/{serviceId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> getUserByService(char serviceId)
        {

            var response = new ListResponse<Users>();
            try
            {
                var res = await _userRepository.getUsersByService(serviceId);
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
            }
            return response.ToHttpResponse();

        }


        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UploadFile([FromForm(Name = "file")] IFormFile file)
        {
            _logger.LogInformation($"Register Init");
            _logger.LogInformation("file COUNT=" + file.Length);
            _logger.LogError("file COUNT=" + file.Length);

            var response = new Responses();
            try
            {
                if (file != null)
                {
                    //Upload files
                    var comm = new common();
                    var fileName = await comm.uploadfile(file, _logger);
                    response.Message = "fileName";
                    response.DidError = false;
                }
                else
                {
                    response.Message = "File is not uploaded";
                    response.DidError = false;
                }


            }
            catch (System.Exception ex)
            {
                response.Message = ex.Message;
                response.DidError = true;
            }
            return response.ToHttpResponse();
        }



        [Route("[action]")]
        [HttpPost]
        [Consumes("application/json", "multipart/form-data")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Register([FromForm] UserDto model)
        {
            _logger.LogError($"Register Init" + JsonConvert.SerializeObject(model));
            _logger.LogError($"UserDto={model.file == null}");
            var response = new SingleResponse<Users>();

            try
            {
                if (!model.login_typeid.HasValue)
                {
                    response.DidError = true;
                    response.ErrorMessage = "There was an internal error, please contact to technical support.";
                    response.Message = "Please define or send login Type ID";
                }
                else if (model.login_typeid.Value == (int)LoginType.app)
                {
                    var isExist = await _userRepository.getUserName(model.email);
                    if (isExist != null)
                    {
                        response.DidError = true;
                        response.ErrorMessage = "Email is exist, please try again";
                        _logger.LogError($"Email is exist, please try again");
                    }
                    else
                    {

                        //Upload files
                        var comm = new common();
                        var fileName = model.file != null ? comm.uploadfile(model.file, _logger) : null;


                        //Registor

                        var _user = new Users
                        {
                            first_name = model.first_name,
                            last_name = model.last_name,
                            email = model.email,
                            password = model.password,
                            address = model.address,
                            history=model.history,
                            phone_no = model.phone_no,
                            user_typeid = model.user_typeid,
                            login_typeid = model.login_typeid,
                            roleid = model.roleid,
                            profile_picture_path = fileName != null ? fileName.Result : null,
                            serviceId = model.serviceId,
                            created_by = model.created_by
                        };
                        var res = await _userRepository.Register(_user);
                        response.DidError = false;
                        response.Model = res;
                        response.Message = "successfully registered";

                    }

                }
                else
                {//social media
                    var result = await _userRepository.getUserName(model.email);
                    if (result != null)//Update
                    {
                        result.first_name = model.first_name;
                        result.last_name = model.last_name;
                        result.login_typeid = model.login_typeid;
                        result.user_typeid = model.user_typeid;
                        result.uid = model.uid;
                        result.profile_picture_path = model.imgUrl;
                        result.IsLoggedIn = 1;
                        var res = await _userRepository.Update(result);
                        response.DidError = false;
                        response.Model = res;
                        response.Message = "successfully Updated";

                    }
                    else
                    {//insert
                        var _user = new Users
                        {
                            first_name = model.first_name,
                            last_name = model.last_name,
                            email = model.email,
                            password = model.password,
                            phone_no = model.phone_no,
                            user_typeid = model.user_typeid,
                            login_typeid = model.login_typeid,
                            uid = model.uid,
                            profile_picture_path = model.imgUrl,
                            serviceId = model.serviceId,
                            address = model.address,
                            IsLoggedIn = 1,
                            created_by = model.created_by
                        };
                        var res = await _userRepository.Register(_user);
                        response.DidError = false;
                        response.Model = res;
                        response.Message = "successfully registered";
                    }

                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Stopped program because of exception");
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }
            return response.ToHttpResponse();
        }

    }



}