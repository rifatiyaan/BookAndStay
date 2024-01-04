using System.ComponentModel.DataAnnotations;

namespace BookAndStay.Web.ViewModel
{
    public class LoginVM
    {
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
