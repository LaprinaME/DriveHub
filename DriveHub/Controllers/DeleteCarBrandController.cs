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
    public class DeleteCarBrandController : Controller
    {
        private readonly DriveHubContext _context;

        public DeleteCarBrandController(DriveHubContext context)
        {
            _context = context;
        }

        // GET: DeleteCarBrand
        public async Task<IActionResult> Index()
        {
            var brands = await _context.CarBrands
                .Select(b => new DeleteCarBrandViewModel
                {
                    BrandID = b.BrandID,
                    BrandName = b.BrandName,
                    Country = b.Country
                })
                .ToListAsync();

            return View(brands);
        }

        // POST: DeleteCarBrand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brand = await _context.CarBrands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            _context.CarBrands.Remove(brand);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
