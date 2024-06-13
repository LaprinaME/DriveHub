using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DriveHub.Models;
using DriveHub.ViewModels;
using DriveHub.DataContext;

namespace DriveHub.Controllers
{
    public class AddDealershipController : Controller
    {
        private readonly DriveHubContext _context;

        public AddDealershipController(DriveHubContext context)
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
        public async Task<IActionResult> Add(AddDealershipViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dealership = new Dealership
                {
                   
                    DealershipName = model.DealershipName,
                    Address = model.Address,
                    Phone = model.Phone
                };

                _context.Dealerships.Add(dealership);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View("Index", model);
        }
    }
}
