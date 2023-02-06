using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entity
{
    [Table("star_rate_details")]
    public class Star_rate_detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public short star_rate { get; set; }//1,2,3,4,5 star
        public short? user_type_id { get; set; } = 2;//1-admin,2-self Emplyee,3-agent
        public short user_id { get; set; }
        public short service_type_id { get; set; }
        public string review_descriptions { get; set; }
        public int service_detail_id { get; set; }
        public int created_by { get; set; } = 1;
        public DateTime created_at { get; set; } = DateTime.Now;
        public short is_active { get; set; } = 1;
    }
}