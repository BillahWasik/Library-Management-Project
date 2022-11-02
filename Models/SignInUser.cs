using System.ComponentModel.DataAnnotations;

namespace Library_Management_Project.Models
{
    public class SignInUser
    {
        [Required(ErrorMessage = "Please enter your email"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
