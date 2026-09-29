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
        
        // NY TEST INDSÆTTES HER, inde i klassen
        [TestMethod]
        public async Task GetById_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((User)null);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundObjectResult));
        }
        
        [TestMethod]
        public async Task Login_ReturnsUnauthorized_WhenUserDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(r => r.GetByUsernameAsync("ukendt")).ReturnsAsync((User)null);
            var model = new LoginModel { Username = "ukendt", Password = "hemmeligt" };

            // Act
            var result = await _controller.Login(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
        }
    
    }
}