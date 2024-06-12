using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using DriveHub.DataContext;
using DriveHub.Models;

namespace DriveHub.Controllers
{
    public class FavoriteCarsController : Controller
    {
        private readonly DriveHubContext _context;

        public FavoriteCarsController(DriveHubContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var favoriteCars = await _context.FavoriteCars.Include(fc => fc.Car).ToListAsync();
            return View(favoriteCars);
        }
    }
}
