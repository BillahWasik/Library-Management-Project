using Library_Management_Project.Repository;
using Microsoft.AspNetCore.Mvc;
namespace Library_Management_Project.ViewComponents
{
    public class TopBooks : ViewComponent
    {
        private readonly BookRepository _db;

        public TopBooks(BookRepository _db)
        {
            this._db = _db;
        }
        public IViewComponentResult Invoke() 
        {
           var data = _db.GetTopBooks();
          return View(data);
        }
    }
}
