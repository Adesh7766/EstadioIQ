using System.ComponentModel.DataAnnotations;

namespace EstadioIQ.Entity.DTO
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string Role { get; set; } = "User";
    }

}
