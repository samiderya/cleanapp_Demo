using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entity
{
    [Table("cleaning_details")]
    public class Cleaning_details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public int cleaning_typeid { get; set; }

        public double min_hour { get; set; }
        public int package_typeid { get; set; }
        public int employee_no { get; set; }
        public int agentid { get; set; }
        public double? agent_rateid { get; set; }
        public int? transactionid { get; set; }
        public short service_status { get; set; }=1;//1-1ctive,2-start,3-Complite,4-incomplite
        public DateTime due_date { get; set; }

        public int created_by { get; set; }
        public DateTime created_at { get; set; }
        public short is_active { get; set; } = 1;
    }
}