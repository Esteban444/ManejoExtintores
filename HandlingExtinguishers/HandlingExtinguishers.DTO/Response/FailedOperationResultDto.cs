using System;


namespace HandlingExtinguishers.DTO.Response
{
    public class FailedOperationResultDto
    {
        public string? Title { get; set; }
        public int? Status { get; set; }
        public string? Detail { get; set; }
        public IEnumerable<string>? Errors { get; set; }
        public string? TraceId { get; set; }
    }
}
