using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Entity;
using Server.Helpers;
using Server.Response;
using Server.Services;

namespace Server.Controllers
{
    [Route("api/test")]
    // [Controller]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<QuizController> _logger;
        public TestController(ILogger<QuizController> logger, IUserRepository userRepository)
        {
            this._logger = logger;
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

        }


        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult getWorkExperiance()
        {
            var response = new ListResponse<workExperience>();
            try
            {
                var lstdata = new List<workExperience>();
                lstdata.Add(new workExperience()
                {
                    id = 1,
                    quation = "How much paid cleaning experience do you have?",
                    choice = new choice()
                    {
                        answer = new List<string>(){
                      "0 - 6 months",
                      "6 months - 1 year",
                      "1 year - 3 years",
                      "3 years - 5 years",
                      "5+ years"
                     }
                    },
                });
                lstdata.Add(new workExperience()
                {
                    id = 2,
                    quation = "Are you legally eligible to work in the Canada.?",
                    choice = new choice()
                    {
                        answer = new List<string>(){
                      "Yes",
                      "No"
                     }
                    },
                });
                lstdata.Add(new workExperience()
                {
                    id = 3,
                    quation = "How did you hear about Executive Hand? (optional)",

                });
                lstdata.Add(new workExperience()
                {
                    id = 4,
                    quation = "If you were referred by Executive Hand professional, enter their referral code. (optional)",

                });
                lstdata.Add(new workExperience()
                {
                    id = 5,
                    quation = "Are you part of a Company/LLC or a crew? (optional)",
                    choice = new choice()
                    {
                        answer = new List<string>(){
                      "I work individually",
                      "1 - 5 employees",
                      "6 - 10 employees",
                      "10+ employees"
                     }
                    },

                });

                response.Model = lstdata;
                response.DidError = false;


            }
            catch (System.Exception ex)
            {
                response.Model = null;
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }
            return response.ToHttpResponse();
        }



        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> getTest()
        {
            string key = "AIzaSyB-BqCGBS_uuXsZI57LWEL5iJAN8PTnPF8";
            var response = new Responses();
            string address = "42 Farley LnHamilton, ON L9G 0H2";
            try
            {

                var url = string.Format("https://maps.googleapis.com/maps/api/js?key={0}&libraries={1}&callback=initMap", key, address);

                // var url = string.Format("https://maps.googleapis.com/maps/api/geocode/json?address={0}&key={1}",address, key);
                var req = (HttpWebRequest)WebRequest.Create(url);

                var res = (HttpWebResponse)req.GetResponse();
                if (res == null)
                {
                    response.DidError = false;
                    response.ErrorMessage = "Data not found";
                }
                else
                {

                    response.DidError = false;
                    using (var streamreader = new StreamReader(res.GetResponseStream()))
                    {
                        var result = await streamreader.ReadToEndAsync();
                        response.Message = result.ToString();
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