using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entity
{
    [Table("background_check")]
    public class Background_check
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public int userid { get; set; }
        public string file_name_sin_no { get; set; }
        public string file_name_idcard { get; set; }
        public int status { get; set; } = 0;
        public short agreement_accepted { get; set; } = 1;
        public int created_by { get; set; } = 0;
        public DateTime created_at { get; set; } = DateTime.Now;
        public short is_active { get; set; } = 1;
    }
}