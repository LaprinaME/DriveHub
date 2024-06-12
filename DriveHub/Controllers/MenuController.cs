using DriveHub.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DriveHub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;

namespace DriveHub.Controllers
{
    public class MenuController : Controller
    {
        // GET: 
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: 
        [HttpPost]
        public IActionResult Index(string page)
        {
            if (!string.IsNullOrEmpty(page))
            {
                return Redirect(page);
            }
            else
            {
                // Если не выбрана страница, просто возвращаем текущую страницу
                return RedirectToAction("Index");
            }
        }
    }
}