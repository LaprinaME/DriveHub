using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveHub.Models;
using DriveHub.DataContext;

namespace DriveHub.Controllers
{
    public class UsersController : Controller
    {
        private readonly DriveHubContext _context;

        public UsersController(DriveHubContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }
    }
}
