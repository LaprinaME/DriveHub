using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DriveHub.Models;
using DriveHub.ViewModels;
using DriveHub.DataContext;

namespace DriveHub.Controllers
{
    public class AddCarsController : Controller
    {
        private readonly DriveHubContext _context;

        public AddCarsController(DriveHubContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new AddCarsViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddCarsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var car = new Car
                {
                    CarID = viewModel.CarID,
                    Make = viewModel.Make,
                    Model = viewModel.Model,
                    Year = viewModel.Year,
                    Price = viewModel.Price,
                    Mileage = viewModel.Mileage,
                    Description = viewModel.Description,
                    DateAdded = DateTime.Now
                };

                _context.Cars.Add(car);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View("Index", viewModel);
        }
    }
}
