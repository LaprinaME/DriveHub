using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DriveHub.Models;
using DriveHub.ViewModels;
using DriveHub.DataContext;

namespace DriveHub.Controllers
{
    public class AddReviewController : Controller
    {
        private readonly DriveHubContext _context;

        public AddReviewController(DriveHubContext context)
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
        public async Task<IActionResult> Add(AddReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                var review = new Review
                {
                    
                    UserID = model.UserID,
                    CarID = model.CarID,
                    Rating = model.Rating,
                    Comment = model.Comment,
                    DatePosted = model.DatePosted
                };

                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View("Index", model);
        }
    }
}
