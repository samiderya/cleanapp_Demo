using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entity
{
    [Table("user_quiz_answer")]
    public class User_quiz_answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public int userid { get; set; }
        public int quiz_id { get; set; }
        public string answer_given { get; set; }
        public short is_active { get; set; } = 1;
    }
}