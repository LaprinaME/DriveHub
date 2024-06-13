using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DriveHub.Models;
using DriveHub.ViewModels;
using DriveHub.DataContext;

namespace DriveHub.Controllers
{
    public class AddFavoriteCarsController : Controller
    {
        private readonly DriveHubContext _context;

        public AddFavoriteCarsController(DriveHubContext context)
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
        public async Task<IActionResult> Add(AddFavoriteCarsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var favoriteCar = new FavoriteCar
                {
                   
                    UserID = model.UserID,
                    CarID = model.CarID,
                    DateAdded = model.DateAdded
                };

                _context.FavoriteCars.Add(favoriteCar);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View("Index", model);
        }
    }
}
