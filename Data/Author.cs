using System.Collections.Generic;

namespace Library_Management_Project.Data
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Book { get; set; }
    }
}
