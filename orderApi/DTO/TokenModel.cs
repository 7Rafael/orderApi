using System.ComponentModel.DataAnnotations;

namespace orderApi.DTO
{
    public class TokenModel
    {
        public string? AcessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
