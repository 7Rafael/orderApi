using System.ComponentModel.DataAnnotations;

namespace orderApi.DTO
{
    public class Response
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
    }
}
