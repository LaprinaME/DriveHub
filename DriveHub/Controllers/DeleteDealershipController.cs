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
    public class DeleteDealershipController : Controller
    {
        private readonly DriveHubContext _context;

        public DeleteDealershipController(DriveHubContext context)
        {
            _context = context;
        }

        // GET: DeleteDealership
        public async Task<IActionResult> Index()
        {
            var dealerships = await _context.Dealerships
                .Select(d => new DeleteDealershipViewModel
                {
                    DealershipID = d.DealershipID,
                    DealershipName = d.DealershipName,
                    Address = d.Address,
                    Phone = d.Phone
                })
                .ToListAsync();

            return View(dealerships);
        }

        // POST: DeleteDealership/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dealership = await _context.Dealerships.FindAsync(id);
            if (dealership == null)
            {
                return NotFound();
            }

            _context.Dealerships.Remove(dealership);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
