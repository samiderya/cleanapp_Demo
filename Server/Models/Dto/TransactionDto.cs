using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models.Dto
{

    public class TransactionDto
    {
        public string card_type { get; set; }
        public string cardowner_name { get; set; }
        public string card_number { get; set; }
        public string expired_date { get; set; }
        public double ccv { get; set; }
        public double amount { get; set; }
        public int user_id { get; set; }
        public int transaction_typeid { get; set; }

    }
}