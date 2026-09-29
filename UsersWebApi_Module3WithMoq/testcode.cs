/*
 using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Timers;
using UsersWebApi_Module3WithMoq.Controllers;
using UsersWebApi_Module3WithMoq.Models;

namespace UsersTestProject
{
    [TestClass]
    public sealed class UsersControllerTests
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
        public async Task GetById_UserExists_ReturnsUser()
        {
            // Arrange
            var expectedUser = new User { Id = 1, Name = "John Doe", Username = "john", Email = "john@test.com" };
            _mockRepository
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(expectedUser);

            // Act
            var result = await _controller.GetById(1);

            // Assert
            var user = result.Value;
            Assert.IsNotNull(user);

            // another assert
            Assert.AreEqual(expectedUser.Id, user!.Id);
            Assert.AreEqual(expectedUser.Name, user.Name);
            Assert.AreEqual(expectedUser.Username, user.Username);
            Assert.AreEqual(expectedUser.Email, user.Email);
            _mockRepository.Verify(r => r.GetByIdAsync(1), Times.Once);
        }
    }
}
*/