using System;
using Microsoft.AspNetCore.Http;

namespace Server.Models.Dto
{
    public class CleaningTypeDto
    {
        public string cleaning_type { get; set; }
        public int created_by { get; set; } = 0;
        public IFormFile file { get; set; }
    }
    // SELECT id, cleaning_typeid, min_hour, package_typeid, employee_no, agentid, agent_rateid, transactionid, due_date, created_by, created_at, is_active
    // FROM cleanerdb.cleaning_details;

    public class CleaningDetailDto
    {
        public short cleaning_typeid { get; set; }
        public double total_hour { get; set; }
        public short package_typeid { get; set; }
        public short total_employee { get; set; }
        public short? agentid { get; set; }
        public DateTime due_date { get; set; }
    }
}