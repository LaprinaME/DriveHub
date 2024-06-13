using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DriveHub.Models;
using DriveHub.ViewModels;
using DriveHub.DataContext;

namespace DriveHub.Controllers
{
    public class AddUsersController : Controller
    {
        private readonly DriveHubContext _context;

        public AddUsersController(DriveHubContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddUsersViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    
                    Username = model.Username,
                    Password = model.Password,
                    RoleID = model.RoleID
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View("Index", model);
        }
    }
}
