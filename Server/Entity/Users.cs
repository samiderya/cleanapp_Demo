using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entity
{

    [Table("users")]
    public class Users : IPoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; } = "-";
        public string email { get; set; }
        public string password { get; set; } = "123456";
        public string phone_no { get; set; }
        public string address { get; set; }
        public string history { get; set; }
        public int user_typeid { get; set; } = 1;
        public int? login_typeid { get; set; }
        public string serviceId { get; set; }//keeps as string and separeted by comma,
        public int? roleid { get; set; } = 0;

        public string profile_picture_path { get; set; }
        public string uid { get; set; }

        public DateTime? LastLogin { get; set; } = DateTime.Now;
        public int? IsLoggedIn { get; set; } = 0;

        public string Token { get; set; }
        public int created_by { get; set; } = 0;
        public DateTime created_at { get; set; } = DateTime.Now;
        public short is_active { get; set; } = 1;

    }

}
