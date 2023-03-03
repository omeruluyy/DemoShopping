using DemoShopping.Models;
using DemoShopping.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DemoShopping.Controllers
{
    public class RegisterController : Controller
    {
        private readonly DemoShoppingDbContext _context;

        public RegisterController(DemoShoppingDbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( RegisterViewModel user)
        {
           var isRegistered= _context.Users.Where(u => u.Email == user.Email).FirstOrDefault();
            if (isRegistered !=null)
            {
 
                return View();


            }
            if (ModelState.IsValid)
            {
                User user1 = new User()
                {
                    Email = user.Email,
                    Name = user.Name,
                    Password = user.Password,
                    Surname = user.Surname,
                    
                };
                
                _context.Add(user1);
                UserRole role = new UserRole()
                {
                    User = user1,

                    RoleId = 2,
                };
                _context.UserRoles.Add(role);
                await _context.SaveChangesAsync();
               
                //await _context.SaveChangesAsync();

            }
                return RedirectToAction("Index", "Login");

        }
    }
}
