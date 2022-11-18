using System.ComponentModel.DataAnnotations;

namespace Library_Management_Project.Models
{
    public class UserRegistration
    {
        [Key]
        [Required(ErrorMessage = "Enter a valid Email")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter your password Again")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password Mismatch!")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Enter your First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter your Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
