using DriveHub.Controllers;
using DriveHub.DataContext;
using DriveHub.Models;
using DriveHub.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DriveHubTest
{
    public class DeleteUsersControllerTests
    {
        private DbContextOptions<DriveHubContext> _options;

        public DeleteUsersControllerTests()
        {
            // Используем память для тестирования контроллера
            _options = new DbContextOptionsBuilder<DriveHubContext>()
                .UseInMemoryDatabase(databaseName: "Test_DriveHub")
                .Options;
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfUsers()
        {
            // Arrange
            using (var context = new DriveHubContext(_options))
            {
                context.Users.AddRange(
                    new User { UserID = 1, Username = "User1" },
                    new User { UserID = 2, Username = "User2" }
                );
                context.SaveChanges();

                var controller = new DeleteUsersController(context);

                // Act
                var result = await controller.Index() as ViewResult;
                var model = result.ViewData.Model as List<DeleteUsersViewModel>;

                // Assert
                Assert.NotNull(result);
                Assert.Equal(2, model.Count);
            }
        }

        [Fact]
        public async Task Delete_ReturnsRedirectToActionResult_WhenUserExists()
        {
            // Arrange
            using (var context = new DriveHubContext(_options))
            {
                context.Users.Add(new User { UserID = 1, Username = "User1" });
                context.SaveChanges();

                var controller = new DeleteUsersController(context);

                // Act
                var result = await controller.Delete(1) as RedirectToActionResult;

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Index", result.ActionName);
            }
        }

        [Fact]
        public async Task Delete_ReturnsNotFoundResult_WhenUserDoesNotExist()
        {
            // Arrange
            using (var context = new DriveHubContext(_options))
            {
                var controller = new DeleteUsersController(context);

                // Act
                var result = await controller.Delete(1) as NotFoundResult;

                // Assert
                Assert.NotNull(result);
            }
        }
    }
}
