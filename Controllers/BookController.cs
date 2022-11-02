using Library_Management_Project.Data;
using Library_Management_Project.Models;
using Library_Management_Project.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Library_Management_Project.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBookRepository _db;
        private readonly IWebHostEnvironment _env;
        public BookController(IBookRepository _db, IWebHostEnvironment _env, ApplicationDbContext _context)
        {
            this._db = _db;
            this._env = _env;
            this._context = _context;
        }
        public string UploadImage(string FolderPath, IFormFile file)
        {
            FolderPath += file.FileName;

            string FullPath = Path.Combine(_env.WebRootPath, FolderPath);

            file.CopyTo(new FileStream(FullPath, FileMode.Create));

            return "/" + FolderPath;
        }
        private IEnumerable<Language> DropdownData()
        {
            var data = _context.TblLanguages.ToList();
            return data;
        }
        public IActionResult Index()
        {
            var data = _db.GetAllBooks().ToList();
            return View(data);
        }
        [Authorize]
        public IActionResult CreateBook(bool IsSuccess = false)
        {
            ViewBag.Success = IsSuccess;
            ViewBag.Dropdown = new SelectList(DropdownData(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateBook(BookModel obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.imagefile != null)
                {
                    string path = "Image/Book/";
                    obj.BookImageUrl = UploadImage(path, obj.imagefile);
                }

                if (obj.BookPdf != null)
                {
                    string pdfpath = "Pdf/";
                    obj.BookModelPdfUrl = UploadImage(pdfpath, obj.BookPdf);
                }

                ViewBag.Dropdown = new SelectList(DropdownData(), "Id", "Name");
                _db.AddNewBook(obj);
                return RedirectToAction(nameof(Index), new { IsSuccess = true });
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            var data = _db.GetDetails(id);
            return View(data);
        }
        public IActionResult BookTable() 
        {
            var data = _db.GetAllBooks().ToList();
            return View(data);
        }
    }
}
