using System;
using GeoCoordinatePortable;
using Microsoft.AspNetCore.Http;

namespace Server.Models.Dto
{
   
    public class AgentDto
    {
        public string agent_name { get; set; }
        public string phone_no { get; set; }
        public string email { get; set; }
        public string serviceId { get; set; }
        public string history { get; set; }
        public string address { get; set; }

        public double? latitude { get; set; } = 0;
        public double? longitude { get; set; } = 0;
        public double rate { get; set; }
        public double? star { get; set; }
        public GeoCoordinate pin { get; set; }


        public double mile_range { get; set; }
        public string imgUrl { get; set; }
        public IFormFile file { get; set; }

    }
}