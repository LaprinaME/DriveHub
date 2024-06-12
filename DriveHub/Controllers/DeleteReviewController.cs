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
    public class DeleteReviewController : Controller
    {
        private readonly DriveHubContext _context;

        public DeleteReviewController(DriveHubContext context)
        {
            _context = context;
        }

        // GET: DeleteReview
        public async Task<IActionResult> Index()
        {
            var reviews = await _context.Reviews
                .Select(r => new DeleteReviewViewModel
                {
                    ReviewID = r.ReviewID,
                    UserID = r.UserID,
                    CarID = r.CarID,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    DatePosted = r.DatePosted
                })
                .ToListAsync();

            return View(reviews);
        }

        // POST: DeleteReview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
