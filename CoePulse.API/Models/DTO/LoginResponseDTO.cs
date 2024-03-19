using Microsoft.AspNetCore.Identity;

namespace CoePulse.API.Models.DTO
{
    public class LoginResponseDTO
    {
        public string? Token { get; set; }
        public string? Email { get; set; }
        public List<string>? Roles { get; set; }
    }
}
