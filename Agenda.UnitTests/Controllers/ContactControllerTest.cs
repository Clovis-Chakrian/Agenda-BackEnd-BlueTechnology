using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Agenda.API.Controllers;
using Agenda.API.Models;
using Agenda.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Agenda.UnitTests.Controllers
{
    public class ContactControllerTest
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.GetAllContacts()).ReturnsAsync(new List<Contact>());
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = (OkObjectResult)await controller.Get();

            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_InvolkesContactsServiceExactllyOnce()
        {
            // Arrange
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.GetAllContacts()).ReturnsAsync(new List<Contact>());
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            mockContactService.Verify(service => service.GetAllContacts(), Times.Once());
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnsListOfContacts()
        {
            // Arrange
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.GetAllContacts()).ReturnsAsync(new List<Contact>(){
                new Contact(){
                    Id = 1,
                    Name = "Clóvis",
                    LastName = "Chakrian",
                    Email = "clovischakrian@gmail.com",
                    Phone = "81985444683"
                }
            });
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objResult = (OkObjectResult)result;
            objResult.Value.Should().BeOfType<List<Contact>>();
        }

        [Fact]
        public async Task Get_OnNoUsersFound_ReturnsStringWithDescritiveMessage()
        {
            // Arrange
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.GetAllContacts()).ReturnsAsync(new List<Contact>());
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objResult = (OkObjectResult)result;
            objResult.Value.Should().Be("Nenhum contato cadastrado ainda.");
        }

        [Fact]
        public async Task GetById_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.GetContactById(1)).ReturnsAsync(new Contact()
            {
                Id = 1,
                Name = "Clóvis",
                LastName = "Chakrian",
                Email = "clovischakrian@gmail.com",
                Phone = "81985444683"
            });
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.GetById(1);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.StatusCode.Should().Be(200);
            objectResult.Value.Should().BeOfType<Contact>();
        }

        [Fact]
        public async Task GetById_OnNoUserFound_ReturnsStatusCode404() 
        {
            // Arrange
            var mockContactService = new Mock<IContactService>();
            mockContactService.Setup(service => service.GetContactById(1)).ReturnsAsync((Contact)null);
            var controller = new ContactController(mockContactService.Object);

            // Act
            var result = await controller.GetById(1);

            // Assert
            result.Should().BeOfType<NotFoundObjectResult>();
            var objectResult = (NotFoundObjectResult)result;
            objectResult.StatusCode.Should().Be(404);
            objectResult.Value.Should().Be("Não foi encontrado nenhum contato para o Id recebido.");
        }

        [Fact]
        public async Task Post_OnSuccess_ReturnsStatusCode201()
        {
            
        }
    }
}