using System.ComponentModel.DataAnnotations;

namespace GreenHealthWebsite.Models.Login
{
    public class LoginView
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public byte[] Password { get; set; }
    }
}
