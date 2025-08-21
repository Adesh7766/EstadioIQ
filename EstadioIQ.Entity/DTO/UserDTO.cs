using System.ComponentModel.DataAnnotations;

namespace EstadioIQ.Entity.DTO
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
