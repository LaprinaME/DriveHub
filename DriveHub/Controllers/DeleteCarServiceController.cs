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
    public class DeleteCarServiceController : Controller
    {
        private readonly DriveHubContext _context;

        public DeleteCarServiceController(DriveHubContext context)
        {
            _context = context;
        }

        // GET: DeleteCarService
        public async Task<IActionResult> Index()
        {
            var services = await _context.CarServices
                .Select(s => new DeleteCarServiceViewModel
                {
                    ServiceID = s.ServiceID,
                    ServiceName = s.ServiceName,
                    Description = s.Description,
                    Price = s.Price
                })
                .ToListAsync();

            return View(services);
        }

        // POST: DeleteCarService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.CarServices.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.CarServices.Remove(service);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
