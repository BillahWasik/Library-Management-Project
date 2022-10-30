namespace Library_Management_Project.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LanguageId { get; set; }
        public int TotalPages { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }
        public Language Language { get; set; }

    }
}
