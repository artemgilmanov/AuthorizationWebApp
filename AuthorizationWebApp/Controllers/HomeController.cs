using AuthorizationWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Authorization.DB.Models;
using Authorization.DB;

namespace AuthorizationWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public HomeController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(login.Email, login.Password, true, false).Result;

                if (result.Succeeded)
                {
                    return View(nameof(Success));
                }
                else
                {
                    ModelState.AddModelError("", "User does not exist, please create account.");
                }
            }
            return View(login);
        }
      
        public IActionResult Register()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult Register(Register register)
        {
            if (register.FirstName == register.Password)
            {
                ModelState.AddModelError("", "Firstname and Password must be different.");
                return View();
            }

            if (ModelState.IsValid)
            {
                var user = new User { Email = register.Email, UserName = register.Email };
                var result = _userManager.CreateAsync(user, register.Password).Result;

                if (result.Succeeded)
                {
                    _signInManager.SignInAsync(user, false).Wait(); //Cookie Authentification

                    TryAssignUserRole(user);

                    return Redirect(nameof(Success));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }

            return View(register);
        }

        private void TryAssignUserRole(User user)
        {
            try
            {
                _userManager.AddToRoleAsync(user, Constants.UserRoleName).Wait();
            }
            catch
            {
                //log see in logging
            }
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}