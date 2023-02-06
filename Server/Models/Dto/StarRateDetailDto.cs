
namespace Server.Models.Dto
{
    public class StarRateDetailDto
    {
        public short star_rate { get; set; }
        public short userid { get; set; }
        public short user_type_id { get; set; }
        public short service_type_id { get; set; }
        public string review_descriptions { get; set; }
        public int service_detail_id { get; set; }
    }
}