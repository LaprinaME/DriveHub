using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DriveHub.Models;
using DriveHub.ViewModels;
using DriveHub.DataContext;

namespace DriveHub.Controllers
{
    public class AddCarServicesController : Controller
    {
        private readonly DriveHubContext _context;

        public AddCarServicesController(DriveHubContext context)
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
        public async Task<IActionResult> Add(AddCarServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = new CarService
                {
                    
                    ServiceName = model.ServiceName,
                    Description = model.Description,
                    Price = model.Price
                };

                _context.CarServices.Add(service);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View("Index", model);
        }
    }
}
