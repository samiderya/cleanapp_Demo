using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entity
{
    [Table("transactions")]
    public class Transactions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]

        public int Id { get; set; }
        public string card_type { get; set; }
        public string cardowner_name { get; set; }
        public string card_number { get; set; }
        public string expired_date { get; set; }
        public double ccv { get; set; }
        public double amount { get; set; }
        public int user_id { get; set; }
        public int transaction_typeid { get; set; }
        public int created_by { get; set; }=0;
        public DateTime created_at { get; set; }=DateTime.Now;
        public short is_active { get; set; } = 1;

    }
}