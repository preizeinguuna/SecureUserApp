using System.ComponentModel.DataAnnotations;

namespace SecureUserApp.Models
{
    public class UserModel
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Role { get; set; } = "User";
    }
}