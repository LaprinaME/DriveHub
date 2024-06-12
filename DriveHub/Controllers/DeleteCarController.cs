using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveHub.Models;
using DriveHub.ViewModels;
using DriveHub.DataContext;

namespace DriveHub.Controllers
{
    public class DeleteCarController : Controller
    {
        private readonly DriveHubContext _context;

        public DeleteCarController(DriveHubContext context)
        {
            _context = context;
        }

        // GET: DeleteCar
        public async Task<IActionResult> Index()
        {
            var cars = await _context.Cars
                .Select(c => new DeleteCarViewModel
                {
                    CarID = c.CarID,
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    Price = c.Price,
                    Mileage = c.Mileage,
                    Description = c.Description,
                    DateAdded = c.DateAdded
                })
                .ToListAsync();

            return View(cars);
        }

        // POST: DeleteCar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
