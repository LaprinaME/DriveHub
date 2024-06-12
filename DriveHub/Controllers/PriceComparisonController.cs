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
    public class PriceComparisonController : Controller
    {
        // Действие для отображения главной страницы
        public IActionResult Index()
        {
            return View();
        }
    }
}
