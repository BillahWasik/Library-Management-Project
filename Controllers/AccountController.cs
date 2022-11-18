using Library_Management_Project.Models;
using Library_Management_Project.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library_Management_Project.Controllers
{

    public class AccountController : Controller
    {
        private readonly IAccountRepository _db;
        private readonly SignInManager<CustomizeUser> _signInManager;

        public AccountController(IAccountRepository _db , SignInManager<CustomizeUser> _signInManager)
        {
            this._db = _db;
            this._signInManager = _signInManager;
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegistration obj)
        {
            if (ModelState.IsValid)
            {
                var result = await _db.CreateUserAsync(obj);
                if (result.Succeeded)
                {
                   await _db.LoggedIn(obj);
                    return RedirectToAction("Index","Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                ModelState.Clear();
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInUser obj , string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _db.LoginUser(obj);
                if (result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(returnUrl)) 
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Data Credentials");
            }

            return View(obj);
        }
        public IActionResult Logout()
        {
            _db.LogOut();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ChangePassword()
        {
            return View();
           
        }
        [HttpPost]
        public async  Task<IActionResult> ChangePassword(ChangePasswordModel obj)
        {
            if (ModelState.IsValid) 
            {
             var result = await _db.ChangePassword(obj);
                if (result.Succeeded) 
                {
                    ModelState.Clear();
                    return View();
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(obj);

        }

    }
}
