using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BookAndStay.Web.ViewModel
{
    public class RegisterVM
    {
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Compare(nameof(Password))]

        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        public string? Role { get; set; }

        public string? ReturnUrl { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? RoleList { get; set; }


    }
}
