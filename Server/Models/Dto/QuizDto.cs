using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Server.Entity;

namespace Server.Models.Dto
{

    public class QuizDto
    {
        public QuizDto()
        {
            ListChoice = new List<Quiz_Choice>();
        }
        public int Id { get; set; }
        public int quation_no { get; set; } = 1;
        public string quation { get; set; }
        public List<Quiz_Choice> ListChoice { get; set; }

    }
}