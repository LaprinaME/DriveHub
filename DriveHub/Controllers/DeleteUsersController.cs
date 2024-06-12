using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveHub.DataContext;
using DriveHub.ViewModels;

namespace DriveHub.Controllers
{
    public class DeleteUsersController : Controller
    {
        private readonly DriveHubContext _context;

        public DeleteUsersController(DriveHubContext context)
        {
            _context = context;
        }

        // GET: /DeleteUsers
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users
                .Select(u => new DeleteUsersViewModel
                {
                    UserID = u.UserID,
                    Username = u.Username
                })
                .ToListAsync();

            return View(users);
        }

        // POST: /DeleteUsers/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
