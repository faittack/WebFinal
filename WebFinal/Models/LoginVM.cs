using System.ComponentModel.DataAnnotations;

namespace WebFinal.Models
{
    public class LoginVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}

