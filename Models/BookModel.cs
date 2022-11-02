using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_Project.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please select the Language")]
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        [Required(ErrorMessage = "Please enter the Total Page Number")]
        public int TotalPages { get; set; }
        [Required(ErrorMessage = "Please enter the Author Name")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Please enter the Category")]
        public string Category { get; set; }

        public string BookImageUrl { get; set; }
        [Required(ErrorMessage = "Please Select the Image of the Book")]
        public IFormFile imagefile { get; set; }
        [Required(ErrorMessage = "Please Select the Pdf of the Book")]
        public IFormFile BookPdf { get; set; }

        public string BookModelPdfUrl { get; set; }
    }
}
