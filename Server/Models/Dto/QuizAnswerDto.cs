using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Server.Models.Dto
{
    public class QuizAnswerDto
    {
        public int userid { get; set; }
        public short Qid { get; set; }
        public char Qanswer { get; set; }


    }
}