using DriveHub.Controllers;
using DriveHub.DataContext;
using DriveHub.Models;
using DriveHub.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Data;
using System.Threading.Tasks;
using Xunit;

namespace DriveHubTest
{
    public class AccountControllerTests
    {
        private readonly DbContextOptions<DriveHubContext> _options;

        public AccountControllerTests()
        {
            // Используем память для тестирования контроллера
            _options = new DbContextOptionsBuilder<DriveHubContext>()
                .UseInMemoryDatabase(databaseName: "Test_DriveHub")
                .Options;
        }

        [Fact]
        public async Task Login_ValidUser_RedirectToAdministration()
        {
            // Arrange
            var options = _options;
            using (var context = new DriveHubContext(options))
            {
                // Заполняем базу данных для тестирования
                context.Users.Add(new User
                {
                    UserID = 1,
                    Username = "testuser",
                    Password = "testpassword",
                    RoleID = 1 // Идентификатор роли для администратора
                });
                await context.SaveChangesAsync();
            }

            var mockContext = new Mock<DriveHubContext>(options);
            var loginModel = new LoginViewModel { Login = "testuser", Password = "testpassword" };
            var controller = new AccountController(mockContext.Object);

            // Act
            var result = await controller.Login(loginModel) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Administration", result.ControllerName);
        }

        [Fact]
        public async Task Register_ValidModel_RedirectToHome()
        {
            // Arrange
            var options = _options;
            using (var context = new DriveHubContext(options))
            {
                var mockRole = new Role { RoleID = 2, RoleName = "Administrator" };
                context.Roles.Add(mockRole);
                await context.SaveChangesAsync();
            }

            var mockContext = new Mock<DriveHubContext>(options);
            var registerModel = new RegisterViewModel
            {
                Login = "newuser",
                Password = "password123",
                UserCode = 1, // Пример кода пользователя
                RoleCode = 2 // Идентификатор роли администратора
            };
            var controller = new AccountController(mockContext.Object);

            // Act
            var result = await controller.Register(registerModel) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }
    }
}
