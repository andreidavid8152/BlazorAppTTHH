using System.ComponentModel.DataAnnotations;

namespace BlazorAppTTHH.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "El nombre de usuario debe tener al menos 4 caracteres.", MinimumLength = 4)]
        public string Usuario { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
