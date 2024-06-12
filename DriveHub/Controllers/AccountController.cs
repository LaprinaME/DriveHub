using Microsoft.AspNetCore.Mvc;
using DriveHub.DataContext;
using DriveHub.Models;
using DriveHub.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DriveHub.Controllers
{
    public class AccountController : Controller
    {
        private readonly DriveHubContext _context;

        public AccountController(DriveHubContext context)
        {
            _context = context;
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users
                    .Include(u => u.Roles)
                    .FirstOrDefaultAsync(u => u.Username == model.Login && u.Password == model.Password);

                if (user != null)
                {
                    if (user.Roles != null)
                    {
                        var roleCode = user.RoleID;

                        if (roleCode == 1)
                        {
                            return RedirectToAction("Index", "Administration");
                        }
                        else if (roleCode == 2)
                        {
                            return RedirectToAction("Index", "Administration");
                        }
                        else if (roleCode == 3)
                        {
                            return RedirectToAction("Index", "Administration");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Роль пользователя не определена");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Неверный логин или пароль");
                }
            }
            return View(model);
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _context.Users.AnyAsync(u => u.Username == model.Login))
                {
                    ModelState.AddModelError("Login", "Пользователь с таким логином уже существует");
                    return View(model);
                }

                if (await _context.Roles.AllAsync(r => r.RoleID != model.RoleCode))
                {
                    ModelState.AddModelError("RoleCode", "Роль с указанным кодом не существует");
                    return View(model);
                }

                var account = new User
                {
                    Username = model.Login,
                    Password = model.Password,
                    UserID = model.UserCode
                };

                account.Roles = await _context.Roles.FindAsync(model.RoleCode);

                _context.Add(account);
                await _context.SaveChangesAsync();

                if (model.RoleCode == 2)
                {
                    return RedirectToAction("Index", "Administration");
                }
                else if (model.RoleCode == 3)
                {
                    return RedirectToAction("Index", "Administration");
                }
                else if (model.RoleCode == 3)
                {
                    return RedirectToAction("Index", "Administration");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View("~/Views/Account/Register.cshtml");
        }

        // GET: /Account/RegistrationSuccess
        public IActionResult RegistrationSuccess()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}