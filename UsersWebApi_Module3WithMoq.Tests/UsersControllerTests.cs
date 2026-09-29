using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UsersWebApi_Module3WithMoq.Controllers;
using UsersWebApi_Module3WithMoq.Models;

namespace UsersWebApi_Module3WithMoq.Tests
{
    [TestClass]
    public class UsersControllerTests
    {
        private Mock<IUserRepository> _mockRepository;
        private UsersController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<IUserRepository>();
            _controller = new UsersController(_mockRepository.Object);
        }

        [TestMethod]
        public async Task Create_ReturnsBadRequest_WhenModelStateInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("Email", "Required");
            var user = new User();

            // Act
            var result = await _controller.Create(user);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
        }
    }
}