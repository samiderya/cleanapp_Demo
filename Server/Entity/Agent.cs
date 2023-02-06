using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entity
{
    [Table("agent")]
    public class Agent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public string agent_name { get; set; }
        public string serviceId { get; set; }
        public string history { get; set; }
        public string imgUrl { get; set; }
        public string agent_phone { get; set; }
        public string agent_email { get; set; }
        public string agent_address { get; set; }
        public double? latitude { get; set; } = 0;
        public double? longitude { get; set; } = 0;
        public string descriptions { get; set; }
        public int created_by { get; set; } = 1;
        public DateTime created_at { get; set; } = DateTime.Now;
        public short is_active { get; set; } = 1;
    }
}