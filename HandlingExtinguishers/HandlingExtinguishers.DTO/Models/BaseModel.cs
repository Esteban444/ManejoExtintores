using System;

namespace HandlingExtinguishers.DTO.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
