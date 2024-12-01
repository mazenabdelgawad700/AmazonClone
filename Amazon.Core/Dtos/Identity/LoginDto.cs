using System.ComponentModel.DataAnnotations;

namespace Amazon.Core.Dtos.Identity
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
