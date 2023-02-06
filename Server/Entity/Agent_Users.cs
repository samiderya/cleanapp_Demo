using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entity
{
    [Table("agent_users")]
    public class Agent_Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public int agent_id { get; set; }
        public int userid { get; set; }
        public int created_by { get; set; } = 0;
        public DateTime created_at { get; set; } = DateTime.Now;
        public short is_active { get; set; } = 1;
    }
}