using Library_Management_Project.Data;
using Library_Management_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library_Management_Project.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext _db)
        {
            this._db = _db;
        }
        public List<BookModel> GetAllBooks()
        {
            var Books = new List<BookModel>();
            var data = _db.TblBooks.Include(x => x.Language).ToList();
            if (data?.Any() == true)
            {
                foreach (var book in data)
                {
                    Books.Add(new BookModel
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        LanguageName = book.Language.Name,
                        LanguageId = book.LanguageId,
                        TotalPages = book.TotalPages,
                        BookImageUrl = book.ImageUrl,
                        BookModelPdfUrl = book.PdfUrl,

                    });
                }
            }
            return Books;
        }

        public List<BookModel> GetTopBooks()
        {
            var Books = new List<BookModel>();
            var data = _db.TblBooks.Include(x => x.Language).Take(3).ToList();
            if (data?.Any() == true)
            {
                foreach (var book in data)
                {
                    Books.Add(new BookModel
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        LanguageName = book.Language.Name,
                        LanguageId = book.LanguageId,
                        TotalPages = book.TotalPages,
                        BookImageUrl = book.ImageUrl,
                        BookModelPdfUrl = book.PdfUrl,

                    });
                }
            }
            return Books;
        }
        public int AddNewBook(BookModel obj)
        {
            var Book = new Book()
            {
                Id = obj.Id,
                Author = obj.Author,
                Category = obj.Category,
                Description = obj.Description,
                ImageUrl = obj.BookImageUrl,
                LanguageId = obj.LanguageId,
                Title = obj.Title,
                TotalPages = obj.TotalPages,
                PdfUrl = obj.BookModelPdfUrl
            };
            _db.TblBooks.Add(Book);
            _db.SaveChanges();
            return Book.Id;
        }

        public BookModel GetDetails(int id)
        {
            var data = _db.TblBooks.Include(x => x.Language).Where(x => x.Id == id).FirstOrDefault();

            if (data != null)
            {
                var book = new BookModel()
                {
                    Title = data.Title,
                    Id = data.Id,
                    Description = data.Description,
                    Author = data.Author,
                    Category = data.Category,
                    TotalPages = data.TotalPages,
                    BookImageUrl = data.ImageUrl,
                    LanguageId = data.LanguageId,
                    LanguageName = data.Language.Name,
                    BookModelPdfUrl = data.PdfUrl,


                };
                return book;

            }
            return null;

        }

        public int EditBook(BookModel obj)
        {
            var Book = new Book()
            {
                Id = obj.Id,
                Author = obj.Author,
                Category = obj.Category,
                Description = obj.Description,
                ImageUrl = obj.BookImageUrl,
                LanguageId = obj.LanguageId,
                Title = obj.Title,
                TotalPages = obj.TotalPages,
                PdfUrl = obj.BookModelPdfUrl
            };
            _db.TblBooks.Update(Book);
            _db.SaveChanges();
            return Book.Id;
        }

        public int DeleteBook(BookModel obj)
        {
            var Book = new Book()
            {
                Id = obj.Id,
                Author = obj.Author,
                Category = obj.Category,
                Description = obj.Description,
                ImageUrl = obj.BookImageUrl,
                LanguageId = obj.LanguageId,
                Title = obj.Title,
                TotalPages = obj.TotalPages,
                PdfUrl = obj.BookModelPdfUrl
            };
            _db.TblBooks.Remove(Book);
            _db.SaveChanges();
            return Book.Id;
        }


    }
}
