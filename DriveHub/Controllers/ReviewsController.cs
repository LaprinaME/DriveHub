using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using DriveHub.DataContext;
using DriveHub.Models;

namespace DriveHub.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly DriveHubContext _context;

        public ReviewsController(DriveHubContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var reviews = await _context.Reviews.Include(r => r.Car).Include(r => r.User).ToListAsync();
            return View(reviews);
        }
    }
}
