using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entity
{
    [Table("package_types")]
    public class Package_types
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public string package_name { get; set; }
        public string descriptions { get; set; }
        public int created_by { get; set; }
        public DateTime created_at { get; set; }
        public short is_active { get; set; } = 1;

    }
}