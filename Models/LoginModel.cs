using System.ComponentModel.DataAnnotations;

namespace BlazorAppTTHH.Models
{
    public class LoginModel
    {
        [Required]
        [StringLength(4, ErrorMessage = "El nombre de usuario debe tener exactamente 4 caracteres.", MinimumLength = 4)]
        public string Usuario { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
