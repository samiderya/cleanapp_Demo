using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entity
{
    [Table("login_types")]
    public class Login_Types : IPoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public string login_type { get; set; }
        public string img_path { get; set; }
        public string description { get; set; }
        public int created_by { get; set; } = 0;
        public DateTime created_at { get; set; } = DateTime.Now;
        public short is_active { get; set; } = 1;

    }
}