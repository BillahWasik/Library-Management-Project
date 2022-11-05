using System.ComponentModel.DataAnnotations;

namespace Library_Management_Project.Models
{
    public class ChangePasswordModel
    {
        
        [Key]
        [Required] 
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage ="Password do not match")]
        [Display(Name ="Confirm Password")]
        public string ConfirmNewPassword { get; set; }
    }
}
