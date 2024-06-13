using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using DriveHub.Models;
using DriveHub.ViewModels;
using DriveHub.DataContext;
using System.Data.SqlClient;

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
                    
                    Make = viewModel.Make,
                    Model = viewModel.Model,
                    Year = viewModel.Year,
                    Price = viewModel.Price,
                    Mileage = viewModel.Mileage,
                    Description = viewModel.Description,
                    DateAdded = DateTime.Now
                };

                try
                {
                    _context.Cars.Add(car);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2627)
                {
                    // Проверка, что исключение связано с нарушением уникальности
                    ModelState.AddModelError(string.Empty, "Автомобиль с таким ID уже существует.");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Неизвестная ошибка. Попробуйте еще раз.");
                }
            }

            return View("Index", viewModel);
        }
    }
}
