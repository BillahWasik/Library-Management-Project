using Library_Management_Project.Models;
using System.Collections.Generic;

namespace Library_Management_Project.Repository
{
    public interface IBookRepository
    {
        int AddNewBook(BookModel obj);
        List<BookModel> GetAllBooks();
        BookModel GetDetails(int id);
        List<BookModel> GetTopBooks();
    }
}