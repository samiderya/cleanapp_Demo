using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
    [Route("api/agent")]
    // [Controller]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentRepository _agentRepository;
        private readonly ILogger<AgentController> _logger;
        public AgentController(ILogger<AgentController> logger, IAgentRepository agentRepository)
        {
            this._logger = logger;
            _agentRepository = agentRepository ?? throw new ArgumentNullException(nameof(agentRepository));

        }


        /// <summary>
        [Route("[action]/{latitude}/{longitude}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAgentsNearest(double latitude, double longitude)
        {

            var response = new ListResponse<AgentDto>();
            try
            {
                var res = await _agentRepository.getAgentNearest(latitude, latitude);
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
        public async Task<IActionResult> Create([FromForm] AgentDto model)
        {
            _logger.LogError($"Agent Create Init" + JsonConvert.SerializeObject(model));
            var response = new Responses();
            try
            {
                if (string.IsNullOrEmpty(model.address))
                {

                    response.DidError = true;
                    response.ErrorMessage = $"Address is required,please enter and try again";
                }
                else
                {
                    //Upload files
                    var comm = new common();
                    var fileName = model.file != null ? comm.uploadfile(model.file, _logger) : null;
                    var geo = comm.GetGeoLocation(model.address);
                    var ent = new Agent()
                    {
                        agent_name = model.agent_name,
                        agent_address = model.address,
                        agent_email = model.email,
                        agent_phone = model.phone_no,
                        imgUrl = fileName != null ? fileName.Result : null,
                        serviceId = model.serviceId,
                        history = model.history,
                        latitude = geo.Result.latitude,
                        longitude = geo.Result.longitude,
                        created_at = DateTime.Now,
                        created_by = 0,
                        is_active = 1,
                    };
                    var resp = await _agentRepository.Save(ent);
                    if (resp != 0)
                    {
                        response.Message = "Agent type Sucessfully Saved";
                        response.Id = resp;
                    }
                    else
                    {
                        response.DidError = true;
                        response.ErrorMessage = "Please try again";
                    }
                }
                //  _logger.LogDebug("root result {result}:", root.results);
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
        public async Task<IActionResult> SaveAgentUser([FromBody] Agent_Users model)
        {
            _logger.LogError($"SaveAgentUsert=" + JsonConvert.SerializeObject(model));
            var response = new Responses();
            try
            {
                var ent = new Agent_Users()
                {
                    agent_id = model.agent_id,
                    userid = model.userid
                };
                var resp = await _agentRepository.SaveAgentUser(ent);
                if (resp)
                {
                    response.Message = "Agent user rxn  Sucessfully Saved";
                }
                else
                {
                    response.DidError = true;
                    response.ErrorMessage = "error Agent user rxn,Please try again";
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
        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update([FromForm] AgentDto model)
        {
            var response = new SingleResponse<Agent>();
            string key = "AIzaSyB-BqCGBS_uuXsZI57LWEL5iJAN8PTnPF8";
            try
            {
                if (string.IsNullOrEmpty(model.address))
                {

                    response.DidError = true;
                    response.ErrorMessage = $"Address is required,please enter and try again";
                }
                else
                {

                    var resAll = await _agentRepository.getAll();
                    var getAgent = resAll.Where(x => x.agent_name.Equals(model.agent_name)).FirstOrDefault();
                    if (getAgent != null)
                    {
                        //Upload files
                        var comm = new common();
                        var fileName = comm.uploadfile(model.file, _logger);
                        var url = string.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0}&key={1}", getAgent.agent_address, key);
                        var req = (HttpWebRequest)WebRequest.Create(url);
                        var res = (HttpWebResponse)req.GetResponse();
                        using (var streamreader = new StreamReader(res.GetResponseStream()))
                        {
                            var result = await streamreader.ReadToEndAsync();
                            response.Message = result.ToString();

                            if (!string.IsNullOrWhiteSpace(result))
                            {
                                dynamic root = JsonConvert.DeserializeObject(result);
                                if (root.status == "OK")
                                {
                                    getAgent.imgUrl = fileName.Result;
                                    getAgent.latitude = root.results[0].geometry.location.lat;
                                    getAgent.longitude = root.results[0].geometry.location.lng;
                                };
                                var resp = await _agentRepository.Update(getAgent);
                                if (resp != null)
                                {
                                    response.Model = resp;
                                    response.Message = "Agent type Sucessfully Saved";
                                }
                                else
                                {
                                    response.DidError = true;
                                    response.ErrorMessage = "Please try again";
                                }
                            }

                        }
                    }


                    else
                    {

                        response.DidError = true;
                        response.ErrorMessage = $"GeoLocation is not found,please enter and try again";
                    }
                }


            }
            catch (System.Exception ex)
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