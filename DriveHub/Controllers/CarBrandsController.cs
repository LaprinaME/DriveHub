using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using System.Linq;
using System.Threading.Tasks;
using DriveHub.DataContext;
using DriveHub.Models;

namespace DriveHub.Controllers
{
    public class CarBrandsController : Controller
    {
        private readonly DriveHubContext _context;

        public CarBrandsController(DriveHubContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await _context.CarBrands.ToListAsync();
            return View(brands);
        }
    }
}
