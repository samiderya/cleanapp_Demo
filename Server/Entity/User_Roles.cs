using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entity
{
    [Table("user_roles")]
    public class User_Roles : IPoco
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public string role_name { get; set; }
        public int created_by { get; set; }
        public DateTime created_at { get; set; }
        public short is_active { get; set; } = 1;
    }
}