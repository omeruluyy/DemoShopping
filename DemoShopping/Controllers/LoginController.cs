using DemoShopping.Models;
using DemoShopping.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DemoShopping.Controllers
{
    public class LoginController : Controller
    {
        private readonly DemoShoppingDbContext _context;

        public LoginController(DemoShoppingDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Index(LoginViewModel loginViewModel)
        {
            //string name = loginViewModel.email;
            //string password = loginViewModel.password;

            User user = _context.Users.FirstOrDefault(x => x.Email == loginViewModel.email);
            if (user == null)
            {
                return View();
            }
            var result = user.Password == loginViewModel.password;
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;
            if (result)
            {
                var userRoles = _context.UserRoles.Where(ur => ur.UserId == user.UserID);
                var roles = _context.Roles.Where(ro => userRoles.Any(ur => ur.RoleId == ro.Id));
                identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                foreach (var item in roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, item.Name));
                }
                identity.AddClaim(new Claim(ClaimTypes.Email, loginViewModel.email));
                isAuthenticate = true;
            }
            if (isAuthenticate)
            {
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
