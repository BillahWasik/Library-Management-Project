namespace Library_Management_Project.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LanguageId { get; set; }
        public int TotalPages { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public Language Language { get; set; }

    }
}
