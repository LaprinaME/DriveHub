using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DriveHub.DataContext;
using DriveHub.Models;

namespace DriveHub.Controllers
{
    public class CarServices1Controller : Controller
    {
        private readonly DriveHubContext _context;

        public CarServices1Controller(DriveHubContext context)
        {
            _context = context;
        }

        // GET: CarServices1
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarServices.ToListAsync());
        }

        // GET: CarServices1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carService = await _context.CarServices
                .FirstOrDefaultAsync(m => m.ServiceID == id);
            if (carService == null)
            {
                return NotFound();
            }

            return View(carService);
        }

        // GET: CarServices1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarServices1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceID,ServiceName,Description,Price")] CarService carService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carService);
        }

        // GET: CarServices1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carService = await _context.CarServices.FindAsync(id);
            if (carService == null)
            {
                return NotFound();
            }
            return View(carService);
        }

        // POST: CarServices1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceID,ServiceName,Description,Price")] CarService carService)
        {
            if (id != carService.ServiceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarServiceExists(carService.ServiceID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carService);
        }

        // GET: CarServices1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carService = await _context.CarServices
                .FirstOrDefaultAsync(m => m.ServiceID == id);
            if (carService == null)
            {
                return NotFound();
            }

            return View(carService);
        }

        // POST: CarServices1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carService = await _context.CarServices.FindAsync(id);
            if (carService != null)
            {
                _context.CarServices.Remove(carService);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarServiceExists(int id)
        {
            return _context.CarServices.Any(e => e.ServiceID == id);
        }
    }
}
