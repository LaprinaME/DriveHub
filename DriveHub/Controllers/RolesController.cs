using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using DriveHub.DataContext;
using DriveHub.Models;

namespace DriveHub.Controllers
{
    public class RolesController : Controller
    {
        private readonly DriveHubContext _context;

        public RolesController(DriveHubContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _context.Roles.ToListAsync();
            return View(roles);
        }
    }
}
