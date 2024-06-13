using Microsoft.AspNetCore.Mvc;
using DriveHub.DataContext;
using DriveHub.Models;
using System.Collections.Generic;
using System.Linq;

namespace DriveHub.Controllers
{
    public class CarCompanyController : Controller
    {
        private readonly DriveHubContext _context;

        public CarCompanyController(DriveHubContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var companies = _context.CarCompanies.ToList();
            return View(companies);
        }

        [HttpPost]
        public IActionResult ChangeStatus(List<int> companyIds, string newStatus)
        {
            if (companyIds != null && companyIds.Any() && !string.IsNullOrEmpty(newStatus))
            {
                foreach (var id in companyIds)
                {
                    var company = _context.CarCompanies.Find(id);
                    if (company != null)
                    {
                        company.Status = newStatus;
                    }
                }
                _context.SaveChanges(); // Сохраняем изменения в базе данных
            }
            return RedirectToAction("Index");
        }
    }
}
