using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Server.Models.Dto
{
    public class UserDto
    {

        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone_no { get; set; }
        public string address { get; set; }
        public string history { get; set; }

        public int user_typeid { get; set; } = 2;//Self Employed
        public int? login_typeid { get; set; } = 1;//app
        public string serviceId { get; set; }//rxn cleaning_type
        public int? roleid { get; set; } = 0;

        public string imgUrl { get; set; }
        public string uid { get; set; }
        public int created_by { get; set; } = 0;

        public IFormFile file { get; set; }
        // public string demoPassword
        // {
        //     get { return first_name.Substring(0, 2) + last_name.Substring(0, 2); }
        // }
    }
}