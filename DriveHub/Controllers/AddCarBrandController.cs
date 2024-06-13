using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DriveHub.Models;
using DriveHub.ViewModels;
using DriveHub.DataContext;

namespace DriveHub.Controllers
{
    public class AddCarBrandController : Controller
    {
        private readonly DriveHubContext _context;

        public AddCarBrandController(DriveHubContext context)
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
        public async Task<IActionResult> Add(AddCarBrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                var brand = new CarBrand
                {
                    BrandName = model.BrandName,
                    Country = model.Country
                };

                _context.CarBrands.Add(brand);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View("Index", model);
        }
    }
}
