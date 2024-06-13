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
    public class TestDriveRequestsController : Controller
    {
        private readonly DriveHubContext _context;

        public TestDriveRequestsController(DriveHubContext context)
        {
            _context = context;
        }

        // GET: TestDriveRequests
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestDriveRequests.ToListAsync());
        }

        // GET: TestDriveRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDriveRequest = await _context.TestDriveRequests
                .FirstOrDefaultAsync(m => m.request_id == id);
            if (testDriveRequest == null)
            {
                return NotFound();
            }

            return View(testDriveRequest);
        }

        // GET: TestDriveRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestDriveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("request_id,preferred_date,preferred_time,status")] TestDriveRequest testDriveRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testDriveRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testDriveRequest);
        }

        // GET: TestDriveRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDriveRequest = await _context.TestDriveRequests.FindAsync(id);
            if (testDriveRequest == null)
            {
                return NotFound();
            }
            return View(testDriveRequest);
        }

        // POST: TestDriveRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("request_id,preferred_date,preferred_time,status")] TestDriveRequest testDriveRequest)
        {
            if (id != testDriveRequest.request_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testDriveRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestDriveRequestExists(testDriveRequest.request_id))
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
            return View(testDriveRequest);
        }

        // GET: TestDriveRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testDriveRequest = await _context.TestDriveRequests
                .FirstOrDefaultAsync(m => m.request_id == id);
            if (testDriveRequest == null)
            {
                return NotFound();
            }

            return View(testDriveRequest);
        }

        // POST: TestDriveRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testDriveRequest = await _context.TestDriveRequests.FindAsync(id);
            if (testDriveRequest != null)
            {
                _context.TestDriveRequests.Remove(testDriveRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestDriveRequestExists(int id)
        {
            return _context.TestDriveRequests.Any(e => e.request_id == id);
        }
    }
}
