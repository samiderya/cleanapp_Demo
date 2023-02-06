using System;
using GeoCoordinatePortable;
using Microsoft.AspNetCore.Http;

namespace Server.Models.Dto
{
    public class BackgroundDto
    {
        public int userid { get; set; }
        public IFormFile file_id { get; set; }
        public IFormFile file_sin { get; set; }


    }
}