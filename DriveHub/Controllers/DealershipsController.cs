using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using DriveHub.DataContext;
using DriveHub.Models;

namespace DriveHub.Controllers
{
    public class DealershipsController : Controller
    {
        private readonly DriveHubContext _context;

        public DealershipsController(DriveHubContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dealerships = await _context.Dealerships.ToListAsync();
            return View(dealerships);
        }
    }
}
