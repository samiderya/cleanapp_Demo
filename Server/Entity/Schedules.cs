using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entity
{
    [Table("schedules")]
    public class Schedules
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]

        public int Id { get; set; }

        public int customer_id { get; set; }
        public int package_typeid { get; set; }
        public DateTime due_date { get; set; }
        public int status { get; set; }
        public int created_by { get; set; }
        public DateTime created_at { get; set; }
        public short is_active { get; set; } = 1;

    }
}