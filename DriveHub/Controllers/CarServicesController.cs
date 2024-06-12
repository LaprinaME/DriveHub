using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using DriveHub.DataContext;
using DriveHub.Models;

namespace DriveHub.Controllers
{
    public class CarServicesController : Controller
    {
        private readonly DriveHubContext _context;

        public CarServicesController(DriveHubContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _context.CarServices.ToListAsync();
            return View(services);
        }
    }
}
