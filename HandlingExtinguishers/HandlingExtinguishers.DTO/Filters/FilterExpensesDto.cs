using System;


namespace HandlingExtinguishers.DTO.Filters
{
    public class FilterExpensesDto
    {
        public string? Description { get; set; } 
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; }  
    }
}
