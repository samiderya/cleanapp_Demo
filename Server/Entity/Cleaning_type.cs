using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entity
{
    [Table("cleaning_type")]
    public class Cleaning_type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public string cleaning_type { get; set; }
        public string imgName { get; set; }
        public string route_url { get; set; }
        public string Descriptions { get; set; }
        public int created_by { get; set; } = 0;
        public DateTime created_at { get; set; } = DateTime.Now;
        public short is_active { get; set; } = 1;
    }
}