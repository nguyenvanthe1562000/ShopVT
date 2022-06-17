using chatapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace chatapp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<User> _sign;
        private readonly UserManager<User> _userManager;

        public AccountController(ILogger<AccountController> logger, SignInManager<User> sign, UserManager<User> userManager)
        {
            _logger = logger;
            _sign = sign;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                var result = await _sign.PasswordSignInAsync(user, password, false, false);
               
                    return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(string username, string password)
        {
            var user = new User
            {
                UserName = username
            };
            var result=await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                var result2 = await _sign.PasswordSignInAsync(user, password, false, false);

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Register", "Account");
        }
    
        public async Task<IActionResult> LogOut()
        {
            await _sign.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}