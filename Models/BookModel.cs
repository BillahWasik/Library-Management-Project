using Microsoft.AspNetCore.Http;

namespace Library_Management_Project.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int TotalPages { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string BookImageUrl { get; set; }
        public IFormFile imagefile { get; set; }
    }
}
