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
    public class DeleteFavoriteCarController : Controller
    {
        private readonly DriveHubContext _context;

        public DeleteFavoriteCarController(DriveHubContext context)
        {
            _context = context;
        }

        // GET: DeleteFavoriteCar
        public async Task<IActionResult> Index()
        {
            var favoriteCars = await _context.FavoriteCars
                .Select(fc => new DeleteFavoriteCarViewModel
                {
                    FavoriteID = fc.FavoriteID,
                    UserID = fc.UserID,
                    CarID = fc.CarID,
                    DateAdded = fc.DateAdded
                })
                .ToListAsync();

            return View(favoriteCars);
        }

        // POST: DeleteFavoriteCar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favoriteCar = await _context.FavoriteCars.FindAsync(id);
            if (favoriteCar == null)
            {
                return NotFound();
            }

            _context.FavoriteCars.Remove(favoriteCar);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
