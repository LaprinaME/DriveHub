using DriveHub.Controllers;
using DriveHub.DataContext;
using DriveHub.Models;
using DriveHub.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace DriveHubTest
{
    public class AddCarBrandControllerTests
    {
        private readonly DbContextOptions<DriveHubContext> _options;

        public AddCarBrandControllerTests()
        {
            // Используем память для тестирования контроллера
            _options = new DbContextOptionsBuilder<DriveHubContext>()
                .UseInMemoryDatabase(databaseName: "Test_DriveHub")
                .Options;
        }

        [Fact]
        public async Task Add_ValidModel_RedirectToIndex()
        {
            // Arrange
            var options = _options;
            using (var context = new DriveHubContext(options))
            {
                var mockBrand = new CarBrand { BrandID = 1, BrandName = "TestBrand", Country = "TestCountry" };
                var controller = new AddCarBrandController(context);
                var model = new AddCarBrandViewModel { BrandID = 1, BrandName = "TestBrand", Country = "TestCountry" };

                // Act
                var result = await controller.Add(model) as RedirectToActionResult;

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Index", result.ActionName);
            }
        }

        [Fact]
        public async Task Add_InvalidModel_ReturnsView()
        {
            // Arrange
            var options = _options;
            using (var context = new DriveHubContext(options))
            {
                var controller = new AddCarBrandController(context);
                var model = new AddCarBrandViewModel(); // Модель с недопустимыми данными

                controller.ModelState.AddModelError("BrandName", "Required"); // Добавление ошибки в ModelState

                // Act
                var result = await controller.Add(model) as ViewResult;

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Index", result.ViewName);
            }
        }
    }
}
