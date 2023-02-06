using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entity
{
    [Table("agent_rate")]
    public class Agent_rate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public double hourly_rate { get; set; }
        public int agentid { get; set; }
        public string descriptions { get; set; }
        public int created_by { get; set; }=1;
        public DateTime created_at { get; set; }=DateTime.Now;
        public short is_active { get; set; } = 1;
    }
}