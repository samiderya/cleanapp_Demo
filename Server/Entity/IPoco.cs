using System;

namespace Server.Entity
{
    public interface IPoco
    {
        int Id { get; set; }
        int created_by { get; set; }
        DateTime created_at { get; set; }
        short is_active { get; set; }
    }
}