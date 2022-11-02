using Library_Management_Project.Repository;
using Microsoft.AspNetCore.Mvc;
namespace Library_Management_Project.ViewComponents
{
    public class TopBooks : ViewComponent
    {
        private readonly IBookRepository _db;

        public TopBooks(IBookRepository _db)
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
