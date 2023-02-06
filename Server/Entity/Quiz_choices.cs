using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entity
{
    [Table("quiz_choice")]
    public class Quiz_Choice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public string choice_no { get; set; }
        public string choice { get; set; }
        public string descriptions { get; set; }
        public short? is_right { get; set; } = 1;
        [ForeignKey("quiz_id")]
        public int quiz_id { get; set; }
        public int created_by { get; set; } = 1;
        public DateTime created_at { get; set; } = DateTime.Now;
        public short is_active { get; set; } = 1;
        // public virtual Quiz Quiz { get; set; }
    }
}